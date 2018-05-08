using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Net.Mail;
using System.Text;
using MySql.Data;
using System.Net;
using System.Configuration;
using MySql.Data.MySqlClient;
using System.Globalization;
using System.Threading;
using System.Resources;
using System.Collections;
using System.Web.Configuration;
using System.Web.UI.HtmlControls;
 
public partial class EditTest : BasePage
{
    #region [ PROPERTIES ]

    public string mode
    {
        get
        {
            return Session["mode"] as string;
        }
        set
        {
            Session["mode"] = (string)value;
        }

    }

    public string Id
    {
        get
        {
            return Session["Id"] as string;
        }
        set
        {
            Session["Id"] = (string)value;
        }

    }

    #endregion

    #region [ PAGE EVENTS ]

    protected void Page_Init(object sender, EventArgs e)
    {
        try
        {
           if (!this.IsPostBack)
            {
                if (Request.QueryString["M"] != null)
                {
                    mode = Request.QueryString["M"].ToString();
                }
                else { mode = string.Empty; }

                if (Request.QueryString["Id"] != null)
                {
                    Id = Request.QueryString["Id"].ToString();
                }
                else { Id = string.Empty; }

                dtNuevasRespuestas = new DataTable();
                dtNuevasRespuestas.Columns.AddRange(new DataColumn[5] { new DataColumn("ID"), new DataColumn("PREGUNTA_ID"), new DataColumn("RESPUESTA_ID"), new DataColumn("TEXTO"), new DataColumn("SOLUCION_CORRECTA") });

                ApplyLayout();
            }
            else
            {
                
               //rptPreguntas.DataSource = dtPreguntas;
                //rptPreguntas.DataBind();
            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex;

            //((MasterPage)(this.Master)).SetLOG("ERROR", "Loading Page", "EditExam.aspx", "Exam", "Page_Init()", ex.Message, DateTime.Now, 1);
            // this.SetLOG("ERROR", "Loading Page", "EditExam.aspx", "Exam", "Page_Init()", ex.Message, DateTime.Now, 1);
            //Response.Redirect(Constants.PAGE_TITLE_ERROR_PAGE + Constants.ASP_PAGE_EXTENSION);
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        { 
            if (!this.IsPostBack)
            {
                
            }
            else
            {
                //FileUpload filex = (FileUpload)rptPreguntas.Items[0].FindControl("fileUploadcontrol"); 
            }

            //this.Title = "Edición Test";
        }
        catch (Exception ex)
        {
            Session["error"] = ex;
            //this.SetLOG("ERROR", "Loading Page", "EditExam.aspx", "Exam", "Page_Load()", ex.Message, DateTime.Now, 1);
            //Response.Redirect(Constants.PAGE_TITLE_ERROR_PAGE + Constants.ASP_PAGE_EXTENSION);
        }
    }

    #endregion

    #region [ EVENTS ]

    protected void btnVolver_Click(object sender, EventArgs e)
    {
        //Response.Redirect(Constants.PAGE_TITLE_TestList + Constants.ASP_PAGE_EXTENSION);
    }

    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        try
        {
            if (ValidateUserData())
            {
                //Obtenemos datos del formulario
                string cadenaConexion = ConfigurationManager.ConnectionStrings["Connection_qsg265"].ConnectionString;

                string consulta = string.Empty;
                int _id = 0;

                 
                string code = TestCode.Text;
                string name = TestName.Text;
                string title = TestTitle.Text;
                string description = TestDescription.Text;
                int productId = int.Parse(ddlTitulos.SelectedValue);
                string key = TestKey.Text;


                var arr = TestFechaExamen.Text.Split('/');
                DateTime dt = new DateTime(int.Parse(arr[2].ToString().Substring(0, 4)), int.Parse(arr[1].ToString()), int.Parse(arr[0].ToString()));

                String fecha = String.Format("{0:s}", dt);

                string from = TestFrom.Text;
                string sign = TestSign.Text;
                string instructions1 = TestInstructions1.Text;
                string instructions2 = TestInstructions2.Text;
                string header = TestHeaderNote.Text;
                string footer = TestFooterNote.Text;
                bool bAactive = TestActive.Checked;

                int iActive = 0;
                if (bAactive)
                {
                    iActive = 1;
                }

                //Ejecutamos acción de BD para la entidad ppal.
                
                switch (mode)
                {
                    //Nuevo
                    case "N": 
                        _id = GetLastTestId() + 1;

                        consulta = "INSERT INTO TEST(ID,  NOMBRE,  CODIGO,  TITULO,  DESCRIPCION,  CLAVE,  ORIGEN, FIRMA, FECHA, NOTA_INSTRUCCIONES1,  NOTA_INSTRUCCIONES2,  NOTA_CABECERA,  NOTA_PIE, PRODUCT_ID,  ACTIVE, CREATED) ";
                        consulta += " VALUES (" + _id + ",'" + name + "', '" + code + "', '" + title + "','" + description + "','" + key + "','" + from + "','" + sign + "','" + fecha + "', '" + instructions1 + "', '" + instructions2 + "','" + header + "','" + footer + "'," + productId + "," + iActive + ",'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "')";
                        // DateTime.Now.ToString("yyyyMMdd HH:mm:ss")
                        break;

                    //Editar
                    case "E":
                        _id = int.Parse(Id);

                        consulta = "UPDATE TEST SET updated='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "', NOMBRE='" + name.Replace("'", "`") + "', CODIGO='" + code + "', TITULO='" + title + "', DESCRIPCION='" + description + "', CLAVE='" + key + "', ORIGEN='" + from + "', FIRMA='" + sign + "', FECHA='" + fecha + "', NOTA_INSTRUCCIONES1='" + instructions1 + "', NOTA_INSTRUCCIONES2='" + instructions2 + "', NOTA_CABECERA='" + header + "', NOTA_PIE='" + footer + "', PRODUCT_ID=" + productId + ", ACTIVE=" + iActive;
                        consulta += " WHERE ID=" + _id;

                        break;
                }

                MySqlConnection cnn = new MySqlConnection(cadenaConexion);
                MySqlCommand mc = new MySqlCommand(consulta, cnn);
                 cnn.Open();
                mc.ExecuteNonQuery();
                cnn.Close();

                bool result = GuardarPreguntas();
             
            }
            else
            {
                //Marcar en rojo(border del textbox) los campos invalidos
                //Mostrar mensaje debajo de cabecera con la info para el usuario
            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex;
            //this.SetLOG("ERROR", "Saving_Page", "EditExam.aspx", "Exam", "btnGuardar_Click()", ex.Message, DateTime.Now, 1);
            //Response.Redirect(Constants.PAGE_TITLE_ERROR_PAGE + Constants.ASP_PAGE_EXTENSION, true);
        }
    }

    #endregion

    #region [ METHODS ]

    protected Int32 GetLastTestId()
    {
        try
        {
            string cadenaConexion = "Database=qsg265;Data Source=localhost;User Id=dbUser;Password=123";
            string Consulta = "SELECT max(Id)FROM TEST";
            MySqlConnection cnn = new MySqlConnection(cadenaConexion);
            MySqlCommand mc = new MySqlCommand(Consulta, cnn);

            cnn.Open();
            MySqlDataReader dr = mc.ExecuteReader();

            Int32 maxId = 0;
            if (!dr.IsClosed)
            {
                while (dr.Read())
                {
                    if (!dr.IsDBNull(0))
                    {
                        maxId = dr.GetInt32(0);
                    }
                }
            }
            cnn.Close();

            return maxId;
        }
        catch (Exception ex)
        {
            Session["error"] = ex;
//            this.SetLOG("ERROR", "READING DB", "EditExam.aspx", "Exam", "GetLastCenterId()", ex.Message, DateTime.Now, 1);
            //Response.Redirect(Constants.PAGE_TITLE_ERROR_PAGE + Constants.ASP_PAGE_EXTENSION);
            return 0;
        }
     }

    protected void FillDDLProducts()
    {
        try
        {
            string cadenaConexion = ConfigurationManager.ConnectionStrings["Connection_qsg265"].ConnectionString;
            string language_code = CultureInfo.CurrentCulture.TwoLetterISOLanguageName.ToString();

            string Consulta = " SELECT PRODUCT.id, literalName.DESCRIPTION FROM PRODUCT LEFT JOIN LITERALES AS literalName ON literalName.TEXT_CODE = PRODUCT.name_code AND literalName.LANGUAGE_CODE ='" + language_code + "' ORDER BY PRODUCT.id DESC";

            MySqlConnection cnn = new MySqlConnection(cadenaConexion);
            MySqlCommand mc = new MySqlCommand(Consulta, cnn);

            cnn.Open();
            MySqlDataReader dr = mc.ExecuteReader();

            DataTable dtProductos = new DataTable();

            dtProductos.Columns.AddRange(new DataColumn[2] { new DataColumn("ID"), new DataColumn("NOMBRE") });

            dtProductos.Rows.Add(0, string.Empty);
            if (!dr.IsClosed)
            {
                while (dr.Read())
                {
                    dtProductos.Rows.Add(dr.GetInt32(0), dr.GetString(1));
                }
            }
            cnn.Close();

            ddlTitulos.DataSource = dtProductos;
            ddlTitulos.DataBind();

        }
        catch (Exception ex)
        {
            Session["error"] = ex;
            throw ex;
        }

    }
        
    protected void FillTest()
    {
        try
        {
           string cadenaConexion = ConfigurationManager.ConnectionStrings["Connection_qsg265"].ConnectionString;

           string Consulta = "SELECT ID, NOMBRE, CODIGO, TITULO, DESCRIPCION, CLAVE, ORIGEN, FIRMA, FECHA, NOTA_INSTRUCCIONES1, NOTA_INSTRUCCIONES2, NOTA_CABECERA, NOTA_PIE, PRODUCT_ID, ACTIVE, CREATED, UPDATED FROM TEST WHERE ID =" + Id;

           MySqlConnection cnn = new MySqlConnection(cadenaConexion);
           MySqlCommand mc = new MySqlCommand(Consulta, cnn);

           cnn.Open();
           MySqlDataReader dr = mc.ExecuteReader();

           if (!dr.IsClosed)
            {
                while (dr.Read())
                {
                    
                    //CODE
                    if (!dr.IsDBNull(2))
                    {
                        TestCode.Text = dr.GetString(2);
                    }

                    //Name
                    if (!dr.IsDBNull(1))
                    {
                        TestName.Text = dr.GetString(1);
                    }

                    //Title
                    if (!dr.IsDBNull(3))
                    {
                        TestTitle.Text = dr.GetString(3);
                    }


                    //description
                    if (!dr.IsDBNull(4))
                    {
                        TestDescription.Text = dr.GetString(4);
                    }

                    //Titulo
                    if (!dr.IsDBNull(13))
                    {
                        ddlTitulos.SelectedValue = dr.GetString(13);
                    }


                    //Clave
                    if (!dr.IsDBNull(5))
                    {
                        TestKey.Text = dr.GetString(5);
                    }


                    //Fecha examen
                    if (!dr.IsDBNull(8))
                    {
                        TestFechaExamen.Text = dr.GetDateTime(8).ToString("dd/MM/yyyy HH:mm:ss");

                    }

                    //Origen
                    if (!dr.IsDBNull(6))
                    {
                        TestFrom.Text = dr.GetString(6);

                    }

                    //Firma
                    if (!dr.IsDBNull(7))
                    {
                        TestSign.Text = dr.GetString(7);

                    }


                    //Instrucciones 1
                    if (!dr.IsDBNull(9))
                    {
                        TestInstructions1.Text = dr.GetString(9);

                    }


                    //Instrucciones 2
                    if (!dr.IsDBNull(10))
                    {
                        TestInstructions2.Text = dr.GetString(10);

                    }


                    //Cabecera
                    if (!dr.IsDBNull(11))
                    {
                        TestHeaderNote.Text = dr.GetString(11);

                    }


                    //Pie
                    if (!dr.IsDBNull(12))
                    {
                        TestFooterNote.Text = dr.GetString(12);

                    }

                     
                    //ACTIVE
                    if (!dr.IsDBNull(14))
                    {
                        TestActive.Checked = dr.GetBoolean(14);
                    }

                }

                FillDDLProducts();

                FillPreguntasFromDB();

                FillDDLTypeForPregunta();



                FillDDLApartados();

            }
            cnn.Close();
         }
        catch (Exception ex)
        {
            Session["error"] = ex;
            //this.SetLOG("ERROR", "Loading Page", "EditExam.aspx", "Exam", "FillExam()", ex.Message, DateTime.Now, 1);
            //Response.Redirect(Constants.PAGE_TITLE_ERROR_PAGE + Constants.ASP_PAGE_EXTENSION);
        }
    }
     
    protected void EmptyFields()
    {
        TestCode.Text = String.Empty;
        TestName.Text = String.Empty;
        TestTitle.Text = String.Empty;
        TestDescription.Text = String.Empty;
        ddlTitulos.SelectedIndex = 0;
        TestKey.Text = String.Empty;
        TestFechaExamen.Text = String.Empty;
        TestFrom.Text = String.Empty;
        TestSign.Text = String.Empty;
        TestInstructions1.Text = String.Empty;
        TestInstructions2.Text = String.Empty;
        TestHeaderNote.Text = String.Empty;
        TestFooterNote.Text = String.Empty;
        TestActive.Checked = false;
    }
    
    protected void ApplyLayout()
    {
        try
        {
            switch (mode)
            {
                case "N":
                    btnGuardar.Visible = true;
                    btnVolver.Visible = true;
                    

                    TestCode.Enabled = true;
                    TestName.Enabled = true;
                    TestTitle.Enabled = true;
                    TestDescription.Enabled = true;
                    ddlTitulos.Enabled = true;
                    TestKey.Enabled = true;
                    TestFechaExamen.Enabled = true;
                    TestFrom.Enabled = true;
                    TestSign.Enabled = true;
                    TestInstructions1.Enabled = true;
                    TestInstructions2.Enabled = true;
                    TestHeaderNote.Enabled = true;
                    TestFooterNote.Enabled = true;
                    TestActive.Enabled = true;
                    btnCalendarFechaExamen.Enabled = true;
                    trEditRow.Visible = true;

                     

                    //imgEliminarPregunta.Enabled = true;

                   
                    FillDDLProducts();
                    EmptyFields();
                
                break;

                case "E":
                    btnGuardar.Visible = true;

                    btnVolver.Visible = true;
                    
                    TestCode.Enabled = true;
                    TestName.Enabled = true;
                    TestTitle.Enabled = true;
                    TestDescription.Enabled = true;
                    ddlTitulos.Enabled = true;
                    TestKey.Enabled = true;
                    TestFechaExamen.Enabled = true;
                    TestFrom.Enabled = true;
                    TestSign.Enabled = true;
                    TestInstructions1.Enabled = true;
                    TestInstructions2.Enabled = true;
                    TestHeaderNote.Enabled = true;
                    TestFooterNote.Enabled = true;
                    TestActive.Enabled = true;
                    btnCalendarFechaExamen.Enabled = true;
                    
                    //imgEliminarPregunta.Enabled = true;

                    trEditRow.Visible = true;

                    if(Id != string.Empty)
                    {
                        FillTest();
                    }

                break;

                case "V":
                    btnGuardar.Visible = false;
                    
                    btnVolver.Visible = true;

                    //imgEliminarPregunta.Enabled = false;
                    TestCode.Enabled = false;
                    TestName.Enabled = false;
                    TestTitle.Enabled = false;
                    TestDescription.Enabled = false;
                    ddlTitulos.Enabled = false;
                    TestKey.Enabled = false;
                    TestFechaExamen.Enabled = false;
                    TestFrom.Enabled = false;
                    TestSign.Enabled = false;
                    TestInstructions1.Enabled = false;
                    TestInstructions2.Enabled = false;
                    TestHeaderNote.Enabled = false;
                    TestFooterNote.Enabled = false;
                    TestActive.Enabled = false;
                    btnCalendarFechaExamen.Enabled = false;

                    trEditRow.Visible = false;

                    if (Id != null && Id != string.Empty)
                    {
                        FillTest();
                    }
                
                break;

                default:
                break;
            }
        }
        catch(Exception ex)
        {
            Session["error"] = ex;
            //this.SetLOG("ERROR", "Loading Page", "EditExam.aspx", "Exam", "ApplyLayout()", ex.Message, DateTime.Now, 1);
            //Response.Redirect(Constants.PAGE_TITLE_ERROR_PAGE + Constants.ASP_PAGE_EXTENSION);

        }
    }
    
    protected bool ValidateUserData()
    {
        bool validationResult = true;

        /*ExamNameES.BorderColor = System.Drawing.ColorTranslator.FromHtml("#e2e2e2");
        examCode.BorderColor = System.Drawing.ColorTranslator.FromHtml("#e2e2e2");
        ExamDescriptionES.BorderColor = System.Drawing.ColorTranslator.FromHtml("#e2e2e2");
       
        if (ExamNameES.Text.Trim() == String.Empty)
        {
            validationResult = false;
            ExamNameES.BorderColor = System.Drawing.Color.Red;
        }

        if (examCode.Text.Trim() == String.Empty)
        {
            validationResult = false;
            examCode.BorderColor = System.Drawing.Color.Red;
        }

        if (ExamDescriptionES.Text.Trim() == String.Empty)
        {
            validationResult = false;
            ExamDescriptionES.BorderColor = System.Drawing.Color.Red;
        }*/

        
        return validationResult;
    }

    #endregion

    #region [ REPEATER FOR PREGUNTAS & RESPUESTAS]

    #region [ Properties ]

    public DataTable dtPreguntas
    {
        get
        {
            return Session["dtPreguntas"] as DataTable;
        }
        set
        {
            Session["dtPreguntas"] = (DataTable)value;
        }
    }

    public DataTable dtNuevasRespuestas
    {
        get
        {
            return Session["dtNuevasRespuestas"] as DataTable;
        }
        set
        {
            Session["dtNuevasRespuestas"] = (DataTable)value;
        }
    } 

    #endregion

    #region [ Methods ]

    protected void FillDDLTypeForPregunta()
    {
        try
        {
            DataTable dtQuestionTypes = new DataTable();

            dtQuestionTypes = new DataTable();
            dtQuestionTypes.Columns.AddRange(new DataColumn[2] { new DataColumn("ID"), new DataColumn("TEXT") });

            dtQuestionTypes.Rows.Add(0, string.Empty);
            dtQuestionTypes.Rows.Add(1, Constants.QUESTION_TYPE_FREE);
            dtQuestionTypes.Rows.Add(2, Constants.QUESTION_TYPE_TEST);

            ddlTipoPregunta.DataSource = dtQuestionTypes;
            ddlTipoPregunta.DataBind();
            ddlTipoPregunta.SelectedIndex = 2;
            ddlTipoPregunta.Enabled = false;
        }
        catch (Exception ex)
        {
            Session["error"] = ex;
            throw ex;
        }
    }

    protected void FillDDLApartados()
    {
        try
        {
            DataTable dtApartados = new DataTable();

            dtApartados = new DataTable();
            dtApartados.Columns.AddRange(new DataColumn[2] { new DataColumn("ID"), new DataColumn("TEXT") });

            dtApartados.Rows.Add(0, string.Empty);
            dtApartados.Rows.Add(1, Constants.APARTADO_TEST_BALIZAMIENTO);
            dtApartados.Rows.Add(2, Constants.APARTADO_TEST_LEGISLACION);
            dtApartados.Rows.Add(3, Constants.APARTADO_TEST_MANIOBRAS);
            dtApartados.Rows.Add(4, Constants.APARTADO_TEST_METEOROLOGIA);
            dtApartados.Rows.Add(5, Constants.APARTADO_TEST_NAVEGACIÓN);
            dtApartados.Rows.Add(6, Constants.APARTADO_TEST_PROPULSION);
            dtApartados.Rows.Add(7, Constants.APARTADO_TEST_RADIOCOMUNICACIONES);
            dtApartados.Rows.Add(8, Constants.APARTADO_TEST_RIPA);
            dtApartados.Rows.Add(9, Constants.APARTADO_TEST_SEGURIDAD);
            dtApartados.Rows.Add(10, Constants.APARTADO_TEST_TECNOLOGIA);

            ddlApartado.DataSource = dtApartados;
            ddlApartado.DataBind();
        }
        catch (Exception ex)
        {
            Session["error"] = ex;
            throw ex;
        }
    }

    protected void FillPreguntasFromDB()
    {
        try
        {
            DataTable dtPreguntas = new DataTable();
            dtPreguntas = GetPreguntas();

            if (dtPreguntas != null)
            {
                rptPreguntas.DataSource = dtPreguntas;
                rptPreguntas.DataBind();
                rptPreguntas.Visible = true;
            }
            else
            {
                rptPreguntas.DataSource = null;
                rptPreguntas.DataBind();
                rptPreguntas.Visible = false;
            }

            lblPreguntaID.Text = (GetLastPreguntaId() + 1) + ".";
        }
        catch (Exception ex)
        {
            Session["error"] = ex;
            throw ex;
        }

    }

    protected Int32 GetLastPreguntaId()
    {
        try
        {
            Int32 maxId = 0;
            if (dtPreguntas.Rows.Count > 0)
            {
                foreach (DataRow dr in dtPreguntas.Rows)
                {
                    if (int.Parse(dr["PREGUNTA_ID"].ToString()) > maxId)
                    {
                        maxId = int.Parse(dr["PREGUNTA_ID"].ToString());
                    }
                }
            }
            return maxId;
        }
        catch (Exception ex)
        {
            Session["error"] = ex;
            //this.SetLOG("ERROR", "READING DB", "EditExam.aspx", "Exam", "GetLastPreguntaId()", ex.Message, DateTime.Now, 1);
            //Response.Redirect(Constants.PAGE_TITLE_ERROR_PAGE + Constants.ASP_PAGE_EXTENSION);
            return 0;
        }
    }

    protected Int32 GetLastRowIDForPregunta()
    {
        try
        {
            string cadenaConexion = "Database=qsg265;Data Source=localhost;User Id=dbUser;Password=123";
            string Consulta = "SELECT max(id)FROM PREGUNTA";
            MySqlConnection cnn = new MySqlConnection(cadenaConexion);
            MySqlCommand mc = new MySqlCommand(Consulta, cnn);

            cnn.Open();
            MySqlDataReader dr = mc.ExecuteReader();

            Int32 maxId = 0;
            if (!dr.IsClosed)
            {
                while (dr.Read())
                {
                    if (!dr.IsDBNull(0))
                    {
                        maxId = dr.GetInt32(0);
                    }
                }
            }
            cnn.Close();

            return maxId;
        }
        catch (Exception ex)
        {
            Session["error"] = ex;
            //this.SetLOG("ERROR", "READING DB", "EditExam.aspx", "Exam", "GetLastConvocationd()", ex.Message, DateTime.Now, 1);
            //Response.Redirect(Constants.PAGE_TITLE_ERROR_PAGE + Constants.ASP_PAGE_EXTENSION);
            return 0;
        }
    }

    private void ResetRowForNewQuestion()
    {
        try
        {
            lblPreguntaID.Text = (GetLastPreguntaId() + 1) + ".";

            ddlTipoPregunta.SelectedIndex = 0;
            ddlApartado.SelectedIndex = 0;
            txtTextoPregunta.Text = string.Empty;
            txtFileDetails.Text = string.Empty;
            txtTextoRespuesta.Text = string.Empty;
            //FeatureImageMiniatura.ImageUrl = Constants.NoImageParaPreguntaTestOnline;
            FeatureImage.ImageUrl = Constants.NoImageParaPreguntaTestOnline;

            txtRespuestaTest1.Text = string.Empty;
            txtRespuestaTest2.Text = string.Empty;
            txtRespuestaTest3.Text = string.Empty;
            txtRespuestaTest4.Text = string.Empty;

        }
        catch (Exception ex)
        {
            Session["error"] = ex;
            //this.SetLOG("ERROR", "Deleting_Convocation", "EditExam.aspx", "Exam", "ddlTipoPregunta_SelectedIndexChanged()", ex.Message, DateTime.Now, 1);
            throw ex;
        }
    }

    protected bool ValidateUserDataForPregunta()
    {
        bool validationResult = true;

        ddlApartado.BorderColor = System.Drawing.ColorTranslator.FromHtml("#e2e2e2");
        ddlTipoPregunta.BorderColor = System.Drawing.ColorTranslator.FromHtml("#e2e2e2");
        txtTextoPregunta.BorderColor = System.Drawing.ColorTranslator.FromHtml("#e2e2e2");
        
        txtTextoRespuesta.BorderColor = System.Drawing.ColorTranslator.FromHtml("#e2e2e2");
        txtRespuestaTest1.BorderColor = System.Drawing.ColorTranslator.FromHtml("#e2e2e2");
        txtRespuestaTest2.BorderColor = System.Drawing.ColorTranslator.FromHtml("#e2e2e2");
        txtRespuestaTest3.BorderColor = System.Drawing.ColorTranslator.FromHtml("#e2e2e2");
        txtRespuestaTest4.BorderColor = System.Drawing.ColorTranslator.FromHtml("#e2e2e2");

        if (txtTextoPregunta.Text.Trim() == String.Empty)
        {
            validationResult = false;
            txtTextoPregunta.BorderColor = System.Drawing.Color.Red;
        }

        if (ddlApartado.SelectedItem.Text == String.Empty)
        {
            validationResult = false;
            ddlApartado.BorderColor = System.Drawing.Color.Red;
        }

        if (ddlTipoPregunta.SelectedItem.Text == String.Empty)
        {
            validationResult = false;
            ddlTipoPregunta.BorderColor = System.Drawing.Color.Red;
        }

        switch (ddlTipoPregunta.SelectedItem.Text)
        {
            case Constants.QUESTION_TYPE_FREE:

                /*if (txtTextoRespuesta.Text.Trim() == String.Empty)
                {
                    validationResult = false;
                    txtTextoRespuesta.BorderColor = System.Drawing.Color.Red;
                }*/

                break;

            case Constants.QUESTION_TYPE_TEST:

                if (txtRespuestaTest1.Text.Trim() == String.Empty)
                {
                    validationResult = false;
                    txtRespuestaTest1.BorderColor = System.Drawing.Color.Red;
                }

                if (txtRespuestaTest2.Text.Trim() == String.Empty)
                {
                    validationResult = false;
                    txtRespuestaTest2.BorderColor = System.Drawing.Color.Red;
                }

                if (txtRespuestaTest3.Text.Trim() == String.Empty)
                {
                    validationResult = false;
                    txtRespuestaTest3.BorderColor = System.Drawing.Color.Red;
                }

                if (txtRespuestaTest4.Text.Trim() == String.Empty)
                {
                    validationResult = false;
                    txtRespuestaTest4.BorderColor = System.Drawing.Color.Red;
                }

                break;

            default:

                break;
        }

        return validationResult;
    }

    private DataTable GetPreguntas()
    {
        try
        {
            string cadenaConexion = ConfigurationManager.ConnectionStrings["Connection_qsg265"].ConnectionString;

            //CAMBIAR ESTO, METERLO COMO PROPIEDAD EN LA PAGINA BASE(O MASTER PAGE) "GetLanguageCode()
            //string language_code = CultureInfo.CurrentCulture.TwoLetterISOLanguageName.ToString();

            string Consulta = "SELECT ID, PREGUNTA_ID, TIPO, APARTADO, TEXTO, IMAGEN_URL FROM PREGUNTA WHERE TEST_ID =" + Id + " ORDER BY PREGUNTA_ID, APARTADO ASC";

            MySqlConnection cnn = new MySqlConnection(cadenaConexion);
            MySqlCommand mc = new MySqlCommand(Consulta, cnn);

            cnn.Open();
            MySqlDataReader dr = mc.ExecuteReader();

            dtPreguntas = new DataTable();
            dtPreguntas.Columns.AddRange(new DataColumn[7] { new DataColumn("ID"), new DataColumn("PREGUNTA_ID"), new DataColumn("TIPO"), new DataColumn("APARTADO"), new DataColumn("TEXTO"), new DataColumn("IMAGEN_URL"), new DataColumn("chkSelect") });

            if (!dr.IsClosed)
            {
                while (dr.Read())
                {
                    dtPreguntas.Rows.Add(dr.GetInt32(0), dr.GetInt32(1), dr.GetString(2), dr.GetString(3), dr.GetString(4), dr.GetString(5), false);
                }
            }
            cnn.Close();

        }
        catch (Exception ex)
        {
            Session["error"] = ex;
            //this.SetLOG("ERROR", "Deleting_Convocation", "EditExam.aspx", "Test", "GetPreguntas()", ex.Message, DateTime.Now, 1);
            throw ex;
        }

        return dtPreguntas;
    }

    private DataTable GetRespuesta(int preguntaID, bool isNew)
    {
        try
        {
            DataTable dtRespuesta = new DataTable();

            dtRespuesta.Columns.AddRange(new DataColumn[5] { new DataColumn("ID"), new DataColumn("PREGUNTA_ID"), new DataColumn("RESPUESTA_ID"), new DataColumn("TEXTO"), new DataColumn("SOLUCION_CORRECTA") });

            if(!isNew)
            { 
                string cadenaConexion = ConfigurationManager.ConnectionStrings["Connection_qsg265"].ConnectionString;

                string Consulta = "SELECT ID, PREGUNTA_ID, RESPUESTA_ID, TEXTO, SOLUCION_CORRECTA FROM RESPUESTA WHERE PREGUNTA_ID =" + preguntaID + " ORDER BY RESPUESTA_ID ASC ";

                MySqlConnection cnn = new MySqlConnection(cadenaConexion);
                MySqlCommand mc = new MySqlCommand(Consulta, cnn);

                cnn.Open();
                MySqlDataReader dr = mc.ExecuteReader();

                if (!dr.IsClosed)
                {
                    while (dr.Read())
                    {
                        dtRespuesta.Rows.Add(dr.GetInt32(0), dr.GetInt32(1), dr.GetInt32(2), dr.GetString(3), ((dr.IsDBNull(4)) ? 0 : dr.GetInt32(4)) );
                    }
                }
                cnn.Close();
            
            }
            else
            {
                foreach(DataRow dr in dtNuevasRespuestas.Rows)
                {
                    if (dr["PREGUNTA_ID"].ToString() == (preguntaID).ToString())
                    {
                        dtRespuesta.Rows.Add(int.Parse(dr["ID"].ToString()), int.Parse(dr["PREGUNTA_ID"].ToString()), int.Parse(dr["RESPUESTA_ID"].ToString()), dr["TEXTO"].ToString(), (int.Parse(dr["SOLUCION_CORRECTA"].ToString())));
                    }
                }
            }

            return dtRespuesta;
        }
        catch (Exception ex)
        {
            Session["error"] = ex;
            //this.SetLOG("ERROR", "Deleting_Convocation", "EditExam.aspx", "Test", "GetPreguntas()", ex.Message, DateTime.Now, 1);
            throw ex;
        }
    }

    protected bool GuardarPreguntas()
    {
        try
        {
            if (EliminarPreguntas(ConfigurationManager.ConnectionStrings["Connection_qsg265"].ConnectionString))
            {
                if (dtPreguntas.Rows.Count > 0)
                {
                    string drID = string.Empty;
                    string drPREGUNTA_ID = string.Empty;
                    string drTIPO = string.Empty;
                    string drAPARTADO = string.Empty;
                    string drTEXTO = string.Empty;
                    //string drTEST_ID = string.Empty;
                    string drIMAGEN_URL = string.Empty; 

                    foreach (DataRow dr in dtPreguntas.Rows)
                    {
                        drID = dr["ID"].ToString();
                        drPREGUNTA_ID = dr["PREGUNTA_ID"].ToString();
                        drTIPO = dr["TIPO"].ToString();
                        drAPARTADO = dr["APARTADO"].ToString();
                        drTEXTO = dr["TEXTO"].ToString();
                        drIMAGEN_URL = dr["IMAGEN_URL"].ToString();

                        string consulta = "INSERT INTO PREGUNTA(ID, PREGUNTA_ID, TIPO, TEST_ID, APARTADO, TEXTO, IMAGEN_URL) ";
                        consulta = consulta + "VALUES(" + drID + ", " + drPREGUNTA_ID + ", 'Test', " + Int32.Parse(Id) + ", '" + drAPARTADO + "','" + drTEXTO + "', '" + drIMAGEN_URL + "')";

                        MySqlConnection cnn = new MySqlConnection(ConfigurationManager.ConnectionStrings["Connection_qsg265"].ConnectionString);
                        MySqlCommand mc = new MySqlCommand(consulta, cnn);
                        cnn.Open();
                        mc.ExecuteNonQuery();
                        cnn.Close();

                        if (EliminarRespuestas(ConfigurationManager.ConnectionStrings["Connection_qsg265"].ConnectionString))
                        {
                            foreach(DataRow drRespuesta in dtNuevasRespuestas.Rows)
                            {
                                string drR_ID = drRespuesta[0].ToString();
                                string drR_PREGUNTA_ID = drRespuesta[1].ToString();
                                string drR_RESPUESTA_ID = drRespuesta[2].ToString();
                                string drR_TEXTO = drRespuesta[3].ToString();
                                int drR_SOLUCION_CORRECTA = drRespuesta[4].ToString() == "1" ? 1 : 0;

                                if(drPREGUNTA_ID == drR_PREGUNTA_ID)
                                {
                                    string consultaRespuesta = "INSERT INTO RESPUESTA(ID, PREGUNTA_ID, RESPUESTA_ID, TEXTO, SOLUCION_CORRECTA) ";

                                    consultaRespuesta = consultaRespuesta + " VALUES(" + drR_ID + ", " + drR_PREGUNTA_ID + ", " + drR_RESPUESTA_ID + ", '" + drR_TEXTO + "'," + drR_SOLUCION_CORRECTA + ")";
                                
                                    MySqlConnection cnnR = new MySqlConnection(ConfigurationManager.ConnectionStrings["Connection_qsg265"].ConnectionString);
                                    MySqlCommand mcR = new MySqlCommand(consultaRespuesta, cnnR);
                                    cnnR.Open();
                                    mcR.ExecuteNonQuery();
                                    cnnR.Close();
                                }
                            }
                        }
                    }
                }
                //Response.Redirect(Constants.PAGE_TITLE_TestList + Constants.ASP_PAGE_EXTENSION, false);
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex;
            throw ex;
        }
    }
   
    protected bool UpdateFeaturedImagePath(string imagePath, string preguntaID)
    {
        try
        {
            string cadenaConexion = ConfigurationManager.ConnectionStrings["Connection_qsg265"].ConnectionString;

            string consulta = "UPDATE PREGUNTA SET IMAGEN_URL='" + imagePath + "' WHERE TEST_ID=" + Id + " AND PREGUNTA_ID=" + preguntaID;

            MySqlConnection cnn = new MySqlConnection(cadenaConexion);
            MySqlCommand mc = new MySqlCommand(consulta, cnn);
            cnn.Open();
            mc.ExecuteNonQuery();
            cnn.Close();

            return true;
        }
        catch (Exception ex)
        {
            Session["error"] = ex;
            //Response.Redirect(Constants.PAGE_TITLE_ERROR_PAGE + Constants.ASP_PAGE_EXTENSION, true);
            return false;
        }
    }

    protected bool ValidateImage(FileUpload fileUpload)
    {
        bool validationResult = false;
        if (fileUpload.HasFile == false)
        {
            // No file uploaded!
            txtFileDetails.Text = "Se ha de seleccionar primero una imagen.";
            return validationResult;
        }
        else
        {
            string fileExtension;
            fileExtension = System.IO.Path.GetExtension(fileUpload.FileName).ToLower();
            string[] allowedExtensions = { ".jpg", ".jpeg", ".png", ".gif" };

            for (int i = 0; i <= allowedExtensions.Length - 1; i++)
            {
                if (fileExtension == allowedExtensions[i])
                {
                    validationResult = true;
                }
            }

            if (!validationResult)
            {
                txtFileDetails.Text = "Tipo de fichero no aceptado.";
            }

            int fileSize = fileUpload.PostedFile.ContentLength;
            int maxSizeForFeatureImage = int.Parse(WebConfigurationManager.AppSettings["TestQuestionImageMaxSize"]);
            int maxSizeForFeatureImageInBytes = ((maxSizeForFeatureImage * 1024) * 1024);

            // Allow only files less than 2,100,000 bytes (approximately 2 MB) to be uploaded.
            if (fileSize > maxSizeForFeatureImageInBytes)
            {
                txtFileDetails.Text = "El tamaño de la imagen es demasiado grande. El tamaño máximo permitido es: " + maxSizeForFeatureImage + "MB";
                validationResult = false;
            }

            if (validationResult)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    protected bool EliminarRespuestas(string cadenaConexion)
        {
            try
            {
                string consulta = "DELETE FROM RESPUESTA WHERE PREGUNTA_ID in(SELECT PREGUNTA_ID FROM PREGUNTA WHERE TEST_ID=" + Id +")";

                MySqlConnection cnn = new MySqlConnection(cadenaConexion);
                MySqlCommand mc = new MySqlCommand(consulta, cnn);
                //cnn.Open();
                //mc.ExecuteNonQuery();
                //cnn.Close();

                return true;
            }
            catch (Exception ex)
            {
                Session["error"] = ex;
                throw ex;
            }


        }
    
    protected bool EliminarPreguntas(string cadenaConexion)
    {
        try
        {
            string consulta = "DELETE FROM PREGUNTA WHERE TEST_ID=" + Id;

            MySqlConnection cnn = new MySqlConnection(cadenaConexion);
            MySqlCommand mc = new MySqlCommand(consulta, cnn);
            cnn.Open();
            mc.ExecuteNonQuery();
            cnn.Close();

            return true;
        }
        catch (Exception ex)
        {
            Session["error"] = ex;
            throw;
        }
    }

    protected Int32 GetLastRowIDForRespuesta()
    {
        try
        {
            string cadenaConexion = "Database=qsg265;Data Source=localhost;User Id=dbUser;Password=123";
            string Consulta = "SELECT max(id)FROM RESPUESTA";
            MySqlConnection cnn = new MySqlConnection(cadenaConexion);
            MySqlCommand mc = new MySqlCommand(Consulta, cnn);

            cnn.Open();
            MySqlDataReader dr = mc.ExecuteReader();

            Int32 maxId = 0;
            if (!dr.IsClosed)
            {
                while (dr.Read())
                {
                    if (!dr.IsDBNull(0))
                    {
                        maxId = dr.GetInt32(0);
                    }
                }
            }
            cnn.Close();

            return maxId;
        }
        catch (Exception ex)
        {
            Session["error"] = ex;
            //this.SetLOG("ERROR", "READING DB", "EditTest.aspx", "Test", "GetLastRowIDForRespuesta()", ex.Message, DateTime.Now, 1);
            //Response.Redirect(Constants.PAGE_TITLE_ERROR_PAGE + Constants.ASP_PAGE_EXTENSION);
            return 0;
        }
    }

    #endregion

    #region [ Events ]
     
    protected void UploadButton_Click(Object sender, EventArgs e)
    {
        try
        {
            Button imgBtnImageUpload = (Button)sender;

            string idPregunta = imgBtnImageUpload.ToolTip;

            //ContentPlaceHolder myPlaceHolder = (ContentPlaceHolder)Master.FindControl("MainContent");

            //HtmlControl fileUploadXXX = (HtmlControl)myPlaceHolder.FindControl("fileUploadcontrol_3");

            //Repeater rpt = (Repeater)myPlaceHolder.FindControl("rptPreguntas");

            //RepeaterItem rptItem = (RepeaterItem)rpt.Controls[0];
            //rptItem.Controls[0].FindControl("fileUploadcontrol_3");

            int cnt = 0;
            foreach (DataRow dr in dtPreguntas.Rows)
            {
                if (dr["PREGUNTA_ID"].ToString() == idPregunta)
                {
                    break;
                }
                cnt++;
            }

            //FileUpload fileUpload = (FileUpload)rptItem.Controls[cnt].FindControl("fileUploadcontrol");

            foreach (RepeaterItem item in rptPreguntas.Items)
             {
                 FileUpload file = (FileUpload)item.FindControl("fileUploadcontrol");
                 String fileName = file.FileName;
                
                //file.SaveAs(Server.MapPath(savePath + fileName));
              }

            FileUpload filex = (FileUpload)rptPreguntas.Items[cnt].FindControl("fileUploadcontrol");


            if (filex.HasFile && ValidateImage(filex))
            {
                string path = Server.MapPath(WebConfigurationManager.AppSettings["TestQuestionImagePath"]);

                // Display the uploaded file's details
                txtFileDetails.Text = String.Format("Fichero publicado: {0}" + "Tamaño (in bytes): {1:N0}" + "Tipo: {2}", fileUploadcontrol.FileName + "\n", fileUploadcontrol.FileBytes.Length + "\n", fileUploadcontrol.PostedFile.ContentType);

                //Save the file
                //string friendlyName = "Destacado_" + DateTime.Now.ToShortDateString().Replace("/", "-") + fileUploadcontrol.FileName.Substring(fileUploadcontrol.FileName.Length-4, 4);

                string filePath = path + fileUploadcontrol.FileName;
                fileUploadcontrol.SaveAs(filePath);
                //System.Drawing.Image.FromFile(fileUploadcontrol.FileName).Save(Server.MapPath("~/Files2/" & fileUploadcontrol.FileName))

                UpdateFeaturedImagePath(WebConfigurationManager.AppSettings["TestQuestionImagePath"] + fileUploadcontrol.FileName, idPregunta);
            }
            else
            {

            }
        }
        catch (Exception ex)               
        {
            txtFileDetails.Text = "No se ha podido cargar correctamente la imagen para la pregunta.";
                        Session["error"] = ex;
            //Response.Redirect(Constants.PAGE_TITLE_ERROR_PAGE + Constants.ASP_PAGE_EXTENSION, true);
        }
    }

    protected void rptPreguntas_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        try
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                DataRowView dv = (DataRowView)e.Item.DataItem;
                DataRow dr = dv.Row;

                Label lblPreguntaID = (Label)e.Item.FindControl("lblPreguntaID");
                int idPregunta = int.Parse(lblPreguntaID.Text);

                HiddenField hdnCheckIsNew = (HiddenField)e.Item.FindControl("hdnCheckIsNew");

                //
                //FileUpload fileUploadcontrol = new FileUpload();
                //fileUploadcontrol.ID = "fileUploadcontrol_" + idPregunta.ToString();
                //fileUploadcontrol.ClientIDMode = ClientIDMode.Static;
                //fileUploadcontrol.Enabled = false;

                //HtmlTableCell tdUpload = (HtmlTableCell)e.Item.FindControl("tdUpload");
                //tdUpload.Controls.Add(fileUploadcontrol);

                 ImageButton imgEliminarPregunta = (ImageButton)e.Item.FindControl("imgEliminarPregunta");
                  switch (mode)
                {
                    case "N":
                        imgEliminarPregunta.Enabled = true;
                        fileUploadcontrol.Enabled = false;
                        break;

                    case "E":
                        imgEliminarPregunta.Enabled = true;
                        fileUploadcontrol.Enabled = true;
                        break;

                    case "V":
                        imgEliminarPregunta.Enabled = false;
                        fileUploadcontrol.Enabled = false;
                        break;
                }

                DataTable dtRespuesta = GetRespuesta(idPregunta, (hdnCheckIsNew.Value == "True" ? true : false));

                TextBox txtPreguntaTipo = (TextBox)e.Item.FindControl("PreguntaTipo");
                string tipoPregunta = txtPreguntaTipo.Text;

                System.Web.UI.HtmlControls.HtmlControl divRespuestaLibre = (System.Web.UI.HtmlControls.HtmlControl)e.Item.FindControl("divRespuestaLibre");
                System.Web.UI.HtmlControls.HtmlControl divRespuestaTest = (System.Web.UI.HtmlControls.HtmlControl)e.Item.FindControl("divRespuestaTest");

                TextBox txtTextoRespuesta = (TextBox)e.Item.FindControl("txtTextoRespuesta");

                switch (tipoPregunta)
                {
                    case Constants.QUESTION_TYPE_TEST:

                        if (dtRespuesta != null && dtRespuesta.Rows.Count == 4)
                        {
                            txtTextoRespuesta.Text = string.Empty;

                            RadioButtonList rblOpciones = (RadioButtonList)e.Item.FindControl("rblOpciones");

                            rblOpciones.Items[0].Value = dtRespuesta.Rows[0]["RESPUESTA_ID"].ToString();
                            rblOpciones.Items[1].Value = dtRespuesta.Rows[1]["RESPUESTA_ID"].ToString();
                            rblOpciones.Items[2].Value = dtRespuesta.Rows[2]["RESPUESTA_ID"].ToString();
                            rblOpciones.Items[3].Value = dtRespuesta.Rows[3]["RESPUESTA_ID"].ToString();

                            rblOpciones.Items[0].Text = "  " + dtRespuesta.Rows[0]["RESPUESTA_ID"].ToString() + ". " + dtRespuesta.Rows[0]["TEXTO"].ToString();
                            rblOpciones.Items[1].Text = "  " + dtRespuesta.Rows[1]["RESPUESTA_ID"].ToString() + ". " + dtRespuesta.Rows[1]["TEXTO"].ToString();
                            rblOpciones.Items[2].Text = "  " + dtRespuesta.Rows[2]["RESPUESTA_ID"].ToString() + ". " + dtRespuesta.Rows[2]["TEXTO"].ToString();
                            rblOpciones.Items[3].Text = "  " + dtRespuesta.Rows[3]["RESPUESTA_ID"].ToString() + ". " + dtRespuesta.Rows[3]["TEXTO"].ToString();

                            rblOpciones.Items[0].Selected = ((int.Parse(dtRespuesta.Rows[0]["SOLUCION_CORRECTA"].ToString()) == 0) ? false : true);
                            rblOpciones.Items[1].Selected = ((int.Parse(dtRespuesta.Rows[1]["SOLUCION_CORRECTA"].ToString()) == 0) ? false : true);
                            rblOpciones.Items[2].Selected = ((int.Parse(dtRespuesta.Rows[2]["SOLUCION_CORRECTA"].ToString()) == 0) ? false : true);
                            rblOpciones.Items[3].Selected = ((int.Parse(dtRespuesta.Rows[3]["SOLUCION_CORRECTA"].ToString()) == 0) ? false : true);

                            rblOpciones.Visible = true;

                            divRespuestaLibre.Visible = false;
                            divRespuestaTest.Visible = true;

                        }
                        else
                        {

                            //

                        }

                    break;

                    default:

                        break;
                }

            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex;
            //this.SetLOG("ERROR", "Printing_Convocation", "EditExam.aspx", "Exam", "rptConvocations_ItemDataBound()", ex.Message, DateTime.Now, 1);
            //Response.Redirect(Constants.PAGE_TITLE_ERROR_PAGE + Constants.ASP_PAGE_EXTENSION, true);
        }

    }

    protected void btnEliminar_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            int rowIndex = ((RepeaterItem)((ImageButton)sender).NamingContainer).ItemIndex;

            Label lblPreguntaId = ((Label)rptPreguntas.Items[rowIndex].FindControl("lblPreguntaID"));
            int idPregunta = int.Parse(lblPreguntaId.Text);

            HiddenField hdnIsNew = ((HiddenField)rptPreguntas.Items[rowIndex].FindControl("hdnCheckIsNew"));

            List<DataRow> lstRowToDelete = new List<DataRow>();
            if(hdnIsNew.Value.ToUpper() == "TRUE")
            {
                foreach(DataRow dr in dtNuevasRespuestas.Rows)
                {
                    if(int.Parse(dr["PREGUNTA_ID"].ToString()) == idPregunta)
                    {
                        lstRowToDelete.Add(dr);
                    }
                }
            }
            
            foreach(DataRow row in lstRowToDelete)
            {
                dtNuevasRespuestas.Rows.Remove(row);
            }

            //lblPreguntaId
             
            dtPreguntas.Rows.RemoveAt(rowIndex);
            rptPreguntas.DataSource = dtPreguntas;
            rptPreguntas.DataBind();

        }
        catch (Exception ex)
        {
            Session["error"] = ex;
            //this.SetLOG("ERROR", "Deleting_Convocation", "EditExam.aspx", "Exam", "btnEliminar_Click()", ex.Message, DateTime.Now, 1);
            //Response.Redirect(Constants.PAGE_TITLE_ERROR_PAGE + Constants.ASP_PAGE_EXTENSION, true);
        }
    }

    protected void ddlTipoPregunta_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            switch (ddlTipoPregunta.SelectedItem.Text)
            {
                case Constants.QUESTION_TYPE_FREE:

                    //divRespuestaLibre.Visible = true;
                    //divRespuestaTest.Visible = false;

                    break;

                case Constants.QUESTION_TYPE_TEST:

                    divRespuestaLibre.Visible = false;
                    divRespuestaTest.Visible = true;

                    break;

                default:

                    divRespuestaLibre.Visible = false;
                    divRespuestaTest.Visible = false;

                    break;
            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex;
            //this.SetLOG("ERROR", "Deleting_Convocation", "EditExam.aspx", "Exam", "ddlTipoPregunta_SelectedIndexChanged()", ex.Message, DateTime.Now, 1);
            //Response.Redirect(Constants.PAGE_TITLE_ERROR_PAGE + Constants.ASP_PAGE_EXTENSION, true);
        }
    }

    protected void rdbRespuestaTest_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            RadioButton rdb = ((RadioButton)sender);

            List<RadioButton> lstRbtn = new List<RadioButton>
            {
                rdbRespuestaTest1,
                rdbRespuestaTest2,
                rdbRespuestaTest3,
                rdbRespuestaTest4
            };

            foreach (RadioButton radioButtonElement in lstRbtn)
            {
                if (radioButtonElement.ID != rdb.ID)
                {
                    radioButtonElement.Checked = false;
                }
            }

        }
        catch (Exception ex)
        {
            Session["error"] = ex;
            //this.SetLOG("ERROR", "Deleting_Convocation", "EditExam.aspx", "Exam", "rdbRespuestaTest_CheckedChanged()", ex.Message, DateTime.Now, 1);
            //Response.Redirect(Constants.PAGE_TITLE_ERROR_PAGE + Constants.ASP_PAGE_EXTENSION, true);
        }
    }
    
    protected void imgAñadirPregunta_Click(object sender, ImageClickEventArgs e)
    {
        AddPregunta();
        FillDDLTypeForPregunta();
    }

    protected void AddPregunta()
    {
        if (ValidateUserDataForPregunta())
        {
                //PREGUNTA
                int id = GetLastRowIDForPregunta() + 1;

                int pregunta_id = GetLastPreguntaId() + 1;
             
                //int pregunta_id = int.Parse(lblPreguntaID.Text.Replace(".", string.Empty));
                string tipoPregunta = ddlTipoPregunta.SelectedItem.Text;
                string apartadoPregunta = ddlApartado.SelectedItem.Text;
                string texotPregunta = txtTextoPregunta.Text;
                string imagenURL = Constants.NoImageParaPreguntaTestOnline;

                dtPreguntas.Rows.Add(id + 1, pregunta_id, tipoPregunta, apartadoPregunta, texotPregunta, imagenURL, true);

                //RESPUESTA/S

                //2DO: esto petara la segunda vez!
                int primaryId = GetLastRowIDForRespuesta() + 1;

                switch (tipoPregunta)
                {
                    case Constants.QUESTION_TYPE_FREE:

                        //dtNuevasRespuestas.Rows.Add(primaryId, pregunta_id, 1, txtTextoRespuesta.Text, 0);

                    break;

                    case Constants.QUESTION_TYPE_TEST:

                        dtNuevasRespuestas.Rows.Add(primaryId, pregunta_id, 1, txtRespuestaTest1.Text, (rdbRespuestaTest1.Checked) ? 1 :0);
                        dtNuevasRespuestas.Rows.Add(primaryId + 1, pregunta_id, 2, txtRespuestaTest2.Text, (rdbRespuestaTest2.Checked) ? 1 :0);
                        dtNuevasRespuestas.Rows.Add(primaryId + 2, pregunta_id, 3, txtRespuestaTest3.Text, (rdbRespuestaTest3.Checked) ? 1 :0);
                        dtNuevasRespuestas.Rows.Add(primaryId + 3, pregunta_id, 4, txtRespuestaTest4.Text, (rdbRespuestaTest4.Checked) ? 1 :0);

                    break;

                    default:
                        //
                    break;
                }

                //BIND REPEATER
                rptPreguntas.DataSource = dtPreguntas;
                rptPreguntas.DataBind();

                ResetRowForNewQuestion();
            }
            else
            {

            }



}
     
    #endregion

    #endregion

}
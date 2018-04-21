using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using System.Data;
using MySql.Data.MySqlClient;
using System.Web.UI.HtmlControls;
using System.Web.UI;

public partial class TestOnline : BasePage
{
    #region [ Properties ]

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

        public List<RadioButtonList> lstPreguntasRespuestas
        {
            get
            {
               return Session["lstPreguntasRespuestas"] as List<RadioButtonList>;
            }
            set
            {
                Session["lstPreguntasRespuestas"] = (List<RadioButtonList>)value;
            }

        }

    #endregion

    protected void Page_Init(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["Id"] != null && !string.IsNullOrEmpty(Request.QueryString["Id"]))
            {
                Id = Request.QueryString["Id"].ToString();
            }
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
          if (!IsPostBack)
          {
          }
          else
          {
                Control myPlaceHolder = Page.FindControl("form");
                HtmlGenericControl divResultadoTest = (HtmlGenericControl)myPlaceHolder.FindControl("divResultadoTest");
                HtmlGenericControl divResultadoTestHeader = (HtmlGenericControl)myPlaceHolder.FindControl("divResultadoTestHeader");

                divResultadoTest.Visible = false;
                divResultadoTestHeader.Visible = true;
          }

          FillTest();
    }

    protected void FillTest()
    {
        try
        {
            Control myPlaceHolder = Page.FindControl("form");
            HtmlGenericControl h2TituloTest, pPresentaciónTest;

            string cadenaConexion = "Database=qsg265;Data Source=localhost;User Id=dbUser;Password=123;sslMode=none;";
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
                        //TestCode.Text = dr.GetString(2);
                    }

                    //Name
                    if (!dr.IsDBNull(1))
                    {
                        //TestName.Text = dr.GetString(1);
                    }

                    //Title
                    if (!dr.IsDBNull(3))
                    {
                        //TestTitle.Text = dr.GetString(3);
                    }

                    //description
                    if (!dr.IsDBNull(4))
                    {
                        //TestDescription.Text = dr.GetString(4);
                    }

                    //Titulo
                    if (!dr.IsDBNull(13))
                    {
                        //ddlTitulos.SelectedValue = dr.GetString(13);
                    }

                    //Clave
                    if (!dr.IsDBNull(5))
                    {
                        //TestKey.Text = dr.GetString(5);
                    }

                    //Fecha examen
                    if (!dr.IsDBNull(8))
                    {
                        //TestFechaExamen.Text = dr.GetDateTime(8).ToShortDateString();
                    }

                    //Origen
                    if (!dr.IsDBNull(6))
                    {
                        //TestFrom.Text = dr.GetString(6);
                    }

                    //Firma
                    if (!dr.IsDBNull(7))
                    {
                        //TestSign.Text = dr.GetString(7);
                    }

                    //Instrucciones 1
                    if (!dr.IsDBNull(9))
                    {
                        //TestInstructions1.Text = dr.GetString(9);
                    }

                    //Instrucciones 2
                    if (!dr.IsDBNull(10))
                    {
                        //TestInstructions2.Text = dr.GetString(10);
                    }

                    //Cabecera
                    if (!dr.IsDBNull(11))
                    {
                        //TestHeaderNote.Text = dr.GetString(11);
                    }

                    //Pie
                    if (!dr.IsDBNull(12))
                    {
                        //TestFooterNote.Text = dr.GetString(12);
                    }

                    //ACTIVE
                    if (!dr.IsDBNull(14))
                    {
                        //TestActive.Checked = dr.GetBoolean(14);
                    }

                    h2TituloTest = (HtmlGenericControl)myPlaceHolder.FindControl("TituloTest");
                    h2TituloTest.InnerText = dr.GetString(2) + " - " + dr.GetString(1);

                    pPresentaciónTest = (HtmlGenericControl)myPlaceHolder.FindControl("pPresentaciónTest");
                    pPresentaciónTest.InnerHtml = dr.GetString(3);
                    pPresentaciónTest.InnerHtml += "<br /><br />" + dr.GetString(4);
                }
                GetPreguntas();
            }
            cnn.Close();
        }
         catch (Exception ex)
        {
            Session["error"] = ex;
        }
    }

    private DataTable GetPreguntas()
    {
        try
        {
            string cadenaConexion = "Database=qsg265;Data Source=localhost;User Id=dbUser;Password=123;sslMode=none;";
            string Consulta = "SELECT ID, PREGUNTA_ID, TIPO, APARTADO, TEXTO, IMAGEN_URL FROM PREGUNTA WHERE TEST_ID =" + Id + " ORDER BY APARTADO, PREGUNTA_ID ASC";

            MySqlConnection cnn = new MySqlConnection(cadenaConexion);
            MySqlCommand mc = new MySqlCommand(Consulta, cnn);

            cnn.Open();
            MySqlDataReader dr = mc.ExecuteReader();

            dtPreguntas = new DataTable();
            dtPreguntas.Columns.AddRange(new DataColumn[7] { new DataColumn("ID"), new DataColumn("PREGUNTA_ID"), new DataColumn("TIPO"), new DataColumn("APARTADO"), new DataColumn("TEXTO"), new DataColumn("IMAGEN_URL"), new DataColumn("chkSelect") });

            string apartadoUltimo = string.Empty;
            bool crearApartado = false;

            lstPreguntasRespuestas = new List<RadioButtonList>();

            HtmlGenericControl divApartadoReferenceOUT = null;
            int cont = 1;

            if (!dr.IsClosed)
            {
                  while (dr.Read())
                {
                    string urlImage = dr.IsDBNull(5) ? string.Empty : dr.GetString(5);
                    dtPreguntas.Rows.Add(dr.GetInt32(0), dr.GetInt32(1), dr.GetString(2), dr.GetString(3), dr.GetString(4), urlImage, false);
                    string apartadoActual = dr.GetString(3);

                    if (apartadoUltimo == string.Empty)
                    {
                        //Primera vez, abrimos apartado
                        crearApartado = true;
                    }
                    else if (apartadoUltimo == apartadoActual)
                    {
                        //Seguimos con el mismo apartado
                        crearApartado = false;
                    }
                    else 
                    {
                        //Si el ultimo apartado no es igual al actual/nuevo
                        crearApartado = true;
                    }

                    divApartadoReferenceOUT = BindHtmlDataPregunta(dr.GetString(3).ToString(), dr.GetString(4).ToString(), dr.GetInt32(1), crearApartado, urlImage, divApartadoReferenceOUT);

                    //Actualizamos apartado mostrado
                    apartadoUltimo = dr.GetString(3);

                    Session["ContadorPreguntas"] = cont;
                    cont++;
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

    private HtmlGenericControl BindHtmlDataPregunta(string nombreApartado, string tituloPregunta, Int32 idPregunta, bool crearApartado, string urlImage, HtmlGenericControl divApartadoReferenceIN)
    {
            Control myPlaceHolder = Page.FindControl("form");
            HtmlGenericControl h2Apartado= null;
            HtmlGenericControl divApartado = null;

            if(!crearApartado)
            {
                //divApartadoReference = (HtmlControl)FindControl("div" + nombreApartado.Replace(" ", "_"));
                //h2ApartadoReference = (HtmlControl)FindControl("h2" + nombreApartado.Replace(" ", "_"));
            }
            else
            {
                h2Apartado = new HtmlGenericControl("h2");
                h2Apartado.Attributes.Add("class", "accordion-header");
                h2Apartado.Attributes.Add("id", "h2" + nombreApartado.Replace(" ", "_"));
                h2Apartado.InnerText = nombreApartado.Trim();
                h2Apartado.Attributes.Add("runat", "server");

                divApartado = new HtmlGenericControl("div");
                divApartado.Attributes.Add("class", "accordion-content");
                divApartado.Attributes.Add("runat", "server");
                divApartado.Attributes.Add("style", "width: auto !important;");
                divApartado.Attributes.Add("id", "div" + nombreApartado.Replace(" ", "_"));
            }

            HtmlGenericControl pTituloPregunta = new HtmlGenericControl("p");
            pTituloPregunta.Attributes.Add("class", "cat");
            pTituloPregunta.Attributes.Add("runat", "server");
            pTituloPregunta.Attributes.Add("id", "p" + tituloPregunta.Replace(" ", "_"));
            pTituloPregunta.InnerHtml = "<span></span>";
                
            HtmlGenericControl aTituloPregunta = new HtmlGenericControl("a");
            aTituloPregunta.Attributes.Add("title", tituloPregunta.Replace(" ", "_"));
            aTituloPregunta.Attributes.Add("id", "aTituloPregunta" + tituloPregunta.Replace(" ", "_"));
            aTituloPregunta.Attributes.Add("runat", "server");
            aTituloPregunta.InnerText = tituloPregunta;
            pTituloPregunta.Controls.Add(aTituloPregunta);
            
            if(crearApartado)
            {
                divApartado.Controls.Add(pTituloPregunta);
            }
            else
            {
                divApartadoReferenceIN.Controls.Add(pTituloPregunta);
            }

            HtmlGenericControl divRadioButtonsPregunta = new HtmlGenericControl("div");
            divRadioButtonsPregunta.Attributes.Add("style", "margin: 0px 65px 0;");
            divRadioButtonsPregunta.Attributes.Add("runat", "server");

            RadioButtonList rblOpciones = new RadioButtonList();
            rblOpciones.Enabled = true;
            rblOpciones.Visible = true;
            rblOpciones.Attributes.Add("style", "margin-top: 0px;");
            rblOpciones.ID = "rblOpciones_" + nombreApartado + "_" + idPregunta; 

            DataTable dtRespuestas = GetRespuesta(idPregunta);
            if (dtRespuestas != null && dtRespuestas.Rows.Count > 0)
            {
                ListItem lstItem;
                foreach (DataRow dr in dtRespuestas.Rows)
                {
                    lstItem = new ListItem();
                        
                    lstItem.Text = dr[3].ToString();
                    lstItem.Value = dr[4].ToString();
                    /*if (dr[4].ToString() == "1")
                    {
                        lstItem.Selected = true;
                    }*/

                    lstItem.Attributes.Add("style", "padding: 3px; font-size: 15px;");
                    rblOpciones.Items.Add(lstItem);
                }
            }
                
            //Guardamos para posterior validación
            lstPreguntasRespuestas.Add(rblOpciones);
        
            if (urlImage != string.Empty && urlImage != Constants.NoImageParaPreguntaTestOnline)
            {
                HtmlGenericControl tableRadioButtonsPregunta = null;
                tableRadioButtonsPregunta = new HtmlGenericControl("table");
                tableRadioButtonsPregunta.Attributes.Add("runat", "server");

                HtmlGenericControl trRadioButtonsPregunta = new HtmlGenericControl("tr");
                trRadioButtonsPregunta.Attributes.Add("runat", "server");

                HtmlGenericControl tdRadioButtonsPregunta = new HtmlGenericControl("td");
                tdRadioButtonsPregunta.Attributes.Add("style", "width: 75%;");
                tdRadioButtonsPregunta.Attributes.Add("runat", "server");

                tdRadioButtonsPregunta.Controls.Add(rblOpciones);
                trRadioButtonsPregunta.Controls.Add(tdRadioButtonsPregunta);
                
                HtmlGenericControl tdImagenPregunta = new HtmlGenericControl("td");
                tdImagenPregunta.Attributes.Add("runat", "server");

                HtmlGenericControl divLinkImagen = new HtmlGenericControl("div");
                divLinkImagen.Attributes.Add("runat", "server");

                HtmlGenericControl aLinkImagen = new HtmlGenericControl("a");
                aLinkImagen.Attributes.Add("class", "big - link");
                aLinkImagen.Attributes.Add("data-reveal-id", "myModal");
                aLinkImagen.Attributes.Add("data-animation", "fade");
                aLinkImagen.Attributes.Add("style", "margin-top:0; padding-top:0; cursor: pointer;");
                aLinkImagen.Attributes.Add("runat", "server");

                Image imgImagen = new Image();
                imgImagen.Width= Unit.Pixel(150);
                imgImagen.Height = Unit.Pixel(110);
                imgImagen.ImageUrl = urlImage;
                imgImagen.ID = "PreguntaImagenMiniatura" + nombreApartado + "_" + idPregunta;

                FeatureImage.ImageUrl = urlImage;

                aLinkImagen.Controls.Add(imgImagen);

                divLinkImagen.Controls.Add(aLinkImagen);

                tdImagenPregunta.Controls.Add(divLinkImagen);

                trRadioButtonsPregunta.Controls.Add(tdImagenPregunta);

                tableRadioButtonsPregunta.Controls.Add(trRadioButtonsPregunta);
                divRadioButtonsPregunta.Controls.Add(tableRadioButtonsPregunta);
            }
            else
            {
                divRadioButtonsPregunta.Controls.Add(rblOpciones);
            }
           
            //
            if(crearApartado)
            {
                divApartado.Controls.Add(divRadioButtonsPregunta);
            }
            else
            {
                divApartadoReferenceIN.Controls.Add(divRadioButtonsPregunta);
            }
        
            if(crearApartado)
            {
                HtmlControl divContaiunerPpal = (HtmlControl)myPlaceHolder.FindControl("accordion_container");
                divContaiunerPpal.Controls.Add(h2Apartado);
                divContaiunerPpal.Controls.Add(divApartado);
            }

            if(crearApartado)
            {
                return divApartado;
            }
            else
            {
                return divApartadoReferenceIN;
            }
     }

    private DataTable GetRespuesta(int preguntaID)
    {
        try
        {
            DataTable dtRespuesta = new DataTable();
            dtRespuesta.Columns.AddRange(new DataColumn[5] { new DataColumn("ID"), new DataColumn("PREGUNTA_ID"), new DataColumn("RESPUESTA_ID"), new DataColumn("TEXTO"), new DataColumn("SOLUCION_CORRECTA") });

                string cadenaConexion = "Database=qsg265;Data Source=localhost;User Id=dbUser;Password=123;sslMode=none;";
                string Consulta = "SELECT ID, PREGUNTA_ID, RESPUESTA_ID, TEXTO, SOLUCION_CORRECTA FROM RESPUESTA WHERE PREGUNTA_ID =" + preguntaID + " ORDER BY RESPUESTA_ID ASC ";

                MySqlConnection cnn = new MySqlConnection(cadenaConexion);
                MySqlCommand mc = new MySqlCommand(Consulta, cnn);

                cnn.Open();
                MySqlDataReader dr = mc.ExecuteReader();

                if (!dr.IsClosed)
                {
                    while (dr.Read())
                    {
                        dtRespuesta.Rows.Add(dr.GetInt32(0), dr.GetInt32(1), dr.GetInt32(2), dr.GetString(3), ((dr.IsDBNull(4)) ? 0 : dr.GetInt32(4)));
                    }
                }
                cnn.Close();
          
            return dtRespuesta;
        }
        catch (Exception ex)
        {
            Session["error"] = ex;
            //this.SetLOG("ERROR", "Deleting_Convocation", "EditExam.aspx", "Test", "GetPreguntas()", ex.Message, DateTime.Now, 1);
            throw ex;
        }
    }

    protected void btnValidarRespuestas_Click(object sender, EventArgs e)
    {
        try
        {
            int contAcertadas = 0;

            foreach(RadioButtonList rbtn in lstPreguntasRespuestas)
            {
                foreach(ListItem lstItem in rbtn.Items)
                {
                    if (lstItem.Selected && lstItem.Value == "1")
                    {
                        contAcertadas++;
                        lstItem.Attributes.Add("style", "border: solid 2px #2EFE2E;");
                    }
                    else if (lstItem.Selected && lstItem.Value == "0")
                    {
                        lstItem.Attributes.Add("style", "border: solid 2px red;");
                    }
                    else if (!lstItem.Selected && lstItem.Value == "1")
                    {
                        lstItem.Attributes.Add("style", "border: solid 2px blue;");
                    }
                }

                Control myPlaceHolder = Page.FindControl("form");
                HtmlGenericControl divResultadoTest = (HtmlGenericControl)myPlaceHolder.FindControl("divResultadoTest");
                HtmlGenericControl divResultadoTestHeader = (HtmlGenericControl)myPlaceHolder.FindControl("divResultadoTestHeader");

                divResultadoTest.InnerHtml = string.Empty;
                //divResultadoTest.InnerHtml =  "<p style='color:grey;'><b>RESULTADO DEL TEST</b></p>";
                divResultadoTest.InnerHtml += "<p style='color:blue;'><b>Nª PREGUNTAS: " + Session["ContadorPreguntas"].ToString() + "</b></p>";
                divResultadoTest.InnerHtml += "<p style='color:#01DF01;'><b>Nº ACIERTOS: " + contAcertadas.ToString() + "</b></p>";
                divResultadoTest.InnerHtml += "<p style='color:red;'><b>Nº FALLOS: " + (((Int32)Session["ContadorPreguntas"]) - contAcertadas).ToString() + "</b></p>";

                divResultadoTest.Visible = true;
                divResultadoTestHeader.Visible = true;
                /*if(rbtn.SelectedValue == "1")
                {
                    rbtn.BorderColor = System.Drawing.Color.Green;

                }
                else
                {
                    rbtn.BorderColor = System.Drawing.Color.Red;
                }*/
            }
        }
         catch (Exception ex)
        {
            Session["error"] = ex;
            //this.SetLOG("ERROR", "Deleting_Convocation", "EditExam.aspx", "Test", "GetPreguntas()", ex.Message, DateTime.Now, 1);
            throw ex;
        }
    }
   
    protected void btnLimpiarTest1_Click(object sender, EventArgs e)
    {
        Response.Redirect("TestOnline.aspx?" + this.ClientQueryString);
    }
    
}
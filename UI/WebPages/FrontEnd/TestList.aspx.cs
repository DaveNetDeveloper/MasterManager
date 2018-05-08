using System; 
using System.Data; 
using MySql.Data.MySqlClient;
using System.Web.UI.HtmlControls;
using System.Web.UI;

public partial class TestList : BasePage
{
    public DataTable dtTests
    {
        get
        {
            return Session["dtTests"] as DataTable;
        }
        set
        {
            Session["dtTests"] = (DataTable)value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
          if (!IsPostBack)
          {
              CargarTestsFromDB(); 
          }
    }
 
    protected void CargarTestsFromDB()
    {
        try
        { 
            string cadenaConexion = "Database=qsg265;Data Source=localhost;User Id=dbUser;Password=123;sslMode=none;"; 
            string Consulta = " SELECT ID, NOMBRE, CODIGO, TITULO, DESCRIPCION, CLAVE, FECHA, PRODUCT_ID, CASE WHEN ACTIVE = 1 THEN 'Si' ELSE 'No' END AS ACTIVE, CREATED FROM TEST ORDER BY PRODUCT_ID, ID ASC";
            
            MySqlConnection cnn = new MySqlConnection(cadenaConexion);
            MySqlCommand mc = new MySqlCommand(Consulta, cnn);

            cnn.Open();
            MySqlDataReader dr = mc.ExecuteReader();

            dtTests = new DataTable();
            dtTests.Columns.AddRange(new DataColumn[10] { new DataColumn("ID"), new DataColumn("NAME"), new DataColumn("CODIGO"), new DataColumn("TITULO"), new DataColumn("DESCRIPCION"), new DataColumn("CLAVE"), new DataColumn("FECHA"), new DataColumn("PRODUCT_ID"), new DataColumn("ACTIVE"), new DataColumn("CREATED") });
             
            string productName = string.Empty;

            if (!dr.IsClosed)
            {
                while (dr.Read())
                {
                    dtTests.Rows.Add(dr.GetInt32(0), dr.GetString(1), dr.GetString(2), dr.GetString(3), dr.GetString(4), dr.GetString(5), dr.GetDateTime(6), dr.GetString(7), dr.GetString(8), dr.GetDateTime(9));

                    switch(dr.GetString(7))
                    {
                        case "1":
                            productName = "PNB";
                        break;
                            case "2":
                            productName = "PER";
                        break;
                        case "3":
                            productName = "PY";
                            break;

                        case "4":
                            productName = "CY";
                            break;

                        case "5":
                            productName = "LNA";
                            break;
                    } 
                    BindHTMLListForTest(dr.GetInt32(0), dr.GetString(1), dr.GetString(2), dr.GetString(3), dr.GetString(4), productName);
                }
            }
            cnn.Close();
        }
        catch (Exception ex)
        {
            Session["error"] = ex;
        }
    }

    private void BindHTMLListForTest(Int32 idTest, string name, string codigo, string titulo, string descripcion, string productName)
    {
        Control myPlaceHolder = Page.FindControl("form");

        HtmlControl divProductContent = (HtmlControl)myPlaceHolder.FindControl(productName + "Content");
        
        HtmlGenericControl pTituloProducto = new HtmlGenericControl("p");
        pTituloProducto.Attributes.Add("class", "cat");
        pTituloProducto.Attributes.Add("runat", "server");
        pTituloProducto.Attributes.Add("id", productName + "Content");

        HtmlGenericControl aTituloTest = new HtmlGenericControl("a");
        aTituloTest.Attributes.Add("title", titulo);
        aTituloTest.Attributes.Add("id", productName + "_a" + idTest.ToString());
        aTituloTest.Attributes.Add("href", "TestOnline.aspx?Id=" + idTest.ToString());
        aTituloTest.Attributes.Add("runat", "server");
        aTituloTest.InnerText = codigo + " - " + name;
        pTituloProducto.Controls.Add(aTituloTest);

        HtmlGenericControl aTituloTest2 = new HtmlGenericControl("a");
        aTituloTest2.Attributes.Add("title", titulo);
        aTituloTest2.Attributes.Add("id", productName + "_a_2");
        aTituloTest2.Attributes.Add("href", "TestOnline.aspx?Id=2");
        aTituloTest2.Attributes.Add("runat", "server");
        aTituloTest2.InnerText = "EX002" + " - " + "Test 2";
        pTituloProducto.Controls.Add(aTituloTest2);

        divProductContent.Controls.Add(pTituloProducto); 
    } 
}
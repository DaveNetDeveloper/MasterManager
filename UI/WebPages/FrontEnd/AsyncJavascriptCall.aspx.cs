using System;
using BussinesTypedObject;

public partial class AsyncJavascriptCall : BasePage
{
    protected void Page_Init(object sender, EventArgs e)
    {
        if (!IsPostBack) { 
            BussinesObject = BussinesTypes.BussinesObjectType.Documento;
        }
    } 
}
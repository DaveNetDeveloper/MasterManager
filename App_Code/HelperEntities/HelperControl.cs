using System.Collections.Generic;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

/// <summary>
/// Descripción breve de HelperControl
/// </summary>
public static class HelperControl
{
    private static Color invalidDataColor = Color.Red;
    public enum ControlType {
        TextBox,
        HtmlInputCheckBox,
        CheckBox,
        HtmlSelect,
        HtmlTextArea
    }
    public static void SetControlAsInvalid(TextBox control, ref bool validationResult)
    {
        validationResult = false;
        control.BorderColor = invalidDataColor;
        control.BorderWidth = new Unit(1);
    }
    public static void ResetControlValues(List<Control> ControlList)
    {
        foreach (Control c in ControlList) {
            switch (c.GetType().Name) {
                case "TextBox":
                    ((TextBox)c).Text = string.Empty;
                    //if (ContainsDateTimeData(((TextBox)c).Text)) ((TextBox)c).Text = dateTimeDefaultMask;
                    break;

                case "CheckBox":
                    ((CheckBox)c).Checked = false;
                    break;

                case "HtmlInputCheckBox":
                    ((HtmlInputCheckBox)c).Checked = false;
                    break;

                case "HtmlTextArea":
                    ((HtmlTextArea)c).Value = string.Empty;
                    break;
            }
        }
    }
    public static string GetSimplyControlName(string controlId)
    {
        return controlId.Substring(controlId.LastIndexOf("_") + 1, controlId.Length - controlId.LastIndexOf("_") - 1);
    }
}
using System; 
using System.Globalization; 

/// <summary>
/// Descripción breve de HelperDataTypesConversion
/// </summary>
public static class HelperDataTypesConversion
{ 
    public static DateTime GetDateTimeFromText(string dateTime, string inputDateTimeFormat, CultureInfo culture)
    {
        try
        {
            var arr = dateTime.Split('/');
            DateTime? dt = null;

            switch (inputDateTimeFormat)
            {
                case Constants.inputDateTimeFormat_ddmmaaaa:
                    // dd, mm, aaaa<--> aaaa, mm, dd  
                    dt = new DateTime(int.Parse(arr[2].ToString().Substring(0, 4).ToString()), int.Parse(arr[1].ToString()), int.Parse(arr[0].ToString()));
                    break;

                case Constants.inputDateTimeFormat_mmddaaaa:
                    // mm, dd, aaaa<--> aaaa, mm, dd  
                    dt = new DateTime(int.Parse(arr[2].ToString().Substring(0, 4).ToString()), int.Parse(arr[0].ToString()), int.Parse(arr[1].ToString()));
                    break;
            }
            return dt != null ? dt.Value : new DateTime();
        }
        catch (Exception)
        {
            //Session["error"] = ex;
            //return new DateTime(dateTime);
            return new DateTime();
        }
    } 
}
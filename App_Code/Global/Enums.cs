/// <summary>
/// Summary description for Enums
/// </summary>
public class Enums
{  
    public enum TipoRecurso
    {
        Menu,
        Inicio,
        Luxsuy,
        Contacto,
        ContactoLocalizacion,
        Especialidades,
        CartaMasajes
    }
     
    public enum AppConfiguration
    {
        settings_DefaultLanguag,
        mail_Host,
        mail_Port,
        mail_To,
        mail_From,
        mail_Subject,
        mail_Body,
        mail_user,
        mail_password
    }

    public enum LogType
    {
        Visitor,
        Contact,
        Error
    }

    public enum PageName
    {
        Page1,
        Page2,
        Page3,
        Page4 
    }

    public enum SubjectContact
    {
        NONE = 0,
        SUBJECT1 = 1,
        SUBJECT2 = 2,
        SUBJECT3 = 3,
        SUBJECT4 = 4,
        SUBJECT5 = 5,
        SUBJECT6 = 6
    }
}
﻿ using System.Web.Configuration;

/// <summary>
/// Summary description for Settings
/// </summary>
internal static class Settings
{
    public enum AppSettings
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

    //Language Settings
    private static string _defaultLanguage = WebConfigurationManager.AppSettings["settings_DefaultLanguage"];
    public static string DefaultLanguage
    {
        get
        {
            return _defaultLanguage;
        }
        set
        {
            _defaultLanguage = value;
        }
    }

    //File Log Settings 
    private static string _logXmlVisitorFileName = WebConfigurationManager.AppSettings["settings_XmlVisitorLogFileName"];
    public static string LogXmlVisitorFileName
    {
        get
        {
            return _logXmlVisitorFileName;
        }
    }

    private static string _logXmlContactFileName = WebConfigurationManager.AppSettings["settings_XmlContactLogFileName"];
    public static string LogXmlContactFileName
    {
        get
        {
            return _logXmlContactFileName;
        }
    }

    //private static string _logTextFileName = WebConfigurationManager.AppSettings["settings_TextLogFileName"];
    //public static string LogTextFileName
    //{
    //    get
    //    {
    //        return _logTextFileName;
    //    }
    //}

    private static string _dataDirectory = WebConfigurationManager.AppSettings["settings_DataDirectory"];
    public static string DataDirectory
    {
        get
        {
            return _dataDirectory;
        }
    }

    private static string _filePathDelimiter = @"\";
    public static string FilePathDelimiter
    {
        get
        {
            return _filePathDelimiter;
        } 
    }

    //URL Redirect Settings
    private static string _rootStartPath = @"~/";
    public static string RootStartPath
    {
        get
        {
            return _rootStartPath;
        }
    }
    
    private static string _paramSubjectPath = @"S";
    public static string ParamNameQueryStringSubject
    {
        get
        {
            return _paramSubjectPath;
        }
    }

    //Mail Settings
    private static string _mailFrom = WebConfigurationManager.AppSettings["mail_From"];
    public static string MailFrom
    {
        get
        {
            return _mailFrom;
        }
    }

    private static string _mailTo = WebConfigurationManager.AppSettings["mail_To"];
    public static string MailTo
    {
        get
        {
            return _mailTo;
        }
    }

    private static string _mailHost = WebConfigurationManager.AppSettings["mail_Host"];
    public static string MailHost
    {
        get
        {
            return _mailHost;
        }
    }

    private static string _mailPort = WebConfigurationManager.AppSettings["mail_Port"];
    public static string MailPort
    {
        get
        {
            return _mailPort;
        }
    }

    private static string _mailUser = WebConfigurationManager.AppSettings["mail_User"];
    public static string MailUser
    {
        get
        {
            return _mailUser;
        }
    }

    private static string _mailPassword = WebConfigurationManager.AppSettings["mail_Password"];
    public static string MailPassword
    {
        get
        {
            return _mailPassword;
        }
    }

    private static string _mailEnableSsl = WebConfigurationManager.AppSettings["mail_EnableSsl"];
    public static string MailEnableSsl
    {
        get
        {
            return _mailEnableSsl;
        }
    } 

}
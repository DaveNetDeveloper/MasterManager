using System; 
using System.Net.Mail;
using System.Net;  

/// <summary>
/// Descripción breve de HelperMail
/// </summary>
public static class HelperMail
{
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

    public static bool SendMail(ModelUserContact datosContacto)
    {
        try
        {
            MailMessage mailMessage = new MailMessage(HelperEncoder.Base64Decode(Settings.MailFrom), HelperEncoder.Base64Decode(Settings.MailTo))
            {
                IsBodyHtml = true,
                //mailMessage.Subject = Resources.resource.Mail_Subject; 
                Body = GetUpdatedMailContent(datosContacto)
            };

            SmtpClient smtpClient = new SmtpClient(HelperEncoder.Base64Decode(Settings.MailHost), int.Parse(HelperEncoder.Base64Decode(Settings.MailPort)));
            //smtpClient.EnableSsl = bool.Parse(Settings.MailEnableSsl);

            var credentials = new NetworkCredential(HelperEncoder.Base64Decode(Settings.MailUser), HelperEncoder.Base64Decode(Settings.MailPassword));

            smtpClient.Credentials = credentials;
            smtpClient.Send(mailMessage);

            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    private static string GetUpdatedMailContent(ModelUserContact datosContacto)
    {
        try
        {
            //string mailBody = Resources.resource.Mail_Body;

            string mailBody = "<br/> <b>Nombre completo: </b>" + datosContacto.NombreCompleto + "<br />";
            mailBody += "<b>Correo electrónico: </b>" + datosContacto.Email + "<br />";
            mailBody += "<b>Teléfono: </b>" + datosContacto.Telefono + "<br />";
            mailBody += "<b>Asunto del mensaje: </b>" + datosContacto.Asunto + "<br />";
            mailBody += "<b>Mensaje: </b>" + datosContacto.Mensaje + "<br />";
            mailBody += "<br />";
            mailBody += "Atentamente, " + "<br />";
            //mailBody += "Corporation</div>";  
            mailBody += "<table style = 'float: right; width: 100%' id = 'tLogo'> <tr><td style ='float:right;'><a target='_blank' href='http://www.com'><img src='http://www' width='135px' height='85px' /></a></td></tr></table>";
            return mailBody;
        }
        catch (Exception)
        {
            throw;
        }
    }
}
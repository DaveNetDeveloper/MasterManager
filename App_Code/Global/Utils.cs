﻿using System;
using System.Web;
using System.Net.Mail;
using System.Net;
using System.Xml.Linq;
using System.Text;
using System.IO;

public static class Utils
{
    #region "Public"

    public static bool SendMail(ModelContacto datosContacto)
    {
        try
        {
            MailMessage mailMessage = new MailMessage(Base64Decode(Settings.MailFrom), Base64Decode(Settings.MailTo));
            mailMessage.IsBodyHtml = true;

            //mailMessage.Subject = Resources.resource.Mail_Subject; 
            mailMessage.Body = GetUpdatedMailContent(datosContacto);

            SmtpClient smtpClient = new SmtpClient(Base64Decode(Settings.MailHost), int.Parse(Base64Decode(Settings.MailPort)));
            //smtpClient.EnableSsl = bool.Parse(Settings.MailEnableSsl);

            var credentials = new NetworkCredential(Base64Decode(Settings.MailUser), Base64Decode(Settings.MailPassword));

            smtpClient.Credentials = credentials;
            smtpClient.Send(mailMessage); 

            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public static bool IsValidFormData(ModelContacto datosContacto)
    {
        try
        {
            if(datosContacto != null)
            {  
                if(string.IsNullOrEmpty(datosContacto.Email))
                {
                    return false;
                }
                else if (string.IsNullOrEmpty(datosContacto.NombreCompleto))
                {
                    return false;
                }
                else if (string.IsNullOrEmpty(datosContacto.Asunto))
                {
                    return false;
                }
                else if (string.IsNullOrEmpty(datosContacto.Mensaje))
                {
                    return false;
                }
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception ex)
        {
            return false;
        }

    }

   
     
    public static void LogFile(Enums.LogType logType, object entity)
    {
        try
        {
            var logFilePath = HttpContext.Current.Server.MapPath(Settings.DataDirectory) + Settings.FilePathDelimiter;

            switch (logType)
            {
                case Enums.LogType.Visitor:

                    ModelArea visitante = (ModelArea)entity;
                    WriteVisitorXmlDocument(logFilePath + Base64Decode(Settings.LogXmlVisitorFileName), visitante);
                    break;

                case Enums.LogType.Contact:

                    ModelContacto contacto = (ModelContacto)entity;
                    WriteContactXmlDocument(logFilePath + Base64Decode(Settings.LogXmlContactFileName), contacto);
                    break;
            }

            //TEXT FILE
            //WriteTextDocument(logFilePath + Settings.LogTextFileName, visitante);
        }
        catch (Exception ex)
        {
            //Log Error File using ex Exception 
        }
    }

    public static string GetDefautLanguage()
    {
        return Settings.DefaultLanguage;
    }

   
    #endregion

    #region "Private"

    private static string GetUpdatedMailContent(ModelContacto datosContacto)
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
            //mailBody += "Luxsuy</div>";  
            mailBody += "<table style = 'float: right; width: 100%' id = 'tLogo'> <tr><td style ='float:right;'><a target='_blank' href='http://www.luxsuy.com'><img src='http://www.luxsuy.com/Luxsuy/images/LogoMail.png' width='135px' height='85px' /></a></td></tr></table>";
            return mailBody;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private static string Base64Encode(string textToEndode)
    {
        var plainTextBytes = Encoding.UTF8.GetBytes(textToEndode);
        return Convert.ToBase64String(plainTextBytes);
    }

    private static string Base64Decode(string base64EncodedData)
    {
        try
        { 
            var base64EncodedBytes = Convert.FromBase64String(base64EncodedData);
            return Encoding.UTF8.GetString(base64EncodedBytes);
        }
        catch (Exception ex)
        { 
            return null;
        }
    }

    private static void WriteTextDocument(string filename, ModelArea visitante = null)
    {
        StreamWriter log;
        if (!File.Exists(filename))
        {
            log = new StreamWriter(filename);
        }
        else
        {
            log = File.AppendText(filename);
        }

        log.WriteLine("-----------------------------------------------------------------------------------------------");
        log.WriteLine("Data Time: " + DateTime.Now);
        //log.WriteLine("Log Type: " + logType.ToString());

        if (null != visitante)
        {
            log.WriteLine("IP: " + visitante.IP);
            log.WriteLine("Region: " + visitante.Region);
            log.WriteLine("Pais: " + visitante.Pais);
            log.WriteLine("CodigoZIP: " + visitante.CodigoZIP);
            log.WriteLine("CodigoPais: " + visitante.CodigoPais);
            log.WriteLine("Latitud: " + visitante.Latitud);
            log.WriteLine("Longitud: " + visitante.Longitud);
            log.WriteLine("ZonaHoraria: " + visitante.ZonaHoraria);
            log.WriteLine("Ciudad: " + visitante.Ciudad);

            log.WriteLine("NavegadorCookkies: " + visitante.NavegadorCookkies);
            log.WriteLine("NavegadorLenguaje: " + visitante.NavegadorLenguaje);
            log.WriteLine("NavegadorPlataforma: " + visitante.NavegadorPlataforma);
            log.WriteLine("NavegadorProducto: " + visitante.NavegadorProducto);
            log.WriteLine("NavegadorAgente: " + visitante.NavegadorAgente);
            log.WriteLine("NavegadorCompañia: " + visitante.NavegadorCompañia);
        }
        log.Close();
    }

    private static void WriteVisitorXmlDocument(string filename, ModelArea visitante)
    {
        try
        { 
            XDocument doc = XDocument.Load(filename);
            XElement root = new XElement("VisitorEntry");
            root.Add(new XElement("DateTime", DateTime.Now.ToString()));

            if (null != visitante)
            {
                root.Add(new XElement("SessionID", visitante.SessionID));
                root.Add(new XElement("SessionStartTicks", visitante.SessionStartTicks));

                root.Add(new XElement("IP", visitante.IP));
                root.Add(new XElement("Region", visitante.Region));
                root.Add(new XElement("Pais", visitante.Pais));
                root.Add(new XElement("CodigoZIP", visitante.CodigoZIP));
                root.Add(new XElement("CodigoPais", visitante.CodigoPais));
                root.Add(new XElement("Latitud", visitante.Latitud));
                root.Add(new XElement("Longitud", visitante.Longitud));
                root.Add(new XElement("ZonaHoraria", visitante.ZonaHoraria));
                root.Add(new XElement("Ciudad", visitante.Ciudad));

                root.Add(new XElement("NavegadorCookkies", visitante.NavegadorCookkies));
                root.Add(new XElement("NavegadorLenguaje", visitante.NavegadorLenguaje));
                root.Add(new XElement("NavegadorPlataforma", visitante.NavegadorPlataforma));
                root.Add(new XElement("NavegadorProducto", visitante.NavegadorProducto));
                root.Add(new XElement("NavegadorAgente", visitante.NavegadorAgente));
                root.Add(new XElement("NavegadorCompañia", visitante.NavegadorCompañia));
            }
            doc.Element("VisitorEntries").Add(root);
            doc.Save(filename);
        }
        catch (Exception ex)
        {
            //Log Error File using ex Exception 
        }
    }

    private static void WriteContactXmlDocument(string filename, ModelContacto contacto)
    {
        try
        { 
            XDocument doc = XDocument.Load(filename);
            XElement root = new XElement("ContactEntry");
            root.Add(new XElement("DateTime", DateTime.Now.ToString()));

            if (null != contacto)
            {
                root.Add(new XElement("NombreCompleto", contacto.NombreCompleto));
                root.Add(new XElement("Email", contacto.Email));
                root.Add(new XElement("Telefono", contacto.Telefono));
                root.Add(new XElement("Asunto", contacto.Asunto));
                root.Add(new XElement("Mensaje", contacto.Mensaje));
            }
            doc.Element("ContactEntries").Add(root);
            doc.Save(filename);
        }
        catch (Exception ex)
        {
            //Log Error File using ex Exception 
        } 
    }

    //private static string GetIPAddress()
    //{
    //    //try
    //    //{
    //        var address = String.Empty;
    //        WebRequest request = WebRequest.Create("http://checkip.dyndns.org/");
    //        using (WebResponse response = request.GetResponse())
    //        using (StreamReader stream = new StreamReader(response.GetResponseStream()))
    //        {
    //            address = stream.ReadToEnd();
    //        }

        //        int first = address.IndexOf("Address: ") + 9;
        //        int last = address.LastIndexOf("</body>");
        //        return address.Substring(first, last - first);

        //        /*System.Web.HttpContext context = System.Web.HttpContext.Current;
        //        string ipAddress = context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

        //        if (!string.IsNullOrEmpty(ipAddress))
        //        {
        //            string[] addresses = ipAddress.Split(',');
        //            if (addresses.Length != 0)
        //            {
        //                var adrees = addresses[0];
        //            }
        //        } 

        //        var addr = context.Request.ServerVariables["REMOTE_ADDR"]; */ 
        //    //}
        //    //catch (Exception ex)
        //    //{
        //    //    //Log Error File using ex Exception
        //    //    return null;
        //    //} 
        //}

        //private static XmlTextReader GetLocation(string ipaddress)
        //{
        //    // Register at Address = {http://api.ipinfodb.com/v3/ip-city/?key=Your Api key Here&ip=37.133.25.245&format=xml} for a free key and put it here
        //    string myKey = "7b42d0e4d71fd72e97e100fe3938bda8278e7e1e9b892879d52e91623e571f5e";
        //    WebRequest rssReq = WebRequest.Create("http://api.ipinfodb.com/v3/ip-city/?key=" + myKey + "&ip=" + ipaddress + "&format=xml");
        //    WebProxy px = new WebProxy("http://api.ipinfodb.com/v3/ip-city/?key=" + myKey + "&ip=" + ipaddress + "&format=xml", true);
        //    rssReq.Proxy = px;
        //    rssReq.Timeout = 10000;
        //    try
        //    {
        //        WebResponse rep = rssReq.GetResponse();
        //        XmlTextReader xtr = new XmlTextReader(rep.GetResponseStream());
        //        return xtr;
        //    }
        //    catch
        //    {
        //        return null;
        //    }
        //} 

    #endregion
}
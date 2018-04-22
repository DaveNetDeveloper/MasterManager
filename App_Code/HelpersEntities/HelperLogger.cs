using System;
using System.Web; 
using System.Xml.Linq; 
using System.IO; 

/// <summary>
/// Descripción breve de HelperLogger
/// </summary>
public static class HelperLogger
{
    public static void LogFile(Enums.LogType logType, object entity)
    {
        try
        {
            var logFilePath = HttpContext.Current.Server.MapPath(Settings.DataDirectory) + Settings.FilePathDelimiter;

            switch (logType)
            {
                case Enums.LogType.Visitor:

                    ModelArea visitante = (ModelArea)entity;
                    WriteVisitorXmlDocument(logFilePath + HelperEncoder.Base64Decode(Settings.LogXmlVisitorFileName), visitante);
                    break;

                case Enums.LogType.Contact:

                    ModelContacto contacto = (ModelContacto)entity;
                    WriteContactXmlDocument(logFilePath + HelperEncoder.Base64Decode(Settings.LogXmlContactFileName), contacto);
                    break;
            }

            //TEXT FILE
            //WriteTextDocument(logFilePath + Settings.LogTextFileName, visitante);
        }
        catch (Exception)
        {
            //Log Error File using ex Exception 
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
        catch (Exception)
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
        catch (Exception)
        {
            //Log Error File using ex Exception 
        }
    } 
}
<%@ Application Language="C#" %>

<%@ Import Namespace="System.Web.Routing" %>

<script runat="server">

    void Application_Start(object sender, EventArgs e)
    {
        RegisterRoute(RouteTable.Routes);
    }

    void RegisterRoute(RouteCollection routes)
    {
        //routes.Add("LuxsuyRoute", new Route("Inicio", new LuxsuyRouteHandler()));
        //routes.Add("CartaRoute", new Route("MassagesLetter", new CartaRouteHandler())); 
        //routes.Add("EspecialidadesRoute", new Route("OurSpecialites", new EspecialidadesRouteHandler()));  
        //routes.Add("ContactRoute", new Route("Contact", new ContactoRouteHandler())); 
        //routes.Add("TrabajarRoute", new Route("ContactTrabajar", new TrabajarRouteHandler())); 
        //routes.Add("LocalizacionRoute", new Route("ContactLocation", new LocalizacionRouteHandler()));   
    }

    void Application_End(object sender, EventArgs e)
    {
        //  Código que se ejecuta al cerrarse la aplicación

    }

    void Application_Error(object sender, EventArgs e)
    {
        // Código que se ejecuta cuando se produce un error sin procesar

    }

    void Session_Start(object sender, EventArgs e)
    {
        // Código que se ejecuta al iniciarse una nueva sesión

    }

    void Session_End(object sender, EventArgs e)
    {
        // Código que se ejecuta cuando finaliza una sesión. 
        // Nota: el evento Session_End se produce solamente con el modo sessionstate
        // se establece como InProc en el archivo Web.config. Si el modo de sesión se establece como StateServer
        // o SQLServer, el evento no se produce.

    }

</script>

<%@ Application Language="C#" %>
<%@ Import Namespace="Website" %>
<%@ Import Namespace="System.Web.Optimization" %>
<%@ Import Namespace="System.Web.Routing" %>
<%@ Import Namespace="Chinook.System.BLL.Security" %>

<script runat="server">

    void Application_Start(object sender, EventArgs e)
    {
        RouteConfig.RegisterRoutes(RouteTable.Routes);
        BundleConfig.RegisterBundles(BundleTable.Bundles);

        //create the startup default roles
        //Create the webmaster user
        //Create the employee user accounts
        //when the application starts up

        var rolemgr = new RoleManager();
        rolemgr.AddDefaultRoles();
        var usrmgr = new UserManager();
        usrmgr.AddWebMaster();
    }

</script>

# BackEnd-Garage-Mechanic-Management_WebApi_Rest-Csharp
**************************************
this is back end project (WebApi REST+.NET)

Open The Projet in Visuel Studio 2019

//Go to Web.config File and change this line , add you Database chaine

    <connectionStrings>
        <add name="master" connectionString="Data Source=.;Initial Catalog=master;Integrated Security=true" providerName="System.Data.SqlClient"/>
    </connectionStrings>

# App_Start>WebApiConfig.cs
************************
 // Configuration et services API Web

            // Itinéraires de l'API Web
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            //JSON
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
            config.EnableCors(new EnableCorsAttribute("*", "*", "*"));
            
// The general information relating to an assembly depends on
// the next set of attributes. Change the values of these attributes to modify the information
// associated with an assembly.
        [assembly: AssemblyTitle ("Mechanical_Garage_Management")]
        [assembly: AssemblyDescription ("")]
        [assembly: AssemblyConfiguration ("")]
        [assembly: AssemblyCompany ("")]
        [assembly: AssemblyProduct ("Mechanical_Garage_Management")]
        [assembly: AssemblyCopyright ("Copyright © 2020")]
        [assembly: AssemblyTrademark ("")]
        [assembly: AssemblyCulture ("")]

// Assigning the value false to ComVisible makes the types invisible in this assembly
// to COM components. If you need to access a type in this assembly from
// COM, set the ComVisible attribute to true on this type.
        [assembly: ComVisible (false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
        [assembly: Guid ("1c606775-52d5-45ab-8405-3eb71ea84db5")]

// The version information for an assembly consists of the following four values:
//
// Main version
// Minor version
// Build number
// Revision
//
// You can specify all the values ​​or you can define by default the values ​​Revision and Version number
// using ’*’, as shown below:
        [assembly: AssemblyVersion ("1.0.0.0")]
        [assembly: AssemblyFileVersion ("1.0.0.0")]

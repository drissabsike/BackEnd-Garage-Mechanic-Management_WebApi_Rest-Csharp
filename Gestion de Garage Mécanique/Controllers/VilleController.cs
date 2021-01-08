using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Gestion_de_Garage_Mécanique.Models;

namespace Gestion_de_Garage_Mécanique.Controllers
{
    public class VilleController : ApiController
    {

        //methode fetch data from sql server "select juste les villes"
        [Route("api/Ville/GetCity")]
        [HttpGet]
        public HttpResponseMessage GetCity()
        {
            string query = @"select city from dbo.Ville";
            DataTable table = new DataTable();
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["master"].ConnectionString))
            using (var cmd = new SqlCommand(query, con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);
            }
            return Request.CreateResponse(HttpStatusCode.OK, table);
        }

    }
}

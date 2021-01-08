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
    public class DomaineController : ApiController
    {

        //methode fetch data from sql server "select juste les Domaines"
        [Route("api/Domaine/GetDom")]
        [HttpGet]
        public HttpResponseMessage GetDom()
        {
            string query = @"select domaine from dbo.Domaine";
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

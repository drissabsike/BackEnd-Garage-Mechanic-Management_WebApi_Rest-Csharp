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
    public class MecanicienController : ApiController
    {
        //select all rows from Mecanicien table
        //methode fetch data from sql server
        public HttpResponseMessage Get()
        {
            string query = @"
                      select id,nom,prenom,cin,telephone,domaine,niveau 
                      from dbo.Mecanicien 
                      ";
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

        //methode fetch data from sql server by id
        public HttpResponseMessage GetById(int id)
        {
            string query = @"
                      select id,nom,prenom,cin,telephone,domaine,niveau 
                      from dbo.Mecanicien where id =" + id + @"
                      ";
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


        ///api/Mecanicien insert
        public string Post(Mecanicien mecanicien)
        {
            if (mecanicien.nom.Length == 0)
            {
                return "Verifier les champes";
            }
            else
                try
            {
                string query = @"
            insert into dbo.Mecanicien(nom,prenom,cin,telephone,domaine,niveau) values
                    ('" + mecanicien.nom + @"','" + mecanicien.prenom + @"','" + mecanicien.cin + @"',
                    " + mecanicien.telephone + @",'" + mecanicien.domaine + @"','" + mecanicien.niveau + @"')
                        ";
                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["master"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }
                return "Added Successfully !!";
            }
            catch (Exception e)
            {
                return "erreur in Post Code" + e.Message;
            }
        }


        ///api/Mecanicien update
        public string Put(Mecanicien mecanicien)
        {
            try
            {
                string query = @"
            update dbo.Mecanicien set nom='" + mecanicien.nom + @"',prenom='" + mecanicien.prenom + @"',
            cin='" + mecanicien.cin + @"',telephone=" + mecanicien.telephone + @",
            domaine='" + mecanicien.domaine + @"',niveau='" + mecanicien.niveau + @"'
                        where id =" + mecanicien.id + @"  ";
                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["master"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }
                return "update Successfully !!";
            }
            catch (Exception e)
            {
                return "erreur in update Code" + e.Message;
            }
        }


        //api/Mecanicien delete
        public string Delete(int id)
        {
            try
            {
                string query = @"
            delete from dbo.Mecanicien where id =" + id + @"  ";
                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["master"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }
                return "delete Successfully !!";
            }
            catch (Exception e)
            {
                return "erreur in delete Code" + e.Message;
            }
        }


        //select full name from Mecanicien table
        [Route("api/Mecanicien/GetFullNameMec")]
        [HttpGet]
        public HttpResponseMessage GetFullNameMec()
        {
            string query = @"select nom from dbo.Mecanicien";
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

        //select service from service table
        [Route("api/Mecanicien/GetService")]
        [HttpGet]
        public HttpResponseMessage GetService()
        {
            string query = @"select service from dbo.Service";
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

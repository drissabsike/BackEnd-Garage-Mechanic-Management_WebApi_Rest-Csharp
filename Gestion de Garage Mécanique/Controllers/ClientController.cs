using Gestion_de_Garage_Mécanique.Models;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace Gestion_de_Garage_Mécanique.Controllers
{
    public class ClientController : ApiController
    {
        //select all rows from Client table
        //methode fetch data from sql server
        public HttpResponseMessage Get()
        {
            string query = @"
                      select id,nom,prenom,cin,telephone,adresse,cp,ville,vehicule,date_create 
                      from dbo.Client 
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

        //select all rows from Client table by idd
        //methode fetch data from sql server by id
        public HttpResponseMessage GetById(int id)
        {
            string query = @"
                      select id,nom,prenom,cin,telephone,adresse,cp,ville,vehicule,date_create 
                      from dbo.Client where id =" + id + @"
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


        ///api/Client insert
        public string Post(Client client)
        {
            if (client.nom.Length == 0)
            {
                return "Verifier les champes";
            }
            else 
            try
            {
                string query = @"
            insert into dbo.Client(nom,prenom,cin,telephone,adresse,cp,ville,vehicule,info_client) values  
                    ('" + client.nom + @"','" + client.prenom + @"','" + client.cin + @"'," + client.telephone + @"
                    ,'" + client.adresse + @"'," + client.cp + @",'" + client.ville + @"','" + client.vehicule + @"',
                    '"+"Nom:"+client.nom+" Prenom:"+client.prenom+" Cin:"+client.cin+" Vehicule:"+client.vehicule+@"')
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


        ///api/Client update
        public string Put(Client client)
        {
            try
            {
                string query = @"
            update dbo.Client set nom='" + client.nom + @"',prenom='" + client.prenom + @"',cin='" + client.cin + @"',
                        telephone=" + client.telephone + @",adresse='" + client.adresse + @"',cp=" + client.cp + @",
                        ville='" + client.ville + @"',vehicule='" + client.vehicule + @"',
            info_client='" + "Nom:" + client.nom + " Prenom:" + client.prenom + " Cin:" + client.cin +" Vehicule:" + client.vehicule + @"'   
                        where id =" + client.id + @"  ";
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



        //api/Client delete
        public string Delete(int id)
        {
            try
            {
                string query = @"
            delete from dbo.Client where id =" + id + @"  ";
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

        [Route("api/Client/Getinfo")]
        [HttpGet]
        public HttpResponseMessage Getinfo()
        {
            string query = @" select info_client from dbo.Client ";
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

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
    public class FicheTechniqueController : ApiController
    {
        //select all rows from fiche technique table
        //methode fetch data from sql server
        public HttpResponseMessage Get()
        {
            string query = @"
                      select id,nom_mecanicien,probleme_client,service,date_creation,duree_service_jrs,montant_payer,info_client
                      from dbo.Fiche_technique
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

        //select all rows from fiche technique table by idd
        //methode fetch data from sql server by id
        public HttpResponseMessage GetById(int id)
        {
            string query = @"
                      select id,nom_mecanicien,probleme_client,service,date_creation,duree_service_jrs,montant_payer,info_client
                      from dbo.Fiche_technique where id =" + id + @"
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


        ///api/FicheTechnique insert
        public string Post(Fiche_technique Fiche)
        {
            if (Fiche.nom_mecanicien.Length == 0)
            {
                return "Verifier les champes";
            }
            else
                try
                {
                    string query = @"insert into dbo.Fiche_technique (nom_mecanicien,probleme_client,service,duree_service_jrs,montant_payer,info_client)
                    values ('" + Fiche.nom_mecanicien + @"','" + Fiche.probleme_client + @"','" + Fiche.service + @"',
                    "+Fiche.duree_service_jrs + @"," + Fiche.montant_payer + @",'" + Fiche.info_client + @"')
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
                    return "erreur in Post Code :" + e.Message;
                }

        }


        ///api/FicheTechnique update
        public string Put(Fiche_technique Fiche)
        {
            try
            {
                string query = @"
            update dbo.Fiche_technique set nom_mecanicien='" + Fiche.nom_mecanicien + @"',probleme_client='" + Fiche.probleme_client + @"',
                        service='" + Fiche.service + @"',duree_service_jrs=" + Fiche.duree_service_jrs + @",montant_payer=" + Fiche.montant_payer + @",
                        info_client='" + Fiche.info_client + @"'
                        where id =" + Fiche.id + @"  ";
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



        //api/FicheTechnique delete
        public string Delete(int id)
        {
            try
            {
                string query = @"
            delete from dbo.Fiche_technique where id =" + id + @"  ";
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

    }
}

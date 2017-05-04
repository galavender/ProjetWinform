using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace JobOverview
{
    public static class DALTaches
    {
        public static List<Personne> GetPersonnes()
        {
            var LstPersonnes = new List<Personne>();
            var connectString = Properties.Settings.Default.JobOverviewStringConnection;
            string queryString = @"select * from jo.Personne";

            using (var connect = new SqlConnection(connectString))
            {
                var command = new SqlCommand(queryString, connect);
                connect.Open();


                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var pers = new Personne();
                        pers.Login = (string)reader["Login"];
                        pers.Nom = (string)reader["Nom"];
                        pers.Prenom = (string)reader["Prenom"];
                        pers.CodeEquipe = (string)reader["CodeEquipe"];
                        pers.CodeMetier = (string)reader["CodeMetier"];
                        if (reader["Manager"] != DBNull.Value)
                            pers.Manager = (string)reader["Manager"];
                        pers.TauxProductivite = (float)reader["TauxProductivite"];
                        LstPersonnes.Add(pers);
                    }
                }
            }
            return LstPersonnes;
        }
        public static List<TacheProd> GetTacheProd()
        {
            var LstTacheProd = new List<TacheProd>();
            var connectString = Properties.Settings.Default.JobOverviewStringConnection;
            string queryString = @" select * 
                                    from jo.Tache t
                                    inner join jo.TacheProd tp on tp.IdTache=t.IdTache";

            using (var connect = new SqlConnection(connectString))
            {
                var command = new SqlCommand(queryString, connect);
                connect.Open();


                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var tache = new TacheProd();
                        tache.IdTache = (Guid)reader["IdTache"];
                        tache.Libelle = (string)reader["Libelle"];
                        tache.Annexe = (bool)reader["Annexe"];
                        tache.CodeActivité = (string)reader["CodeActivite"];
                        tache.Login = (string)reader["Login"];
                        tache.Description = (string)reader["Description"];
                        tache.Numero = (int)reader["Numero"];
                        tache.DureePrevue = (float)reader["DureePrevue"];
                        tache.DureeRestanteEstimee = (int)reader["DureeRestanteEstimee"];
                        tache.CodeModule = (string)reader["CodeModule"];
                        tache.CodeLogicielModule = (string)reader["CodeLogicielModule"];
                        tache.NumeroVersion = (float)reader["NumeroVersion"];
                      
                        LstTacheProd.Add(tache);
                    }
                }
            }
            return LstTacheProd;
        }
        public static List<Version> GetVersion()
        {
            var LstVersion = new List<Version>();
            var connectString = Properties.Settings.Default.JobOverviewStringConnection;
            string queryString = @" select * 
                                    from jo.Version";

            using (var connect = new SqlConnection(connectString))
            {
                var command = new SqlCommand(queryString, connect);
                connect.Open();


                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var version = new Version();
                        version.Numero = (float)reader["NumeroVersion"];
                        version.Numero = (float)reader["NumeroVersion"];
                        version.Millesime = (Int16)reader["Millesime"];
                        version.DateOuverture = (DateTime)reader["DateOuverture"];
                        version.DateSortiePrévue = (DateTime)reader["DateSortiePrevue"];
                        if (reader["DateSortieReelle"] != DBNull.Value)
                            version.DateSortieRéelle = (DateTime)reader["DateSortieReelle"];

                       


                        LstVersion.Add(version);
                    }
                }
            }
            return LstVersion;



        }
        public static List<TacheProd> ImportTaches()
        {
            List<TacheProd> LstTacheProd = new List<TacheProd>();

            XDocument doc = XDocument.Load(@"..\..\TachesProd.xml");

            foreach (var item in doc.Descendants("TacheProd"))
            {
                var tacheprod = new TacheProd();
                tacheprod.LstTravail = new List<Travail>();

                tacheprod.Libelle = (string)item.Attribute("Libelle");
                tacheprod.CodeActivité = (string)item.Attribute("Activite");
                tacheprod.Login = (string)item.Attribute("Personne");
                tacheprod.DureePrevue = (float)item.Attribute("DureePrev");
                tacheprod.DureeRestanteEstimee = (float)item.Attribute("DureeRest");
                tacheprod.CodeLogicielModule = (string)item.Attribute("Logiciel");
                tacheprod.CodeModule = (string)item.Attribute("Module");
                tacheprod.NumeroVersion = (float)item.Attribute("Version");

                foreach (var ite in item.Descendants("Travail"))
                {
                    var travail = new Travail();

                    travail.DateTravail = (DateTime)ite.Attribute("Date");
                    travail.Heures = (float)ite.Attribute("Heures");
                    travail.TauxProductivite = (float)ite.Attribute("TauxProduct");

                    tacheprod.LstTravail.Add(travail);
                }
                LstTacheProd.Add(tacheprod);

            }
            return LstTacheProd;

        }
    }
}

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
        public static List<string> GetCodeActivité()
        {
            List<string> LstCode = new List<string>();
            var connectString = Properties.Settings.Default.JobOverviewStringConnection;
            string queryString = @" select CodeActivite from jo.Activite where Annexe=0";

            using (var connect = new SqlConnection(connectString))
            {
                var command = new SqlCommand(queryString, connect);
                connect.Open();


                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        LstCode.Add((string)reader["CodeActivite"]);
                    }
                }
            }


            return LstCode;

        }
        private static DataTable GetDataTableForTache(List<TacheProd> LstTacheProd)
        {

            DataTable table = new DataTable();

            var colIdTache = new DataColumn("IdTache", typeof(Guid));
            colIdTache.AllowDBNull = false;
            table.Columns.Add(colIdTache);

            var colLibelle = new DataColumn("Libelle", typeof(string));
            colLibelle.AllowDBNull = false;
            table.Columns.Add(colLibelle);

            var colAnnexe = new DataColumn("Annexe", typeof(bool));
            colAnnexe.AllowDBNull = false;
            table.Columns.Add(colAnnexe);

            var colCodeActivite = new DataColumn("CodeActivite", typeof(string));
            colCodeActivite.AllowDBNull = false;
            table.Columns.Add(colCodeActivite);

            var colLogin = new DataColumn("Login", typeof(string));
            colLogin.AllowDBNull = false;
            table.Columns.Add(colLogin);

            table.Columns.Add(new DataColumn("description", typeof(string)));

            foreach (var p in LstTacheProd)
            {



                #region Ligne de table
                DataRow ligne = table.NewRow();

                ligne["IdTache"] = p.IdTache;
                ligne["Libelle"] = p.Libelle;
                ligne["Annexe"] = p.Annexe;
                ligne["CodeActivite"] = p.CodeActivité;
                ligne["Login"] = p.Login;

                if (p.Description != null)
                    ligne["description"] = p.Description;
                else ligne["description"] = DBNull.Value;
                #endregion


                table.Rows.Add(ligne);
            }

            return table;
        }
        private static DataTable GetDataTableForTacheProd(List<TacheProd> LstTacheProd)
        {

            DataTable table = new DataTable();

            var colIdTache = new DataColumn("IdTache", typeof(Guid));
            colIdTache.AllowDBNull = false;
            table.Columns.Add(colIdTache);

            /*var colNumero = new DataColumn("Numero", typeof(int));
            colNumero.AllowDBNull = false;
            table.Columns.Add(colNumero);
            */
            var colDureePrevue = new DataColumn("DureePrevue", typeof(float));
            colDureePrevue.AllowDBNull = false;
            table.Columns.Add(colDureePrevue);

            var colDureeRestanteEstimee = new DataColumn("DureeRestanteEstimee", typeof(float));
            colDureeRestanteEstimee.AllowDBNull = false;
            table.Columns.Add(colDureeRestanteEstimee);

            var colCodeModule = new DataColumn("CodeModule", typeof(string));
            colCodeModule.AllowDBNull = false;
            table.Columns.Add(colCodeModule);

            var colCodeLogicielModule = new DataColumn("CodeLogicielModule", typeof(string));
            colCodeLogicielModule.AllowDBNull = false;
            table.Columns.Add(colCodeLogicielModule);

            var colNumeroVersion = new DataColumn("NumeroVersion", typeof(string));
            colNumeroVersion.AllowDBNull = false;
            table.Columns.Add(colNumeroVersion);

            var colCodeLogicielVersion = new DataColumn("CodeLogicielVersion", typeof(string));
            colCodeLogicielVersion.AllowDBNull = false;
            table.Columns.Add(colCodeLogicielVersion);

            foreach (var p in LstTacheProd)
            {



                #region Ligne de table
                DataRow ligne = table.NewRow();

                ligne["IdTache"] = p.IdTache;
                //ligne["Numero"] = p.Numero;
                ligne["DureePrevue"] = p.DureePrevue;
                ligne["DureeRestanteEstimee"] = p.DureeRestanteEstimee;
                ligne["CodeModule"] = p.CodeModule;
                ligne["CodeLogicielModule"] = p.CodeLogicielModule;
                ligne["NumeroVersion"] = p.NumeroVersion;
                ligne["CodeLogicielVersion"] = p.CodeLogicielVersion;
                #endregion


                table.Rows.Add(ligne);
            }

            return table;
        }

        public static void InsertTache(List<TacheProd> LstTacheProd)
        {
            var connectString = Properties.Settings.Default.JobOverviewStringConnection;

            string queryString = @" insert jo.Tache(IdTache,Libelle,Annexe,CodeActivite,Login,Description)
                                    select IdTache,Libelle,Annexe,CodeActivite,Login,description from @tab";

            string queryString2 = @"insert jo.TacheProd(IdTache,DureePrevue,DureeRestanteEstimee,CodeModule,CodeLogicieModule,NumeroVersion,CodeLogicielVersion)
                                    select IdTache,DureePrevue,DureeRestanteEstimee,CodeModule,CodeLogicielModule,NumeroVersion,CodeLogicielVersion from @tab";


            var param = new SqlParameter("@tab", SqlDbType.Structured);
            DataTable tableProd = GetDataTableForTache(LstTacheProd);
            param.TypeName = "TypeTableTache";
            param.Value = tableProd;

            var param2 = new SqlParameter("@tab", SqlDbType.Structured);
            DataTable tableProd2 = GetDataTableForTacheProd(LstTacheProd);
            param2.TypeName = "TypeTableTacheProd";
            param2.Value = tableProd2;

            using (var connect = new SqlConnection(connectString))
            {



                connect.Open();
                SqlTransaction tran = connect.BeginTransaction();
                
                try
                {
                    var command = new SqlCommand(queryString, connect, tran);
                    command.Parameters.Add(param);
                    command.ExecuteNonQuery();

                    command = new SqlCommand(queryString2, connect, tran);
                    command.Parameters.Add(param2);
                    command.ExecuteNonQuery();
                    

                    tran.Commit();
                }
                catch (Exception)
                {
                    tran.Rollback();
                    throw;
                }

            }



        }

    }
}

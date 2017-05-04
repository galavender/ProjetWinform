using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOverview.FormLogiciel
{
    public static class DALLogiciel
    {
        public static List<Logiciel> GetLogicielFromDataReader()
        {
            var lst = new List<Logiciel>();
            var connectString = Properties.Settings.Default.JobOverviewStringConnection;
            string queryString = @"select * from jo.Logiciel";

            using (var connect = new SqlConnection(connectString))
            {
                var command = new SqlCommand(queryString, connect);
                connect.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        GetLogiciel(lst, reader);
                    }
                }
            }


            return lst;
        }
        private static void GetLogiciel(List<Logiciel> lst, SqlDataReader reader)
        {
            var log = new Logiciel();
            
            log.Code = (string)reader["CodeLogiciel"];
            log.Nom = (string)reader["Nom"];
            log.CodeFilière = (string)reader["CodeFiliere"];
            lst.Add(log);
            log.LstModule = new List<Module>();
            log.LstVersion = new List<Version>();

            GetModule(log.Code, log.LstModule);

            GetVersion(log.Code, log.LstVersion);
           


        }

        private static void GetModule(string codeLog, List<Module> lstModule)
        {
            

            var connectString = Properties.Settings.Default.JobOverviewStringConnection;
            string queryString = @"select * from jo.Module	where CodeLogiciel=@log";
            var paramLog = new SqlParameter("@log", DbType.String);
            paramLog.Value = codeLog;
            using (var connect = new SqlConnection(connectString))
            {
                var command = new SqlCommand(queryString, connect);
                connect.Open();

                command.Parameters.Add(paramLog);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var mod = new Module();
                        mod.Code = (string)reader["CodeModule"];
                        mod.Libellé = (string)reader["Libelle"];
                        if (reader["CodeModuleParent"]!=DBNull.Value)
                            mod.CodeModuleParent = (string)reader["CodeModuleParent"];
                        if (reader["CodeLogicielParent"] != DBNull.Value)
                            mod.CodeLogicielParent = (string)reader["CodeLogicielParent"];
                        lstModule.Add(mod);
                    }
                }
            }
        }
        private static void GetVersion(string codeLog, List<Version> lstVersion)
        {
            

          

            var connectString = Properties.Settings.Default.JobOverviewStringConnection;
            string queryString = @" select v.NumeroVersion, v.CodeLogiciel, v.Millesime, v.DateOuverture, v.DateSortiePrevue, v.DateSortieReelle, max(r.NumeroRelease) as DerniereRelease
                                    from jo.Version v
                                    inner join jo.Release r on r.NumeroVersion=v.NumeroVersion
                                    where r.CodeLogiciel=@log and r.CodeLogiciel=v.CodeLogiciel
                                    group by v.NumeroVersion, v.CodeLogiciel, v.Millesime, v.DateOuverture, v.DateSortiePrevue, v.DateSortieReelle
                                    ";
            var paramLog = new SqlParameter("@log", DbType.String);
            paramLog.Value = codeLog;
            using (var connect = new SqlConnection(connectString))
            {
                var command = new SqlCommand(queryString, connect);
                connect.Open();

                command.Parameters.Add(paramLog);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var vers = new Version();
                        vers.Numero = (float)reader["NumeroVersion"];
                        vers.Millesime = (Int16)reader["Millesime"];
                        vers.DateOuverture = (DateTime)reader["DateOuverture"];
                        vers.DateSortiePrévue = (DateTime)reader["DateSortiePrevue"];
                        if (reader["DateSortieReelle"] != DBNull.Value)
                            vers.DateSortieRéelle = (DateTime)reader["DateSortieReelle"];
                        if (reader["DerniereRelease"] != DBNull.Value)
                            vers.DerniereRelease = (Int16)reader["DerniereRelease"];
                        lstVersion.Add(vers);
                    }
                }
            }
        }


    }
}

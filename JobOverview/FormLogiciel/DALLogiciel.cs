using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOverview
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
                                    left outer join jo.Release r on r.NumeroVersion=v.NumeroVersion and r.CodeLogiciel=v.CodeLogiciel
                                    where v.CodeLogiciel=@log
                                    group by v.NumeroVersion, v.CodeLogiciel, v.Millesime, v.DateOuverture, v.DateSortiePrevue, v.DateSortieReelle";
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
        public static void InsertVersion(Version vers, string codeLog)
        {
            var connectString = Properties.Settings.Default.JobOverviewStringConnection;

            string queryString = @" insert jo.Version(NumeroVersion,CodeLogiciel,Millesime,DateOuverture,DateSortiePrevue,DateSortieReelle)
                                    values (@NumeroVersion,@CodeLogiciel,@Millesime,@DateOuverture,@DateSortiePrevue,@DateSortieReelle)";

            var paramNumeroVersion = new SqlParameter("@NumeroVersion", DbType.Double);
            paramNumeroVersion.Value =vers.Numero;
            var paramCodeLogiciel = new SqlParameter("@CodeLogiciel", DbType.String);
            paramCodeLogiciel.Value = codeLog;
            var paramMillesime = new SqlParameter("@Millesime", DbType.Int16);
            paramMillesime.Value = vers.Millesime;
            var paramDateOuverture = new SqlParameter("@DateOuverture", DbType.Date);
            paramDateOuverture.Value = vers.DateOuverture;
            var paramDateSortiePrevue = new SqlParameter("@DateSortiePrevue", DbType.Date);
            paramDateSortiePrevue.Value =vers.DateSortiePrévue;
            var paramDateSortieReelle = new SqlParameter("@DateSortieReelle", DbType.Date);
            paramDateSortieReelle.Value = vers.DateSortieRéelle;

            using (var connect = new SqlConnection(connectString))
            {
                connect.Open();
                SqlTransaction tran = connect.BeginTransaction();

                try
                {
                    var command = new SqlCommand(queryString, connect, tran);
                    command.Parameters.Add(paramNumeroVersion);
                    command.Parameters.Add(paramCodeLogiciel);
                    command.Parameters.Add(paramMillesime);
                    command.Parameters.Add(paramDateOuverture);
                    command.Parameters.Add(paramDateSortiePrevue);
                    command.Parameters.Add(paramDateSortieReelle);

                    command.ExecuteNonQuery();
                    tran.Commit();
                }
                catch
                {
                    tran.Rollback();
                    throw;
                }
            }
        }
        public static void SupprimerVersion(float codeVers, string codeLog)
        {
            var connectString = Properties.Settings.Default.JobOverviewStringConnection;

            string queryString = @" delete jo.Version where NumeroVersion=@NumeroVersion and CodeLogiciel=@CodeLogiciel";

            var paramNumeroVersion = new SqlParameter("@NumeroVersion", DbType.Double);
            paramNumeroVersion.Value = codeVers;
            var paramCodeLogiciel = new SqlParameter("@CodeLogiciel", DbType.String);
            paramCodeLogiciel.Value = codeLog;
  

            using (var connect = new SqlConnection(connectString))
            {
                connect.Open();
                SqlTransaction tran = connect.BeginTransaction();

                try
                {
                    var command = new SqlCommand(queryString, connect, tran);
                    command.Parameters.Add(paramNumeroVersion);
                    command.Parameters.Add(paramCodeLogiciel);

                    command.ExecuteNonQuery();
                    tran.Commit();
                }
                catch
                {
                    tran.Rollback();
                    throw;
                }
            }


        }
    }
}

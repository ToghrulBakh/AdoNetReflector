using AdoNetReflector.Abstract;
using AdoNetReflector.DbHelper;
using AdoNetReflector.Extensions;
using System.Data;
using System.Data.SqlClient;

namespace AdoNetReflector.Concrete
{
    public class AdoNetService : IAdoNetService
    {
        private readonly DBSettings settings;
        public AdoNetService(DBSettings settings)
        {
            this.settings = settings;
        }

        public NonQueryRespnose ExecuteNonQueryProc(string procName, List<SqlParameter>? parameters = null)
        {
            NonQueryRespnose resp = new();
            using (SqlConnection con = new (settings.ConnectionString))
            using (var cmd = new SqlCommand(procName, con) { CommandType = CommandType.StoredProcedure })
            {
                try
                {
                    if (parameters == null) parameters = Extension.InitSqlParams();


                    parameters.AddRetval("@return_value");
                    cmd.Parameters.AddRange(parameters.ToArray());


                    con.Open();

                    cmd.ExecuteNonQuery();
                    resp.ReturnValueSql = (int?)cmd.Parameters["@return_value"]?.Value ?? 0;
                }
                catch (Exception )
                {
                    //resp.ReturnValueSql = -1;
                    //resp.Message = ex.Message;
                    throw ;

                }
                finally
                {
                    con.Close();
                }

            }
            return resp;
        }

        public async Task<NonQueryRespnose> ExecuteNonQueryProcAsync(string procName, List<SqlParameter>? parameters = null)
        {
            NonQueryRespnose resp = new  ();
            using (SqlConnection con = new (settings.ConnectionString))
            using (var cmd = new SqlCommand(procName, con) { CommandType = CommandType.StoredProcedure })
            {
                try
                {
                    if (parameters == null) parameters = Extension.InitSqlParams();


                    parameters.AddRetval("@return_value");
                    cmd.Parameters.AddRange(parameters.ToArray());


                    await con.OpenAsync();

                    await cmd.ExecuteNonQueryAsync();
                    resp.ReturnValueSql = (int?)cmd.Parameters["@return_value"]?.Value ?? 0;
                }
                catch (Exception )
                {
                    //resp.ReturnValueSql = -1;
                    //resp.Message = ex.Message;
                    throw ;

                }
                finally
                {
                    con.Close();
                }

            }
            return resp;
        }

        public ReaderResponse<T> ExecuteReader<T>(string procName, List<SqlParameter>? parameters = null) where T : class
        {
            ReaderResponse<T> result = new ReaderResponse<T>();
            using (SqlConnection con = new SqlConnection(settings.ConnectionString))
            using (var cmd = new SqlCommand(procName, con) { CommandType = CommandType.StoredProcedure })
            {
                try
                {
                    if (parameters == null) parameters = Extension.InitSqlParams();


                    parameters.AddRetval("@return_value");
                    cmd.Parameters.AddRange(parameters.ToArray());

                    con.Open();


                    SqlDataReader dr = cmd.ExecuteReader();
                    result.Data = dr.LoadClassFromSQLDataReader<T>();
                    result.ReturnValueSql = (int?)cmd.Parameters["@return_value"]?.Value ?? 0;
                }
                catch (Exception )
                {
                    //result.ReturnValueSql = -1;
                    //result.Message = ex.Message;
                    throw ;
                }
                finally
                {
                    con.Close();
                }

            }
            return result;
        }

        public async Task<ReaderResponse<T>> ExecuteReaderAsync<T>(string procName, List<SqlParameter>? parameters = null)where T : class
        {
            ReaderResponse<T> result = new ReaderResponse<T>();
            using (SqlConnection con = new SqlConnection(settings.ConnectionString))
            using (var cmd = new SqlCommand(procName, con) { CommandType = CommandType.StoredProcedure })
            {
                try
                {
                    if (parameters == null) parameters = Extension.InitSqlParams();


                    parameters.AddRetval("@return_value");
                    cmd.Parameters.AddRange(parameters.ToArray());

                    con.Open();


                    SqlDataReader dr = await cmd.ExecuteReaderAsync();
                    result.Data = await dr.LoadClassFromSQLDataReaderAsync<T>();
                    result.ReturnValueSql = (int?)cmd.Parameters["@return_value"]?.Value ?? 0;
                }
                catch (Exception )
                {
                    //result.ReturnValueSql = -1;
                    //result.Message = ex.Message;
                    throw ;

                }
                finally
                {
                    con.Close();
                }

            }
            return result;
        }

        public ScalarResponse<T> ExecuteScalar<T>(string funcName, List<SqlParameter>? parameters = null)
        {
            ScalarResponse<T> result = new ScalarResponse<T>();
            using (SqlConnection con = new SqlConnection(settings.ConnectionString))
            using (var cmd = new SqlCommand(funcName, con) { CommandType = CommandType.StoredProcedure })
            {
                try
                {
                    con.Open();
                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters.ToArray());
                    result.Data = (T)(cmd.ExecuteScalar());


                }
                catch (Exception )
                {
                    //result.Message = ex.Message;
                    //result.Data= null;
                    throw ;
                }
                finally
                {
                    con.Close();
                }

            }
            return result;
        }

        public async Task<ScalarResponse<T>> ExecuteScalarAsync<T>(string funcName, List<SqlParameter>? parameters = null) where T : class
        {
            ScalarResponse<T> result = new ScalarResponse<T>();
            using (SqlConnection con = new (settings.ConnectionString))
            using (var cmd = new SqlCommand(funcName, con) { CommandType = CommandType.StoredProcedure })
            {
                try
                {
                    await con.OpenAsync();
                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters.ToArray());
                    result.Data = (T)await cmd.ExecuteScalarAsync();


                }
                catch (Exception )
                {
                    //result.Message = ex.Message;
                    //result.Data = null;
                    throw ;
                }
                finally
                {
                    con.Close();
                }

            }
            return result;
        }
    }
}

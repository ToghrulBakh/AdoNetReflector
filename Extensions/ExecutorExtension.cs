//using AdoNetRepository.DbHelper;
//using System.Data;
//using System.Data.SqlClient;

//namespace AdoNetReflector.Extensions
//{
//    public static partial class Extension
//    {
//        /// <summary> 
//        /// Usually for insert delete uptade procs  ,returns return value from proc as an integer
//        /// </summary>
//        public static NonQueryRespnose ExecuteNonQueryProc(this string procName, List<SqlParameter>? parameters = null)
//        {
//            NonQueryRespnose resp = new NonQueryRespnose();
//            using (SqlConnection con = new SqlConnection(Register.ConString)    
//            using (var cmd = new SqlCommand(procName, con) { CommandType = CommandType.StoredProcedure })
//            {
//                try
//                {
//                    if (parameters == null) parameters = Extension.Init();


//                    parameters.AddRetval("@return_value");
//                    cmd.Parameters.AddRange(parameters.ToArray());


//                    con.Open();

//                    cmd.ExecuteNonQuery();
//                    resp.ReturnValueSql = (int?)cmd.Parameters["@return_value"]?.Value ?? 0;
//                }
//                catch (Exception ex)
//                {
//                    //resp.ReturnValueSql = -1;
//                    //resp.Message = ex.Message;
//                    throw ex;

//                }
//                finally
//                {
//                    con.Close();
//                }

//            }
//            return resp;
//        }

//        public static async Task<NonQueryRespnose> ExecuteNonQueryProcAsync(this string procName, List<SqlParameter>? parameters = null)
//        {
//            NonQueryRespnose resp = new NonQueryRespnose();
//            using (SqlConnection con = new SqlConnection(Register.ConString))
//            using (var cmd = new SqlCommand(procName, con) { CommandType = CommandType.StoredProcedure })
//            {
//                try
//                {
//                    if (parameters == null) parameters = Extension.Init();


//                    parameters.AddRetval("@return_value");
//                    cmd.Parameters.AddRange(parameters.ToArray());


//                    await con.OpenAsync();

//                    await cmd.ExecuteNonQueryAsync();
//                    resp.ReturnValueSql = (int?)cmd.Parameters["@return_value"]?.Value ?? 0;
//                }
//                catch (Exception ex)
//                {
//                    //resp.ReturnValueSql = -1;
//                    //resp.Message = ex.Message;
//                    throw ex;

//                }
//                finally
//                {
//                    con.Close();
//                }

//            }
//            return resp;
//        }





//        /// <summary> 
//        /// Usually for get procs and  table valued functions,returns return value as an output parameter   from proc  
//        /// </summary>
//        public static ReaderResponse<T> ExecuteReader<T>(this string procName, List<SqlParameter>? parameters = null) where T : class
//        {
//            ReaderResponse<T> result = new ReaderResponse<T>();
//            using (SqlConnection con = new SqlConnection(Register.ConString))
//            using (var cmd = new SqlCommand(procName, con) { CommandType = CommandType.StoredProcedure })
//            {
//                try
//                {
//                    if (parameters == null) parameters = Extension.Init();


//                    parameters.AddRetval("@return_value");
//                    cmd.Parameters.AddRange(parameters.ToArray());

//                    con.Open();


//                    SqlDataReader dr = cmd.ExecuteReader();
//                    result.Data = dr.LoadClassFromSQLDataReader<T>();
//                    result.ReturnValueSql = (int?)cmd.Parameters["@return_value"]?.Value ?? 0;
//                }
//                catch (Exception ex)
//                {
//                    //result.ReturnValueSql = -1;
//                    //result.Message = ex.Message;
//                    throw ex;
//                }
//                finally
//                {
//                    con.Close();
//                }

//            }
//            return result;
//        }
//        public static async Task<ReaderResponse<T>> ExecuteReaderAsync<T>(this string procName, List<SqlParameter>? parameters = null) where T : class
//        {
//            ReaderResponse<T> result = new ReaderResponse<T>();
//            using (SqlConnection con = new SqlConnection(Register.ConString))
//            using (var cmd = new SqlCommand(procName, con) { CommandType = CommandType.StoredProcedure })
//            {
//                try
//                {
//                    if (parameters == null) parameters = Extension.Init();


//                    parameters.AddRetval("@return_value");
//                    cmd.Parameters.AddRange(parameters.ToArray());

//                    con.Open();


//                    SqlDataReader dr = await cmd.ExecuteReaderAsync();
//                    result.Data = await dr.LoadClassFromSQLDataReaderAsync<T>();
//                    result.ReturnValueSql = (int?)cmd.Parameters["@return_value"]?.Value ?? 0;
//                }
//                catch (Exception ex)
//                {
//                    //result.ReturnValueSql = -1;
//                    //result.Message = ex.Message;
//                    throw ex;

//                }
//                finally
//                {
//                    con.Close();
//                }

//            }
//            return result;
//        }






//        /// <summary> 
//        /// Usually for functions which returns parameter ( simple  data type  )  as a result
//        /// </summary>
//        public static ScalarResponse<T> ExecuteScalar<T>(this string funcName, List<SqlParameter>? parameters = null) where T : class
//        {

//            ScalarResponse<T> result = new ScalarResponse<T>();
//            using (SqlConnection con = new SqlConnection(Register.ConString))
//            using (var cmd = new SqlCommand(funcName, con) { CommandType = CommandType.StoredProcedure })
//            {
//                try
//                {
//                    con.Open();
//                    if (parameters != null)
//                        cmd.Parameters.AddRange(parameters.ToArray());
//                    result.Data = (T)(cmd.ExecuteScalar());


//                }
//                catch (Exception ex)
//                {
//                    //result.Message = ex.Message;
//                    //result.Data= null;
//                    throw ex;
//                }
//                finally
//                {
//                    con.Close();
//                }

//            }
//            return result;
//        }


//        public static async Task<ScalarResponse<T>> ExecuteScalarAsync<T>(this string funcName, List<SqlParameter>? parameters = null) where T : class
//        {

//            ScalarResponse<T> result = new ScalarResponse<T>();
//            using (SqlConnection con = new SqlConnection(Register.ConString))
//            using (var cmd = new SqlCommand(funcName, con) { CommandType = CommandType.StoredProcedure })
//            {
//                try
//                {
//                    await con.OpenAsync();
//                    if (parameters != null)
//                        cmd.Parameters.AddRange(parameters.ToArray());
//                    result.Data = (T)(await cmd.ExecuteScalarAsync());


//                }
//                catch (Exception ex)
//                {
//                    //result.Message = ex.Message;
//                    //result.Data = null;
//                    throw ex;
//                }
//                finally
//                {
//                    con.Close();
//                }

//            }
//            return result;
//        }









//        #region OldVersion


//        /// <summary> 
//        /// Usually for get procs and  table valued functions,returns return value  from proc  old version
//        /// </summary>
//        public static IEnumerable<T> ExecuteProcedure<T>(this string procName, List<SqlParameter> parameters = null) where T : class
//        {
//            IEnumerable<T> result;
//            using (SqlConnection con = new SqlConnection(Register.ConString))
//            using (var cmd = new SqlCommand(procName, con) { CommandType = CommandType.StoredProcedure })
//            {
//                try
//                {
//                    con.Open();
//                    if (parameters != null)
//                        cmd.Parameters.AddRange(parameters.ToArray());
//                    SqlDataReader dr = cmd.ExecuteReader();

//                    result = dr.LoadClassFromSQLDataReader<T>();

//                }
//                catch (Exception ex)
//                {
//                    throw ex;
//                }
//                finally
//                {
//                    con.Close();
//                }

//            }
//            return result;

//        }
//        #endregion

//    }

//}

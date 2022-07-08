 
using System.Data.SqlClient;

namespace AdoNetReflector.Abstract
{
    public interface IAdoNetService
    {
        public Task<NonQueryRespnose> ExecuteNonQueryProcAsync(string procName, List<SqlParameter>? parameters = null);
        public NonQueryRespnose ExecuteNonQueryProc(string procName, List<SqlParameter>? parameters = null);

        public Task<ReaderResponse<T>> ExecuteReaderAsync<T>(string procName, List<SqlParameter>? parameters = null) where T : class;
        public ReaderResponse<T> ExecuteReader<T>(string procName, List<SqlParameter>? parameters= null)where T : class;

        public Task<ScalarResponse<T>> ExecuteScalarAsync<T>(string procName, List<SqlParameter>? parameters = null)where T : class;    
        public ScalarResponse<T> ExecuteScalar<T>(string procName, List<SqlParameter>? parameters = null);

            

    }
}

using System;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace FactElectronicaV1.DataAccess
{
    public interface IDbFactory : IDisposable
    {
        SqlConnection EstablishedConnection(bool multipleActiveResultSets = false);
        Task<SqlConnection> EstablishedConnectionAsync();
    }
}

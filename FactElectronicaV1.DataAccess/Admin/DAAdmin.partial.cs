using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using FactElectronicaV1.Entities;

namespace FactElectronicaV1.DataAccess
{
    public partial class DAAdmin
    {
        #region [ Consultas ]

        public Admin ValidarLogin(String ADMUSUARIO, String ADMCLAVE)
        {
            try
            {
                Admin item = new Admin();
                Instance.DAAsignarProcedure("EFACT_ADMIN_VALIDAR_LOGIN");
                Instance.DAAgregarParametro("@ADMUSUARIO", ADMUSUARIO, SqlDbType.NVarChar, 10, ParameterDirection.Input);
                Instance.DAAgregarParametro("@ADMCLAVE", ADMCLAVE, SqlDbType.NVarChar, 50, ParameterDirection.Input);
                using (IDataReader reader = Instance.DAExecuteReader())
                {
                    if (reader.Read())
                    {
                        Loader.LoadEntity(reader, item);
                        item.Instance = InstanceEntity.Unchanged;
                    }
                    else
                    { return null; }
                }
                return item;
            }
            catch (Exception ex)
            { throw ex; }
        }

        #endregion

        #region [ Metodos ]

        #endregion
    }
}
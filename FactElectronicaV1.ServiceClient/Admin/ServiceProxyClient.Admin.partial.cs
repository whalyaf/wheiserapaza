using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FactElectronicaV1.Entities;

namespace FactElectronicaV1
{
    public partial class ServiceProxyClient
    {

        #region [ Consultas ]

        public Admin ValidarLoginAdmin(String ADMUSUARIO, String ADMCLAVE)
        {
            try
            {
                return this.BL_Admin.ValidarLogin(ADMUSUARIO, ADMCLAVE);
            }
            catch (Exception ex)
            { throw ex; }
        }

        #endregion

        #region [ Metodos ]

        #endregion

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FactElectronicaV1.Entities;

namespace FactElectronicaV1.BusinessLogic
{
    public partial class BLAdmin
    {

        #region [ Consultas ]

        public Admin ValidarLogin(String ADMUSUARIO, String ADMCLAVE)
        {
            try
            {
                return this.Repository.ValidarLogin(ADMUSUARIO, ADMCLAVE);
            }
            catch (Exception ex)
            { throw ex; }
        }

        #endregion

        #region [ Metodos ]

        #endregion

    }
}

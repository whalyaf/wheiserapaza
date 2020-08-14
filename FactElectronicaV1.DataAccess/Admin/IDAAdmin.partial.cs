using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FactElectronicaV1.Entities;

namespace FactElectronicaV1.DataAccess
{
    public partial interface IDAAdmin
    {
        #region [ Consultas ]

        Admin ValidarLogin(String ADMUSUARIO, String ADMCLAVE);

        #endregion

        #region [ Metodos ]

        #endregion
    }
}

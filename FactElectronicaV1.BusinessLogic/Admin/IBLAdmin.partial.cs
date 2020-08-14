using System;
using FactElectronicaV1.Entities;

namespace FactElectronicaV1.BusinessLogic
{
    public partial interface IBLAdmin
    {

        #region [ Consultas ]

        Admin ValidarLogin(String ADMUSUARIO, String ADMCLAVE);

        #endregion

        #region [ Metodos ]

        #endregion

    }
}
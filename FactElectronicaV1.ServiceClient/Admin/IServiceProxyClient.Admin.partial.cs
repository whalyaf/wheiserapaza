using System;
using FactElectronicaV1.Entities;

namespace FactElectronicaV1
{
    public partial interface IServiceProxyClient
    {

        #region [ Consultas ]

        Admin ValidarLoginAdmin(String ADMUSUARIO, String ADMCLAVE);

        #endregion

        #region [ Metodos ]

        #endregion

    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FactElectronicaV1.Entities;

namespace FactElectronicaV1
{
    public partial interface IServiceProxyClient
    {
        #region [ Consultas ]
        ObservableCollection<Admin> GetAllAdmin();
        Admin GetOneAdmin(String ADMUSUARIO);
        #endregion

        #region [ Metodos ]
        Boolean SaveAdmin(ref Admin Item);
        Boolean SaveAdmin(ref ObservableCollection<Admin> Items);
        #endregion
    }
}
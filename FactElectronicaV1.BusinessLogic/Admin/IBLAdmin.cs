using System;
using System.Collections.ObjectModel;
using FactElectronicaV1.Entities;

namespace FactElectronicaV1.BusinessLogic
{
    public partial interface IBLAdmin
    {
        #region [ Consultas ]
        ObservableCollection<Admin> GetAll();
        Admin GetOne(String ADMUSUARIO);
        #endregion

        #region [ Metodos ]
        Boolean Save(ref Admin Item);
        Boolean Save(ref ObservableCollection<Admin> Items);
        #endregion
    }
}

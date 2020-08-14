using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FactElectronicaV1.Entities;

namespace FactElectronicaV1.DataAccess
{
    public partial interface IDAAdmin
    {
        #region [ Consultas ]
        ObservableCollection<Admin> GetAll();
        Admin GetOne(String ADMUSUARIO);
        #endregion

        #region [ Metodos ]
        bool Save(ref Admin Item);
        #endregion
    }
}

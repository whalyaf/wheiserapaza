using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FactElectronicaV1.Entities;
using FactElectronicaV1.BusinessLogic;
using System.Collections.ObjectModel;
using Unity;

namespace FactElectronicaV1
{
    public partial class ServiceProxyClient : IServiceProxyClient
    {
        #region [ Propiedades ]
        [Dependency]
        public IBLAdmin BL_Admin { get; set; }
        #endregion

        #region [ Constructor]
        public ServiceProxyClient(IBLAdmin BL_Admin)
        {
            this.BL_Admin = BL_Admin;
        }

        #endregion

        #region [ Consultas ]
        public ObservableCollection<Admin> GetAllAdmin()
        {
            try
            {
                return this.BL_Admin.GetAll();
            }
            catch (Exception ex)
            { throw ex; }
        }
        public Admin GetOneAdmin(String ADMUSUARIO)
        {
            try
            {
                if (string.IsNullOrEmpty(ADMUSUARIO)) { return null; }
                return this.BL_Admin.GetOne(ADMUSUARIO);
            }
            catch (Exception ex)
            { throw ex; }
        }
        #endregion

        #region [ Metodos ]
        public Boolean SaveAdmin(ref Admin Item)
        {
            try
            {
                return this.BL_Admin.Save(ref Item);
            }
            catch (Exception ex)
            { throw ex; }
        }
        public Boolean SaveAdmin(ref ObservableCollection<Admin> Items)
        {
            try
            {
                return this.BL_Admin.Save(ref Items);
            }
            catch (Exception ex)
            { throw ex; }
        }
        #endregion
    }
}
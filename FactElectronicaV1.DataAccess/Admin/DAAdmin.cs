using System;
using System.Collections.ObjectModel;
using System.Data;
using FactElectronicaV1.Entities;
using Unity;

namespace FactElectronicaV1.DataAccess
{
    public partial class DAAdmin : IDAAdmin
    {
        #region [ Propiedades ]
        public IUnityContainer containerService { get; set; }
        public LoaderEntity<Admin> Loader { get; set; }

        public IDataAccessEnterprise Instance { get; set; }
        #endregion

        #region [ Constructores ]
        public DAAdmin(IDataAccessEnterprise container)
        {
            Loader = new LoaderEntity<Admin>();
            //Instance = container;
            Admin item = new Admin();
            Loader.EntityType = item.GetType();
            Instance = container;
        }
        #endregion

        #region [ Consultas ]
        public ObservableCollection<Admin> GetAll()
        {
            try
            {
                ObservableCollection<Admin> items = new ObservableCollection<Admin>();
                Admin item = new Admin();
                Instance.DAAsignarProcedure("EFACT_ADMIN_SELECT");
                using (IDataReader reader = Instance.DAExecuteReader())
                {
                    while (reader.Read())
                    {
                        item = new Admin();
                        Loader.LoadEntity(reader, item);
                        item.Instance = InstanceEntity.Unchanged;
                        items.Add(item);
                    }
                }
                return items;
            }
            catch (Exception ex)
            { throw ex; }
        }
        public Admin GetOne(String ADMUSUARIO)
        {
            try
            {
                Admin item = new Admin();
                Instance.DAAsignarProcedure("EFACT_ADMIN_SELECT");
                Instance.DAAgregarParametro("@ADMUSUARIO", ADMUSUARIO, SqlDbType.NVarChar, 50, ParameterDirection.Input);
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
        public bool Save(ref Admin item)
        {
            try
            {
                if (item.Instance != InstanceEntity.Unchanged)
                {
                    switch (item.Instance)
                    {
                        case InstanceEntity.New:
                            Instance.DAAsignarProcedure("_CATESI_UnReg");
                            Instance.DAAgregarParametro("@ADMUSUARIO", item.ADMUSUARIO, SqlDbType.Int, 4, ParameterDirection.InputOutput);
                            break;
                        case InstanceEntity.Modify:
                            Instance.DAAsignarProcedure("_CATESU_UnReg");
                            Instance.DAAgregarParametro("@ADMUSUARIO", item.ADMUSUARIO, SqlDbType.Int, 4, ParameterDirection.Input);
                            break;
                        case InstanceEntity.Delete:
                            Instance.DAAsignarProcedure("_CATESD_UnReg");
                            Instance.DAAgregarParametro("@ADMUSUARIO", item.ADMUSUARIO, SqlDbType.Int, 4, ParameterDirection.Input);
                            break;
                    }
                    if (item.Instance == InstanceEntity.New || item.Instance == InstanceEntity.Modify)
                    {
                        Instance.DAAgregarParametro("@CATE_IdSuper", item.ADMTIPO, SqlDbType.VarChar, 50, ParameterDirection.Input);
                        Instance.DAAgregarParametro("@CATE_Nombre", item.ADMEMAIL, SqlDbType.VarChar, 12, ParameterDirection.Input);
                    }


                    if (Instance.DAExecuteNonQuery() > 0)
                    { return true; }
                    else
                    { return false; }
                }
                else
                { return true; }
            }
            catch (Exception ex)
            { throw ex; }
        }
        #endregion
    }
}
using System;
using System.Web.Mvc;
using Unity.AspNet.Mvc;
using Unity;
using Unity.Injection;
using FactElectronicaV1.DataAccess;
using System.Configuration;

namespace FactElectronicaV1
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            string connectionString = ConfigurationManager.ConnectionStrings["Connection"].ToString();
            container.RegisterType<IDbFactory, DbFactory>(new InjectionConstructor(connectionString));

            container.RegisterType<FactElectronicaV1.DataAccess.IDataAccessEnterprise, FactElectronicaV1.DataAccess.DataAccessEnterprise>(new PerRequestLifetimeManager());

            container.RegisterType<FactElectronicaV1.DataAccess.IDAAdmin, FactElectronicaV1.DataAccess.DAAdmin>();

            container.RegisterType<FactElectronicaV1.BusinessLogic.IBLAdmin, FactElectronicaV1.BusinessLogic.BLAdmin>();

            container.RegisterType<FactElectronicaV1.IServiceProxyClient, FactElectronicaV1.ServiceProxyClient>(new PerRequestLifetimeManager());

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}
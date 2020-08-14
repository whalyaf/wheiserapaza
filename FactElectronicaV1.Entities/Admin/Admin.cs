using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactElectronicaV1.Entities
{
    public partial class Admin
    {
        #region [ Constructores ]
        /// <summary>
        /// Inicializar una nueva instancia de la clase Colab_Usuario.
        /// </summary>
        public Admin()
        { }
        #endregion

        public Int32 ADMID { get; set; }
        public string ADMUSUARIO { get; set; }
        public string ADMCLAVE { get; set; }
        public string ADMTIPO { get; set; }
        public string ADMEMAIL { get; set; }

        #region [ Instance Entity ]
        public InstanceEntity m_instance;

        public InstanceEntity Instance
        {
            get { return m_instance; }
            set { m_instance = value; }
        }

        protected void RefreshInstanceEntity()
        {
            if (Instance != InstanceEntity.New && Instance != InstanceEntity.Delete)
            { Instance = InstanceEntity.Modify; }
        }
        #endregion
    }
}

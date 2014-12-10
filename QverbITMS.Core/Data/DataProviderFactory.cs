using QverbITMS.Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QverbITMS.Core.Data
{
    public abstract class DataProviderFactory
    {
        protected DataProviderFactory(DataSettings settings)
        {
            //Guard.ArgumentNotNull(() => settings);
            this.Settings = settings;
        }

        protected DataSettings Settings
        {
            get;
            private set;
        }

        public abstract IDataProvider LoadDataProvider();
    }
}

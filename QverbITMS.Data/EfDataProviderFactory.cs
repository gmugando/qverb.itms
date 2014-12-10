﻿using QverbITMS.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QverbITMS.Core.Extensions;

namespace QverbITMS.Data
{
    public partial class EfDataProviderFactory : DataProviderFactory
    {
        public EfDataProviderFactory()
            : this(DataSettings.Current)
        {
        }

        public EfDataProviderFactory(DataSettings settings)
            : base(settings)
        {
        }

        public override IDataProvider LoadDataProvider()
        {
            var providerName = Settings.DataProvider;
            if (providerName.IsEmpty())
            {
                throw new Exception("Data Settings doesn't contain a providerName");
            }

            switch (providerName.ToLowerInvariant())
            {
                case "sqlserver":
                    return new SqlServerDataProvider();
                //case "sqlce":
                //    return new SqlCeDataProvider();
                default:
                    throw new Exception(string.Format("Unsupported dataprovider name: {0}", providerName));
            }
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QverbITMS.Core
{
    public interface IMergedData
    {
        bool MergedDataIgnore { get; set; }
        Dictionary<string, object> MergedDataValues { get; }
    }
}

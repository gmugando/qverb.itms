using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QverbITMS.Core.Enums
{
    public enum PriorityEnum
	{
        Highest = 4,
        High = 3,
        Medium = 2,
        Low = 1
	}

    public enum StatusEnum
    {
        Deferred = 5,
        WaitingForSomeone = 4,
        Completed = 3,
        InProgress = 2,
        NotStarted = 1
    } 


}

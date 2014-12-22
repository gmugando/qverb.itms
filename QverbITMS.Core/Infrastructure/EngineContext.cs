using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QverbITMS.Core.Infrastructure
{
    /// <summary>
    /// "Should" provide access to the singleton instance of the QverbITMS engine.
    /// </summary>
    public class EngineContext
    {
        #region readonly

        private static IEngine _engine;

        #endregion

        public EngineContext(IEngine engine)
        {
            _engine = engine;
        }
        public static IEngine Initialize(bool forceRecreate)
        {
            //if (Singleton<IEngine>.Instance == null || forceRecreate)
            //{
            //    Singleton<IEngine>.Instance = CreateEngineInstance();
            //    Singleton<IEngine>.Instance.Initialize();
            //}
            //return Singleton<IEngine>.Instance;
            _engine = CreateEngineInstance();
            _engine.Initialize();
            return _engine;

        }

        /// <summary>Gets the singleton SmartStore engine used to access SmartStore services.</summary>
        public static IEngine Current
        {
            get
            {
                //if (Singleton<IEngine>.Instance == null)
                //{
                //    Initialize(false);
                //}
                //return Singleton<IEngine>.Instance;
                return _engine;
            }
        }

        /// <summary>
        /// Creates a factory instance and adds a http application injecting facility.
        /// </summary>
        /// <returns>A new factory</returns>
        public static IEngine CreateEngineInstance()
        {
           return new QverbITMSEngine();
        }
    }
}

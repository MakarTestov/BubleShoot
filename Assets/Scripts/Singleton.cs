using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    public class Singleton<T> where T : new()
    {
        #region Parameters
        #region singleton
        /// <summary>
        /// Объект синглтон
        /// </summary>
        private static Singleton<T> singleton;
        #endregion

        #region obj
        /// <summary>
        /// Объект типа T
        /// </summary>
        public T obj;
        #endregion
        #endregion

        #region Constructors
        #region Singleton()
        private Singleton()
        {
            obj = new T();
        }
        #endregion
        #endregion

        #region T GetSingleton()
        /// <summary>
        /// Получить объект T
        /// </summary>
        /// <returns></returns>
        public static Singleton<T> GetSingleton()
        {
            if(singleton == null)
            {
                singleton = new Singleton<T>();
            }
            return singleton;
        }
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Parameters
{
    /// <summary>
    /// Класс хранящий информацию об уровне
    /// </summary>
    class ParametersLevel
    {
        #region Parameters
        #region NumberLevel
        /// <summary>
        /// Номер текущего уровня
        /// </summary>
        private int numberLevel;
        /// <summary>
        /// Номер текущего уровня
        /// </summary>
        public int NumberLevel
        {
            get { return numberLevel; }
            set { numberLevel = value; }
        }
        #endregion
        #endregion

        #region Constructors
        public ParametersLevel()
        {
            numberLevel = 1;
        }
        #endregion
    }
}

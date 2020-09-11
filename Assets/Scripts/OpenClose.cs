using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    /// <summary>
    /// Класс для 
    /// </summary>
    static class OpenClose
    {
        #region ShowHide_GameObject(GameObject ob)
        /// <summary>
        /// Показать/скрыть объект
        /// </summary>
        public static void ShowHide_GameObject(GameObject ob)
        {
            ob.SetActive(!ob.activeInHierarchy);
        }
        #endregion
    }
}

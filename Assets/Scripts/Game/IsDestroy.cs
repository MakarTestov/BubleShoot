using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Game
{
    class IsDestroy : MonoBehaviour
    {
        #region Parameters
        #region Deleteob
        public delegate void Dest();
        /// <summary>
        /// Событие при уничтожении объекта
        /// </summary>
        public event Dest Deleteob;
        #endregion

        #region Boom
        /// <summary>
        /// Ссылка на объект взрыва
        /// </summary>
        public GameObject Boom;
        #endregion
        #endregion

        #region Unity Method
        private void OnDestroy()
        {
            Destroy(Instantiate(Boom, gameObject.transform.position, Quaternion.identity,gameObject.transform.parent), 1.0f);
            Deleteob?.Invoke();
        }
        #endregion
    }
}

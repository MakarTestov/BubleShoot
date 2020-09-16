using Assets.Scripts.Game.Save;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.About
{
    class StartAboute : MonoBehaviour
    {
        #region TextAbout
        /// <summary>
        /// Ссылка на текст об игре
        /// </summary>
        [SerializeField]
        private Text textAbout;
        public Text TextAbout
        {
            get { return textAbout; }
            set { textAbout = value; }
        }
        #endregion

        #region Unity Methods
        private void Start()
        {
            StartAbout();
        }
        #endregion

        #region  StartAbout()
        /// <summary>
        /// Утсановить начальные настройки зоны
        /// </summary>
        public void StartAbout()
        {
           TextAbout.text = "Best score : " + Singleton<PointPlayer>.GetSingleton().obj.BestPoint.ToString() + "\n\r" + textAbout.text;
        }
        #endregion
    }
}

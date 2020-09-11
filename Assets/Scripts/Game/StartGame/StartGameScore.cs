using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Game.Save.StartGame
{
    /// <summary>
    /// Установить счет по умолчанию
    /// </summary>
    class StartGameScore : MonoBehaviour
    {
        #region Parameters
        #region BestScore
        /// <summary>
        /// Ссылка на текст UI, с лучшим счетом
        /// </summary>
        [SerializeField]
        private Text bestScore;
        /// <summary>
        /// Ссылка на текст UI, с лучшим счетом
        /// </summary>
        public Text BestScore
        {
            get { return bestScore; }
            set { bestScore = value; }
        }
        #endregion
        #endregion

        #region Unity Method
        private void Start()
        {
            BestScore.text = Singleton<PointPlayer>.GetSingleton().obj.BestPoint.ToString();
        }
        #endregion
    }
}

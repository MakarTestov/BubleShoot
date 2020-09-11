using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Game.Save
{
    /// <summary>
    /// Класс для работы с очками пользователя
    /// </summary>
    class PointPlayer
    {
        #region Parameters
        #region BestPoint
        /// <summary>
        /// Лучший счет игрока
        /// </summary>
        private int bestPoint;
        /// <summary>
        /// Лучший счет игрока
        /// </summary>
        public int BestPoint
        {
            get { return bestPoint; }
            set { bestPoint = value; }
        }
        #endregion
        #endregion

        #region Constructors
        #region PointPlayer()
        public PointPlayer()
        {
            if(PlayerPrefs.HasKey(TagsPlayerPref.GetBestScore()))
            {
                BestPoint = PlayerPrefs.GetInt(TagsPlayerPref.GetBestScore());
            }
            else
            {
                BestPoint = 0;
            }
        }
        #endregion
        #endregion

        #region SavePointPlayer(int point)
        /// <summary>
        /// Сохранить счет игрока
        /// </summary>
        /// <param name="point">Новый счет</param>
        public void SavePointPlayer(int point)
        {
            if(point > bestPoint)
            {
                PlayerPrefs.SetInt(TagsPlayerPref.GetBestScore(), point);
                PlayerPrefs.Save();
            }
        }
        #endregion
    }
}

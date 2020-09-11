using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Game.Save
{
    /// <summary>
    /// Класс, хранящий все теги для сохранения информации в PlayerPref
    /// </summary>
    static class TagsPlayerPref
    {
        #region GetBestScore()
        /// <summary>
        /// Возвращает тег лучшего счета
        /// </summary>
        /// <returns>BestScore</returns>
        public static string GetBestScore() => "BestScore";
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Parameters
{
    /// <summary>
    /// Класс для получения имен всех сцен
    /// </summary>
    static class AllNameScene
    {
        #region GetMineMenuNameScene()
        /// <summary>
        /// Возвращает имя сцены главного меню
        /// </summary>
        /// <returns></returns>
        public static string GetMineMenu_NameScene() => "MineMenu";
        #endregion

        #region GetAbout_NameScene()
        /// <summary>
        /// Возвращает имя сцены о приложении
        /// </summary>
        /// <returns></returns>
        public static string GetAbout_NameScene() => "About";
        #endregion

        #region GetGame_NameScene()
        /// <summary>
        /// Возвращает имя игровой сцены
        /// </summary>
        /// <returns></returns>
        public static string GetGame_NameScene() => "Game";
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Parameters
{
    /// <summary>
    /// Класс для получения имени файлов
    /// </summary>
    static class AllNameFile
    {
        #region LevelGame(int number)
        /// <summary>
        /// Возвращает имя файлов уровней
        /// </summary>
        /// <param name="number">Номер требуемого уровня</param>
        /// <returns>Имя файла уровня</returns>
        public static string LevelGame(int number) => "Files/Level" + number.ToString();
        #endregion
    }
}

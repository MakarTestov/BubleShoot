using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    class ColorFromText
    {
        #region Color GetColorFromText(string text)
        /// <summary>
        /// Получить цвет из текста
        /// </summary>
        /// <param name="text">текстовое описание цвета</param>
        /// <returns>Цвет</returns>
        public static Color GetColorFromText(string text)
        {
            switch (text)
            {
                case "blue":
                    {
                        return Color.blue;
                    }
                case "red":
                    {
                        return Color.red;
                    }
                case "green":
                    {
                        return Color.green;
                    }
                default:
                    {
                        return Color.red;
                    }
            }
        }
        #endregion

        #region Color GetRandomColor()
        /// <summary>
        /// Получить случайный цвет
        /// </summary>
        /// <returns></returns>
        public static Color GetRandomColor()
        {
            switch(new System.Random().Next(3))
            {
                case 0:
                    {
                        return Color.blue;
                    }
                case 1:
                    {
                        return Color.red;
                    }
                case 2:
                    {
                        return Color.green;
                    }
                default:
                    {
                        return Color.green;
                    }
            }
        }
        #endregion
    }
}

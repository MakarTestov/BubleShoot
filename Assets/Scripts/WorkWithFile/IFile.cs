using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.WorkWithFile
{
    interface IFile
    {
        /// <summary>
        /// Путь к файлу
        /// </summary>
        string Path { get; set; }
        /// <summary>
        /// Открыть файл
        /// </summary>
        void OpenFile();
    }
}

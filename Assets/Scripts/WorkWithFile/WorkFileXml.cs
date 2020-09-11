using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using UnityEngine;

namespace Assets.Scripts.WorkWithFile
{
    class WorkFileXml : IFile
    {
        #region Parameters
        #region FileXml
        /// <summary>
        /// Документ xml
        /// </summary>
        private XmlDocument fileXml;
        /// <summary>
        /// Документ xml
        /// </summary>
        public XmlDocument FileXml
        {
            get { return fileXml; }
            set { fileXml = value; }
        }
        #endregion

        #region Path
        /// <summary>
        /// Путь к файлу
        /// </summary>
        private string path;
        /// <summary>
        /// Путь к файлу
        /// </summary>
        public string Path 
        {
            get { return path; }
            set { path = value; }
        }
        #endregion
        #endregion

        #region Constructors
        #region WorkFileXml()
        /// <summary>
        /// Создать экземпляр класса
        /// </summary>
        public WorkFileXml()
        {

        }
        #endregion

        #region WorkFileXml(string path)
        /// <summary>
        /// Создать экземпляр класса
        /// </summary>
        /// <param name="path">Путь к файлу</param>
        public WorkFileXml(string path)
        {
            this.Path = path;
        }
        #endregion
        #endregion

        #region OpenFile(string path)
        /// <summary>
        /// Открыть Xml файл
        /// </summary>
        /// <param name="path">Путь к файлу в папке Resourse</param>
        public void OpenFile()
        {
            TextAsset textAsset = Resources.Load<TextAsset>(Path);
            fileXml = new XmlDocument();
            FileXml.LoadXml(textAsset.text);
        }
        #endregion
    }
}

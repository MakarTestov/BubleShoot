using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Game
{
    class LoadLevel : MonoBehaviour
    {
        #region Parameters
        #region NumberLine
        /// <summary>
        /// Номер текущей линии
        /// </summary>
        private int NumberLine;
        #endregion

        #region NumberonLine
        /// <summary>
        /// Номер в линии
        /// </summary>
        private int NumberonLine;
        #endregion

        #region paterncircle
        /// <summary>
        /// Массив всех созданных объектов
        /// </summary>
        private GameObject[,] paterncircle;
        #endregion

        #region Index
        /// <summary>
        /// Структура индексов
        /// </summary>
        private struct Index
        {
            public int i;
            public int j;
        }
        /// <summary>
        /// Индекс загружаемых объектов
        /// </summary>
        private Index index = new Index { i = 0, j = 0 };
        #endregion

        #region Parent
        /// <summary>
        /// Родитель
        /// </summary>
        private Transform Parent;
        #endregion

        #region Patern
        /// <summary>
        /// Объект генерации
        /// </summary>
        private GameObject Patern;
        #endregion

        #region SpawnPoint
        /// <summary>
        /// Место генерации
        /// </summary>
        private Transform SpawnPoint;
        #endregion

        #region CreateOb
        public delegate void NewOb(GameObject ob);
        /// <summary>
        /// Событие при создании новых объектов
        /// </summary>
        public event NewOb CreateOb;
        #endregion
        #endregion

        #region Constructors
        #region LoadLevel()
        public LoadLevel()
        {
            NumberLine = 0;
            NumberonLine = 0;
        }
        #endregion
        #endregion

        #region LoadonScenePaternFromFileXml()
        /// <summary>
        /// Загрузить все мячи из файла
        /// </summary>
        public void LoadonScenePaternFromFileXml(XmlDocument filexml, Transform parent, GameObject patern, Transform spawnpoint)
        {
            Parent = parent;
            Patern = patern;
            SpawnPoint = spawnpoint;

            CreateArrayPatern(filexml);

            ReadXmlFile(filexml);
        }
        #endregion

        #region ReadXmlFile(XmlDocument filexml)
        /// <summary>
        /// Обработать файл
        /// </summary>
        /// <param name="filexml">файл уровня</param>
        private void ReadXmlFile(XmlDocument filexml)
        {
            foreach (XmlNode r in filexml.ChildNodes)
            {
                foreach (XmlNode v in r.ChildNodes)
                {
                    LoadLine(v);
                    index.i++;
                    index.j = 0;
                }
            }
        }
        #endregion

        #region CreateArrayPatern(XmlDocument filexml)
        /// <summary>
        /// Создать массив исходя из файла игры
        /// </summary>
        /// <param name="filexml"></param>
        private void CreateArrayPatern(XmlDocument filexml)
        {
            int n = Convert.ToInt16(filexml.DocumentElement.GetAttribute("countline"));
            int m = Convert.ToInt16(filexml.DocumentElement.GetAttribute("countonline"));
            paterncircle = new GameObject[n, m];
        }
        #endregion

        #region LoadLine(XmlNode xml)
        /// <summary>
        /// Проход по линии мячей и их генерация
        /// </summary>
        /// <param name="xml"></param>
        private void LoadLine(XmlNode xml)
        {
            foreach (XmlNode r in xml.ChildNodes)
            {
                CreatePatternCircle((XmlElement)r);
                index.j++;
            }
        }
        #endregion

        #region CreatePatternCircle()
        /// <summary>
        /// Создать новый круг
        /// </summary>
        private void CreatePatternCircle(XmlElement xml)
        {
            paterncircle[index.i, index.j] = Instantiate(Patern, Parent);
            SetparametersNewObject(xml, paterncircle[index.i, index.j]);
            SetPositionPatern(paterncircle[index.i, index.j]);
            SetspringJoint(index.i, index.j);
            CreateOb?.Invoke(paterncircle[index.i, index.j]);
        }
        #endregion

        #region SetparametersNewObject(XmlElement xml, GameObject ob)
        /// <summary>
        /// Установить параметры для нового объекта
        /// </summary>
        /// <param name="xml">Элемент из файла для чтения параметров</param>
        /// <param name="ob">Новый созданный объект</param>
        private void SetparametersNewObject(XmlElement xml, GameObject ob)
        {
            SetColorOb(ob.GetComponent<Image>(), xml);
        }
        #endregion

        #region SetColorOb(Image im, XmlElement xml)
        /// <summary>
        /// Установить цвет из файла
        /// </summary>
        /// <param name="im">Ссылка на компонент изображения</param>
        /// <param name="xml">Элемент для чтени яцвета</param>
        private void SetColorOb(Image im, XmlElement xml)
        {
            im.color = ColorFromText.GetColorFromText(xml.GetAttribute("color"));
        }
        #endregion

        #region SetspringJoint(int i, int j)
        /// <summary>
        /// Установить соединение для узла
        /// </summary>
        /// <param name="i">индекс строки узла</param>
        /// <param name="j">индекс столбца узла</param>
        private void SetspringJoint(int i, int j)
        {
            if(j == 0)
            {
                paterncircle[i, j].GetComponent<SpringJoint2D>().connectedAnchor = new Vector2(paterncircle[i, j].transform.position.x, 
                    paterncircle[i, j].transform.position.y+1.0f);
            }
            else
            {
                paterncircle[i, j].GetComponent<SpringJoint2D>().connectedBody = paterncircle[i, j-1].GetComponent<Rigidbody2D>();
            }
        }
        #endregion

        #region SetPositionPatern(GameObject ob)
        /// <summary>
        /// Установить расположение на экране
        /// </summary>
        /// <param name="ob">Объект для расположения</param>
        private void SetPositionPatern(GameObject ob)
        {
            RectTransform rect = ob.GetComponent<RectTransform>();
            Vector3 pos = SpawnPoint.localPosition + new Vector3(rect.rect.width * index.i, -rect.rect.height * index.j);
            ob.transform.localPosition = pos;
        }
        #endregion
    }
}

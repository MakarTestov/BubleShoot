using Assets.Scripts.Game.Moving;
using Assets.Scripts.Game.Save;
using Assets.Scripts.Parameters;
using Assets.Scripts.WorkWithFile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Scripts.Game
{
    class StartGame : MonoBehaviour
    {
        #region Parameters
        #region fileXml
        /// <summary>
        /// Ссылка на объект файла чтения уровня
        /// </summary>
        private WorkFileXml fileXml;
        #endregion

        #region PaternBall
        /// <summary>
        /// Ссылка на объект шаблона гругов
        /// </summary>
        [SerializeField]
        private GameObject paternBall;
        /// <summary>
        /// Ссылка на объект шаблона гругов
        /// </summary>
        public GameObject PaternBall
        {
            get { return paternBall; }
            set { paternBall = value; }
        }
        #endregion

        #region SpawnPoint
        /// <summary>
        /// Ссылка на место спауна гругов
        /// </summary>
        [SerializeField]
        private Transform spawnPoint;
        /// <summary>
        /// Ссылка на место спауна гругов
        /// </summary>
        public Transform SpawnPoint
        {
            get { return spawnPoint; }
            set { spawnPoint = value; }
        }
        #endregion

        #region Parent
        /// <summary>
        /// Объект родитель
        /// </summary>
        [SerializeField]
        private Transform parent;
        /// <summary>
        /// Объект родитель
        /// </summary>
        public Transform Parent
        {
            get { return parent; }
            set { parent = value; }
        }
        #endregion

        #region background
        /// <summary>
        /// Ссылка на фон запуска
        /// </summary>
        [SerializeField]
        private RectTransform background;
        #endregion

        #region lineRenderer
        /// <summary>
        /// Ссылка на объект отрисовки 
        /// </summary>
        [SerializeField]
        private TrejectRender lineRenderer;
        #endregion

        #region Score
        /// <summary>
        /// Ссылка на текст счета
        /// </summary>
        [SerializeField]
        private Text Score;
        #endregion

        #region CountBall
        /// <summary>
        /// Ссылка на текст хранящий количество шаров
        /// </summary>
        [SerializeField]
        private Text CountBall;
        #endregion

        #region EndGame
        public delegate void EventGame();
        /// <summary>
        /// Событие при завершении игры
        /// </summary>
        public event EventGame EndGame;
        #endregion

        #region CountCreateball
        /// <summary>
        /// Количество созданных мячей
        /// </summary>
        private int countCreateball;
        /// <summary>
        /// Количество созданных мячей
        /// </summary>
        public int CountCreateball
        {
            get { return countCreateball; }
            set
            {
                if (value == 0)
                {
                    EndGamePlay();
                }
                countCreateball = value;
            }
        }
        #endregion
        #endregion

        #region Unity Methods
        private void Start()
        {
            SetStartParameters();
            LoadLevel loadLevel = new LoadLevel();
            loadLevel.CreateOb += CreateOb;
            loadLevel.LoadonScenePaternFromFileXml(fileXml.FileXml, Parent, PaternBall, SpawnPoint);
            loadLevel.CreateOb -= CreateOb;
        }
        #endregion

        #region SetStartParameters()
        /// <summary>
        /// Установить начальные значения для начала игры
        /// </summary>
        public void SetStartParameters()
        {
            fileXml = new WorkFileXml();
            fileXml.Path = AllNameFile.LevelGame(Singleton<ParametersLevel>.GetSingleton().obj.NumberLevel);
            fileXml.OpenFile();
            SetParametersBall();
        }
        #endregion

        #region SetParametersBall()
        /// <summary>
        /// Установить свойства мяча по-умолчанию
        /// </summary>
        private void SetParametersBall()
        {
            int x = Convert.ToInt32(CountBall.text);
            if (x > 0)
            {
                GameObject ob = Instantiate(paternBall, background.transform);
                ob.AddComponent<Shoot>();
                ob.GetComponent<Shoot>().treject = lineRenderer;
                ob.GetComponent<MovePlayerBall>().Background = background;
                ob.GetComponent<MovePlayerBall>().Handle = ob.GetComponent<RectTransform>();
                ob.GetComponent<Image>().color = ColorFromText.GetRandomColor();
                ob.GetComponent<Shoot>().end += EndShoot;
                CountCreateball++;
                CountBall.text = (x - 1).ToString();
            }
            else
            {
                EndGamePlay();
            }
        }
        #endregion

        #region EndShoot(Shoot shoot)
        /// <summary>
        /// При остановке мяча
        /// </summary>
        /// <param name="shoot"></param>
        private void EndShoot(Shoot shoot)
        {
            shoot.end -= EndShoot;
            SetParametersBall();
        }
        #endregion

        #region CreateOb(GameObject ob)
        /// <summary>
        /// Создании объекта
        /// </summary>
        /// <param name="ob"></param>
        private void CreateOb(GameObject ob)
        {
            ob.GetComponent<IsDestroy>().Deleteob += DestroyOb;
            CountCreateball++;
        }
        #endregion

        #region DestroyOb()
        /// <summary>
        /// Увеличение счета при уничтожении объекта
        /// </summary>
        private void DestroyOb()
        {
            Score.text = (Convert.ToInt32(Score.text) + 1).ToString();
            CountCreateball--;
        }
        #endregion

        #region EndGamePlay()
        /// <summary>
        /// Завершение игры
        /// </summary>
        private void EndGamePlay()
        {
            Singleton<PointPlayer>.GetSingleton().obj.SavePointPlayer(Convert.ToInt32(Score.text));
            SceneManager.LoadScene(AllNameScene.GetMineMenu_NameScene());
        }
        #endregion
    }
}

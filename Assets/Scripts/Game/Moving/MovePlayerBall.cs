using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

namespace Assets.Scripts.Game.Moving
{
    class MovePlayerBall : MonoBehaviour, IDragHandler, IPointerDownHandler//, IPointerUpHandler
    {
        #region Parameters
        #region HandleLimit
        /// <summary>
        /// Ограничение растояния
        /// </summary>
        [Range(0f, 2f)][SerializeField]
        private float handleLimit = 0.5f;
        /// <summary>
        /// Ограничение растояния
        /// </summary>
        public float HandleLimit
        {
            get { return handleLimit; }
            set { handleLimit = value; }
        }
        #endregion

        #region inputVector
        /// <summary>
        /// Точка нажатия
        /// </summary>
        [HideInInspector]
        private Vector2 inputVector = Vector2.zero;
        #endregion

        #region Background
        /// <summary>
        /// Ссылка на фоновый объект
        /// </summary>
        [SerializeField]
        private RectTransform background;
        /// <summary>
        /// Ссылка на фоновый объект
        /// </summary>
        public RectTransform Background
        {
            get { return background; }
            set { background = value; }
        }
        #endregion

        #region Handle
        /// <summary>
        /// Ссылка на объект управления
        /// </summary>
        [SerializeField]
        private RectTransform handle;
        /// <summary>
        /// Ссылка на объект управления
        /// </summary>
        public RectTransform Handle
        {
            get { return handle; }
            set { handle = value; }
        }
        #endregion

        #region Horizontal
        /// <summary>
        /// Где он относительно горизонтали
        /// </summary>
        public float Horizontal 
        { 
            get { return inputVector.x; }
            set { inputVector.x = value; }
        }
        #endregion

        #region Vertical
        /// <summary>
        /// Где он относительно вертикали
        /// </summary>
        public float Vertical 
        { 
            get { return inputVector.y; }
            set { inputVector.y = value; }
        }
        #endregion

        #region ballPosition
        /// <summary>
        /// Текущее положения мяча
        /// </summary>
        private Vector2 ballPosition = Vector2.zero;
        #endregion

        #region cam
        /// <summary>
        /// Ссылка на основную камеру
        /// </summary>
        private Camera cam;
        #endregion
        #endregion

        #region Unity Methods
        void Start()
        {
            cam = Camera.main;
            ballPosition = RectTransformUtility.WorldToScreenPoint(cam, background.position);
        }

        public void OnDrag(PointerEventData eventData)
        {
            Vector2 direction = eventData.position - ballPosition;
            inputVector = (direction.magnitude > background.sizeDelta.x / 2f) ? direction.normalized : direction / (background.sizeDelta.x / 2f);
            handle.anchoredPosition = (inputVector * background.sizeDelta.x / 2f) * handleLimit;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            OnDrag(eventData);
        }

       /* public void OnPointerUp(PointerEventData eventData)
        {
            inputVector = Vector2.zero;
            handle.anchoredPosition = Vector2.zero;
        }*/
        #endregion
    }
}

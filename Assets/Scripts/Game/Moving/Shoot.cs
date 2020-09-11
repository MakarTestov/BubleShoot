﻿using Assets.Scripts.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Game.Moving
{
    [RequireComponent(typeof(MovePlayerBall))]
    [RequireComponent(typeof(TrejectRender))]
    class Shoot : MonoBehaviour
    {
        #region Parameters
        #region ballmove
        /// <summary>
        /// Ссылка на компонент объекта движени
        /// </summary>
        private MovePlayerBall ballmove;
        #endregion

        #region treject
        /// <summary>
        /// Ссылка на компонент отображения пути
        /// </summary>
        [SerializeField]
        public TrejectRender treject;
        /// <summary>
        /// Ссылка на компонент отображения пути
        /// </summary>
        public TrejectRender Treject
        {
            get { return treject; }
            set { treject = value; }
        }
        #endregion

        #region Speed
        /// <summary>
        /// Скорость движения
        /// </summary>
        public float speed = 9.0f;
        #endregion

        #region maxdist
        /// <summary>
        /// Текущее натяжение
        /// </summary>
        private float maxdist;
        #endregion

        #region ismaxspeed
        /// <summary>
        /// Натянуто ли на максимум
        /// </summary>
        private bool ismaxspeed = false;
        #endregion

        #region eps
        /// <summary>
        /// Отклонение от курса
        /// </summary>
        private int eps = 5;
        #endregion

        #region ismove
        /// <summary>
        /// Движется ли сейчас объект
        /// </summary>
        private bool ismove = false;
        #endregion

        #region isfirstcoll
        /// <summary>
        /// Было ли первое столкновение
        /// </summary>
        private bool isfirstcoll = true;
        #endregion

        #region End
        public delegate void End(Shoot shoot);
        /// <summary>
        /// Событие вызываемое при окончании движения
        /// </summary>
        public event End end;
        #endregion
        #endregion

        #region Unity Methods
        private void Start()
        {
            ballmove = GetComponent<MovePlayerBall>();
            end += DeleteColorBall;
        }

        private void OnMouseDrag()
        {
            treject.Show(transform.position, new Vector3(-ballmove.Horizontal, -ballmove.Vertical, 0));
            maxdist = Convert.ToSingle(Math.Sqrt(ballmove.Horizontal * ballmove.Horizontal + ballmove.Vertical * ballmove.Vertical));
        }

        private void OnMouseUp()
        {
            GetComponent<MovePlayerBall>().enabled = false;
            GetComponent<TrejectRender>().enabled = false;
            ballmove.Handle = null;
            treject.enabled = false;
            //Debug.Log(ballmove.Horizontal);
            //ballmove.Horizontal += (float)(new System.Random().NextDouble());
            if (maxdist >= 1)
            {
                ismaxspeed = true;
            }
            else
            {
                ismaxspeed = false;
            }
            speed *= maxdist;
            ismove = true;
        }

        public void OnCollisionEnter2D(Collision2D collision)
        {
            if(collision.transform.tag == "ball")
            {
                if(ismaxspeed)
                {
                    if(isfirstcoll)
                    {
                        Destroy(collision.gameObject);
                        isfirstcoll = false;
                    }
                    else
                    {
                        SetParametersAfterColli(collision);
                    }
                }
                else
                {
                    SetParametersAfterColli(collision);
                }
            }
            if(ismove == false)
            {
                if(collision.transform.tag == "Wall")
                {
                    Destroy(gameObject);
                }
            }
        }

        private void FixedUpdate()
        {
            if(ismove)
            {
                //transform.rotation = Quaternion.LookRotation(new Vector3(ballmove.Horizontal, ballmove.Vertical));
                Vector3 move = new Vector3(-ballmove.Horizontal, -ballmove.Vertical, 0);
                transform.position += move * speed * Time.deltaTime;
                CheckPosition();
            }
        }
        #endregion

        #region CheckPosition()
        /// <summary>
        /// Проверить положение шара
        /// </summary>
        private void CheckPosition()
        {
            int w = Display.main.systemWidth / 2;
            if(transform.localPosition.x < -w || transform.localPosition.x > w)
            {
                ballmove.Horizontal = -ballmove.Horizontal;
            }
        }
        #endregion

        #region SetParametersAfterColli(Collision2D ob)
        /// <summary>
        /// Установить параметры после коллизии
        /// </summary>
        /// <param name="ob"></param>
        private void SetParametersAfterColli(Collision2D ob)
        {
            SetSpringJoint(ob.gameObject.GetComponent<Rigidbody2D>());
            transform.parent = ob.transform.parent;
            treject.enabled = false;
            GetComponent<Shoot>().enabled = false;
            ismove = false;
            end?.Invoke(this);
        }
        #endregion

        #region SetSpringJoint(Rigidbody2D ob)
        /// <summary>
        /// Установить точку крепления
        /// </summary>
        /// <param name="ob"></param>
        private void SetSpringJoint(Rigidbody2D ob)
        {
            GetComponent<SpringJoint2D>().connectedBody = ob;
        }
        #endregion


        /// <summary>
        /// Удалить шарики того же цвета
        /// </summary>
        /// <param name="shoot"></param>
        private void DeleteColorBall(Shoot shoot)
        {
            Debug.Log("Start destroy");
            GetComponent<DeleteColorBall>().DeleteFromAllColor(new List<GameObject> { gameObject }, GetComponent<Image>().color);
        }
    }
}

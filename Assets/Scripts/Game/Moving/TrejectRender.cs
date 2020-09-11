using Assets.Scripts.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Game.Moving
{
    class TrejectRender : MonoBehaviour
    {
        #region Parameters
        #region lineRenderer
        /// <summary>
        /// Ссылка на компонент отрисовки траектории
        /// </summary>
        private LineRenderer lineRenderer;
        #endregion

        #region xlimit
        /// <summary>
        /// Ограничение по оси X
        /// </summary>
        private float xlimit = 2.8f;
        #endregion

        #region ylimit
        /// <summary>
        /// Ограничение по оси Y
        /// </summary>
        private float ylimit = 5.0f;
        #endregion

        #region countpoints
        /// <summary>
        /// Количество точек для отрисовки
        /// </summary>
        public int countpoints = 100;
        #endregion

        #region isreverce
        /// <summary>
        /// Было ли отражение
        /// </summary>
        public bool isreverce = false;
        #endregion
        #endregion

        #region Unity Method
        private void Start()
        {
            lineRenderer = GetComponent<LineRenderer>();
        }
        #endregion

        #region Show(Vector3 origin, Vector3 speed)
        /// <summary>
        /// Показать траекторию
        /// </summary>
        /// <param name="origin"></param>
        /// <param name="speed"></param>
        public void Show(Vector3 origin, Vector3 speed)
        {
            List<Vector3> points = new List<Vector3>();
            lineRenderer.positionCount = countpoints;
            for (int i = 0; i < countpoints; i++)
            {
                Vector3 point = new Vector3();
                float time = i * 0.1f;
                point = origin + speed * time;
                points.Add(point);
                if(point.x < -xlimit || point.x > xlimit)
                {
                    /*origin = point;
                    speed.x = -speed.x;*/
                    ShowLine(point, speed, points);
                    isreverce = true;
                    break;
                }
                if(point.y < -ylimit || point.y > ylimit)
                {
                    lineRenderer.positionCount = i;
                    break;
                }
            }

            lineRenderer.SetPositions(points.ToArray());
        }
        #endregion

        #region ShowLine(Vector3 origin, Vector3 speed, List<Vector3> points)
        /// <summary>
        /// Рисование линии после отражения
        /// </summary>
        /// <param name="origin"></param>
        /// <param name="speed"></param>
        /// <param name="points"></param>
        private void ShowLine(Vector3 origin, Vector3 speed, List<Vector3> points)
        {
            speed.x = -speed.x;
            for (int i = points.Count - 1; i < countpoints; i++)
            {
                Vector3 point = new Vector3();
                float time = i * 0.1f;
                point = origin + speed * time;
                points.Add(point);
            }
        }
        #endregion
    }
}

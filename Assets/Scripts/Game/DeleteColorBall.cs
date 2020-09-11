using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Game
{
    class DeleteColorBall : MonoBehaviour
    {
        #region Parameters
        #region Radius
        public int radius = 5000;
        #endregion
        #endregion

        #region DeleteFromAllColor(List<GameObject> pastobjects)
        /// <summary>
        /// Удалить все объекты в радиусе того же цвета
        /// </summary>
        /// <param name="pastobjects"></param>
        public void DeleteFromAllColor(List<GameObject> pastobjects, Color color)
        {
            Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.localPosition, radius);
            foreach(var hitcollider in hitColliders)
            {
                if(color == hitcollider.GetComponent<Image>().color && pastobjects.Find(x => x == hitcollider.gameObject) == null)
                {
                    pastobjects.Add(transform.gameObject);
                    Debug.Log("NextBallColor");
                    hitcollider.gameObject.GetComponent<DeleteColorBall>().DeleteFromAllColor(pastobjects, color);
                }
            }
            Destroy(transform.gameObject);
        }
        #endregion
    }
}

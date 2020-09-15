using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Game
{
    /// <summary>
    /// При столкновении удалить шары одного цвета
    /// </summary>
    class DeleteColorBall : MonoBehaviour
    {
        public void DeleteObColor(GameObject ob)
        {
            List<GameObject> listob = DeleteAllBallColor(new List<GameObject> { ob }, ob.GetComponent<Image>().color);
            Debug.Log(listob.Count);
            if (listob.Count > 2)
            {
                foreach (GameObject r in listob)
                {
                    Destroy(r);
                }
            }
        }
        #region DeleteAllBallColor(List<GameObject> ob, Color color)
        /// <summary>
        /// Удалить все шары того же цвета обойдя все связи
        /// </summary>
        /// <param name="ob"></param>
        /// <param name="color"></param>
        public List<GameObject> DeleteAllBallColor(List<GameObject> ob, Color color)
        {
            //Debug.Log(gameObject.GetComponents<SpringJoint2D>().Length);
            SpringJoint2D[] sp = gameObject.GetComponents<SpringJoint2D>();
            Debug.Log(sp.Length);
            if (sp.Length > 0)
            {
                Debug.Log("ifup");
                foreach (SpringJoint2D r in sp)
                {
                    if (r.GetComponent<Image>().color == color && !ob.Exists(x => x == r.gameObject))
                    {
                        ob.Add(r.gameObject);
                        r.GetComponent<DeleteColorBall>().DeleteAllBallColor(ob, color);
                    }
                }
            }
            return ob;
        }
        #endregion
    }
}

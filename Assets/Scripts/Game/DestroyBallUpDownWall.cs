using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Game
{
    class DestroyBallUpDownWall : MonoBehaviour
    {
        #region Unity Methods
        public void OnCollisionEnter2D(Collision2D collision)
        {
            if(collision.transform.tag == "ball")
            {
                Destroy(collision.gameObject);
            }
        }
        #endregion
    }
}

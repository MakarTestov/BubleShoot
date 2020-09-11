using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class StartWall : MonoBehaviour
{
    #region Unity Method
    private void Start()
    {
        Vector2 sizewall = GetComponent<RectTransform>().rect.size;
        GetComponent<BoxCollider2D>().size = sizewall;
    }
    #endregion
}

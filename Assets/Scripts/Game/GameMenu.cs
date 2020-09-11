using Assets.Scripts.Parameters;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    #region BackToMenu()
    /// <summary>
    /// Событие при нажатии кнопки вернуться в меню
    /// </summary>
    public void BackToMenu()
    {
        SceneManager.LoadScene(AllNameScene.GetMineMenu_NameScene());
    }
    #endregion
}

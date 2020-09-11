using Assets.Scripts.Parameters;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AboutMenu : MonoBehaviour
{
    #region BackToMenuClick()
    /// <summary>
    /// Событие при вызове кнопки выхода в меню
    /// </summary>
    public void BackToMenuClick()
    {
        SceneManager.LoadScene(AllNameScene.GetMineMenu_NameScene());
    }
    #endregion

    #region OpenDeveloper()
    /// <summary>
    /// Событие при вызове открытия страницы разработчика
    /// </summary>
    public void OpenDeveloper()
    {
        Application.OpenURL(AllLink.VK());
    }
    #endregion
}

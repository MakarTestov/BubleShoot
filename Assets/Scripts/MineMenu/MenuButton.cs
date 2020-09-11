using Assets.Scripts;
using Assets.Scripts.Parameters;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{

    #region Parameters
    #region exitPanel
    /// <summary>
    /// ССылка на панель закрытия игры
    /// </summary>
    [SerializeField]
    private GameObject exitPanel;
    #endregion
    #endregion

    #region PlayClick()
    /// <summary>
    /// Событие при нажатии на кнопку начала игры
    /// </summary>
    public void PlayClick()
    {
        SceneManager.LoadScene(AllNameScene.GetGame_NameScene());
    }
    #endregion

    #region AboutClick()
    /// <summary>
    /// Событие при нажатии кнопки "О программе"
    /// </summary>
    public void AboutClick()
    {
        SceneManager.LoadScene(AllNameScene.GetAbout_NameScene());
    }
    #endregion

    #region ExitClick()
    /// <summary>
    /// Событие при нажатии кнопки выхода из приложения
    /// </summary>
    public void ExitClick()
    {
        Application.Quit();
    }
    #endregion

    #region OpenClose_ExitPanel()
    /// <summary>
    /// Закрыть/открыть объект
    /// </summary>
    public void OpenClose_ExitPanel()
    {
        OpenClose.ShowHide_GameObject(exitPanel);
    }
    #endregion
}

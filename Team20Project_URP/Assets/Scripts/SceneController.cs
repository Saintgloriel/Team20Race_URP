using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    /// <summary>
    /// Загружает сцену с главным меню игры 
    /// </summary>
    public void OnMainMenuPress()
    {
        SceneManager.LoadScene(0);
    }

    /// <summary>
    /// Загружает игровую сцену с гоночной трассой
    /// </summary>
    public void OnPlayButtonPress()
    {
        SceneManager.LoadScene(1);
    }

    /// <summary>
    /// Закрывает приложение
    /// </summary>
    public void OnExitButtonPress()
    {
        Application.Quit();
        Debug.Log("Game Quit!");
    }
    
}  

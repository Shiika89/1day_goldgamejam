using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange
{
    private static bool roadNow = false;

    /// <summary>
    /// Titleシーンに移行する
    /// </summary>
    public static void RoadTitle()
    {
        if (roadNow)
        {
            return;
        }
        roadNow = true;
        FadeController.StartFadeOut(Title);
    }   
    /// <summary>
    /// Gameシーンに移行する
    /// </summary>
    public static void LoadGame(string name)
    {
        if (roadNow)
        {
            return;
        }
        roadNow = true;
        FadeController.StartFadeOut(() => Game(name));
    }

    private static void Title()
    {
        roadNow = false;
        SceneManager.LoadScene("TitleScene");
    }
    private static void Game(string name)
    {
        roadNow = false;
        SceneManager.LoadScene(name);
    }
}

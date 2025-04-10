using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public static class Utilities
{
    public static int playerDeaths = 0;
    public static string UpdateDeathCount(ref int countReference)
    {
        countReference += 1;
        return "Next time, you'll be at number " + countReference + ".";
    }
    public static void RestartLevel()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1.0f;
    }

    public static bool RestartLevel(int sceneIndex)
    {
        Debug.Log("Player deaths: " + playerDeaths + "");
        string message = UpdateDeathCount(ref playerDeaths);
        Debug.Log("Player deaths: " + playerDeaths);
        Debug.Log(message);
        SceneManager.LoadScene(sceneIndex);
        Time.timeScale = 1.0f;
        return true;
    }
}
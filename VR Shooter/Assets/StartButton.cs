using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    public int GameStartSceneIndex;

    public void StartGame()
    {
        SceneManager.LoadScene(GameStartSceneIndex);
    }
}

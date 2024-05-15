using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{

    public enum GameState{ Level1, Level2 };
    public static GameState currentGameState = GameState.Level1;

    public void LoadFirstLevel()
    {
        if (currentGameState == GameState.Level1)
        {
            currentGameState = GameState.Level2;
            DontDestroyOnLoad(gameObject);
            SceneManager.LoadScene(1);
        }
    }
}

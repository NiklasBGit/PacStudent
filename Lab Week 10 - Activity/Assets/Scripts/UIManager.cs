using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public enum GameState{ Start, WalkingLevel };
    public static GameState currentGameState = GameState.Start;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadFirstLevel()
    {
        if (currentGameState == GameState.Start)
        {
            currentGameState = GameState.WalkingLevel;
            DontDestroyOnLoad(gameObject);
            SceneManager.LoadScene(1);
        }
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public void QuitGame()
    {
        UnityEditor.EditorApplication.isPlaying = false;
    }

    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.buildIndex == 1)
        {
            Button btn = GameObject.FindWithTag("QuitButton").GetComponent<Button>();
            btn.onClick.AddListener(QuitGame);
        }
    }
}

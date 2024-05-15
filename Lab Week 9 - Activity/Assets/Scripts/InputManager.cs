using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class InputManager : MonoBehaviour
{
    public SaveGameManager saveGameManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            SpeedManager.CurrentSpeedState = (SpeedManager.CurrentSpeedState == SpeedManager.GameSpeed.Slow) ? SpeedManager.GameSpeed.Fast : SpeedManager.GameSpeed.Slow;
            saveGameManager.SaveSpeed();
        }

        else if (GameManager.currentGameState == GameManager.GameState.Start && Input.GetKeyDown("return"))
        {
            GameManager.currentGameState = GameManager.GameState.WalkingLevel;
            Destroy(GetComponent<Tweener>());
            DontDestroyOnLoad(gameObject);
            SceneManager.LoadScene(1);
        }
    }
}

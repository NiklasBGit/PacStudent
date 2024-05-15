using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveGameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        LoadSpeed();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SaveSpeed()
    {
        PlayerPrefs.SetInt("currentSpeed", (int)SpeedManager.SpeedModifier);
    }

    public void LoadSpeed()
    {
        if (PlayerPrefs.HasKey("currentSpeed"))
        {
            SpeedManager.CurrentSpeedState = (PlayerPrefs.GetInt("currentSpeed") == 1)
                ? SpeedManager.GameSpeed.Slow
                : SpeedManager.GameSpeed.Fast;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    private int currentTime;
    private int lastTime;
    private float timer;
    private const float moveWait = 2.0f;
    [SerializeField] private Transform[] transformArray;
    void Start()
    {
        transformArray[0] = GameObject.FindWithTag("Red").transform;
        transformArray[1] = GameObject.FindWithTag("Blue").transform;
        ResetTime();
    }

    void Update()
    {
        timer += Time.deltaTime;
        if ((int)timer > lastTime)
        {
            lastTime = (int)timer;
            MoveObject();
            Debug.Log(lastTime);

        } if (Input.GetKeyDown("space") && Time.timeScale == 1)
        {
            Time.timeScale = 0;
            Debug.Log("Spacebar pressed");
        } else if (Input.GetKeyDown("space") && Time.timeScale == 0)
        {
            Time.timeScale = 1;
            Debug.Log("Spacebar pressed");
        } if (Input.GetKeyDown("return"))
        {
            ResetTime();
        }
    }
    private void ResetTime()
    {
        timer = 0;
        lastTime = 0;
        Debug.Log(lastTime);
    }

    private void MoveObject()
    {
        if ((lastTime % (int)moveWait == 0) && (lastTime % (int)(moveWait * 2) != 0)) {
            Vector3 currentPosRed = transformArray[0].position;
            Vector3 currentPosBlue = transformArray[1].position;
            transformArray[0].position = new Vector3(currentPosRed.x, currentPosBlue.y, 0);
            transformArray[1].position = new Vector3(currentPosBlue.x, currentPosRed.y, 0);
        } if (lastTime % (int)(moveWait * 2) == 0) {
            Vector3 currentPosRed = transformArray[0].position;
            Vector3 currentPosBlue = transformArray[1].position;
            transformArray[0].position = new Vector3(currentPosBlue.x, currentPosRed.y, 0);
            transformArray[1].position = new Vector3(currentPosRed.x, currentPosBlue.y, 0);

        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private Transform[] transAray = new Transform[2];
    
    // Start is called before the first frame update
    void Start()
    {
        transAray[0] = GameObject.FindWithTag("Red").transform;
        transAray[1] = GameObject.FindWithTag("Blue").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W)) {
            transAray[0].Rotate(0, 0, 45);
            transAray[1].Rotate(0, 0, -45);
        } if (Input.GetButtonDown("Fire1"))
        {
            Vector3 currentPosRed = transAray[0].position;
            Vector3 currentPosBlue = transAray[1].position;
            transAray[0].position = new Vector3(currentPosRed.x, currentPosBlue.y, currentPosRed.z);
            transAray[1].position = new Vector3(currentPosBlue.x, currentPosRed.y, currentPosBlue.z);
        }
    }
}

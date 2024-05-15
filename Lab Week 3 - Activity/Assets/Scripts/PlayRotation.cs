﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayRotation : MonoBehaviour
{
    public Animator animatorController;
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !audioSource.isPlaying)
        {
            animatorController.SetTrigger("RotateParam");
            audioSource.Play();
        }
    }
}

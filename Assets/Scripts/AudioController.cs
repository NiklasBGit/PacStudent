using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioSource introTrack;
    public AudioSource loopTrack;
    // Start is called before the first frame update
    void Start()
    {
        introTrack.Play();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!introTrack.isPlaying && !loopTrack.isPlaying)
        {
            loopTrack.Play();
        }   
    }
}

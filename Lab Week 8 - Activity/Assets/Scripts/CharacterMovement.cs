using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private Vector3 movement;
    private float movementSqrMagnitude;
    public float walkSpeed = 1.75f;
    public Animator animatorController;
    public AudioSource footstepSource;
    public AudioClip[] footstepClips;
    public AudioSource backgroundMusic;

    // Update is called once per frame
    void Update()
    {
        GetMovementInput();
        CharacterPostion(); 
        CharacterRotation();
        WalkAnimation();
        FootstepAudio();
    }

    void GetMovementInput()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.z = Input.GetAxis("Vertical");
        Vector3.ClampMagnitude(movement,1);
        movementSqrMagnitude = movement.sqrMagnitude;
        // Debug.Log(movement);
    }
    void CharacterPostion()
    {
        transform.Translate(movement * walkSpeed * Time.deltaTime, Space.World); 
    }
    void CharacterRotation() 
    {
        if (movement.magnitude > 0)
        {
            transform.rotation = Quaternion.LookRotation(movement);
        }
    }
    void WalkAnimation() 
    {
        animatorController.SetFloat("MovingSpeed", movementSqrMagnitude);
    }
    void FootstepAudio() 
    {
        if (movementSqrMagnitude > 0.25f && !footstepSource.isPlaying)
        {
            if (footstepSource.clip == footstepClips[0])
            {
                footstepSource.clip = footstepClips[1];
                Debug.Log(footstepSource.clip);
            }
            else if (footstepSource.clip == footstepClips[1])
            {
                footstepSource.clip = footstepClips[0];
                Debug.Log(footstepSource.clip);
            }
            footstepSource.Play();
            
            backgroundMusic.volume = 0.5f;
        }
        if (movementSqrMagnitude <= 0.3f && footstepSource.isPlaying)
        {
            footstepSource.Stop();
            backgroundMusic.volume = 1.0f;
        }
    }
}

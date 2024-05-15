using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotionController : MonoBehaviour
{
    int nextOrientation;
    [SerializeField] private GameObject player;
    [SerializeField] private Animator animatorController;
    private Tweener tweener;

    // Start is called before the first frame update
    void Start()
    {
        tweener = GetComponent<Tweener>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 topLeft = new Vector3(1.0f, -1.0f, 0.0f);
        Vector3 topRight = new Vector3(6.0f, -1.0f, 0.0f);
        Vector3 bottomRight = new Vector3(6.0f, -5.0f, 0.0f);
        Vector3 bottomLeft = new Vector3(1.0f, -5.0f, 0.0f);
        int speed = 1;
        if (player.transform.position == topLeft)
        {
            animatorController.SetTrigger("Flipped");
            float time = Vector3.Distance(topLeft, topRight)/ speed;
            tweener.AddTween(player.transform, player.transform.position, topRight, time);
            nextOrientation = 1;
            animatorController.SetInteger("nextOrientation", nextOrientation);
            Debug.Log("1");
        }
        if (player.transform.position == topRight)
        {
            float time = Vector3.Distance(topRight, bottomRight) / speed;
            tweener.AddTween(player.transform, player.transform.position, bottomRight, time);
            nextOrientation = 2;
            animatorController.SetInteger("nextOrientation", nextOrientation);
            Debug.Log("2");
        }
        if (player.transform.position == bottomRight)
        {
            animatorController.SetTrigger("Flipped");
            float time = Vector3.Distance(bottomRight, bottomLeft) / speed;
            tweener.AddTween(player.transform, player.transform.position, bottomLeft, time);
            nextOrientation = 3;
            animatorController.SetInteger("nextOrientation", nextOrientation);
            Debug.Log("3");
        }
        if (player.transform.position == bottomLeft)
        {
            float time = Vector3.Distance(bottomLeft, topLeft) / speed;
            tweener.AddTween(player.transform, player.transform.position, topLeft, time);
            nextOrientation = 0;
            animatorController.SetInteger("nextOrientation", nextOrientation);
            Debug.Log("4");
        }
    }
}

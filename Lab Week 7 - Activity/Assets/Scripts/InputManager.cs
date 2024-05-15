using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] private GameObject item;
    private List<GameObject> itemList = new List<GameObject>();
    private Tweener tweener;
    // Start is called before the first frame update
    void Start()
    {
        tweener = GetComponent<Tweener>();
        itemList.Add(item);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            float duration = 1.5f;
            Vector3 endPos = new Vector3(-2.0f,0.5f,0.0f);
            tryAddTween(endPos, duration);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            float duration = 1.5f;
            Vector3 endPos = new Vector3(2.0f, 0.5f, 0.0f);
            tryAddTween(endPos, duration);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            float duration = 0.5f;
            Vector3 endPos = new Vector3(0.0f, 0.5f, -2.0f);
            tryAddTween(endPos, duration);
        }
        if (Input.GetKeyDown(KeyCode.W)) 
        {
            float duration = 0.5f;
            Vector3 endPos = new Vector3(0.0f, 0.5f, 2.0f);
            tryAddTween(endPos, duration);

        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject clone = Instantiate(item, new Vector3(0.0f, 0.5f, 0.0f), Quaternion.identity);
            itemList.Add(clone);
        }
    }

    void tryAddTween(Vector3 endPos, float duration)
    {
        foreach (GameObject item in itemList)
        {
            if (tweener.AddTween(item.transform, item.transform.position, endPos, duration) == true)
            {
                break;
            }
        }
    }
}

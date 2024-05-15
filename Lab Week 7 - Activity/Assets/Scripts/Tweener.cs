using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tweener : MonoBehaviour
{
    // private Tween activeTween;
    private List<Tween> activeTweens = new List<Tween>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i=activeTweens.Count-1; i>=0; i--)
        {
            if (Vector3.Distance(activeTweens[i].Target.position, activeTweens[i].EndPos) > 0.1f)
            {
                float startTime = activeTweens[i].StartTime;
                float currentTime = Time.time;
                float t = ((currentTime - startTime) / activeTweens[i].Duration);
                float tSquared = t * t * t;
                activeTweens[i].Target.position = Vector3.Lerp(activeTweens[i].StartPos, activeTweens[i].EndPos, tSquared);
            }

            if (Vector3.Distance(activeTweens[i].Target.position, activeTweens[i].EndPos) <= 0.1f)
            {
                activeTweens[i].Target.position = activeTweens[i].EndPos;
                activeTweens.Remove(activeTweens[i]);
            }
        }
    }

    public bool AddTween(Transform targetObject, Vector3 startPos, Vector3 endPos, float duration)
    {
        bool hasActiveTween = TweenExists(targetObject);
        if (hasActiveTween == false)
        {
            Tween activeTween = new Tween(targetObject, startPos, endPos, Time.time, duration);
            activeTweens.Add(activeTween);
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool TweenExists(Transform target)
    {
        bool inList = false;
        foreach (Tween activeTween in activeTweens)
        {
            if (activeTween.Target == target)
            {
                inList = true;
                break;
                
            }
            else
            {
                inList = false;
            }
        }
        return inList;
    }
}

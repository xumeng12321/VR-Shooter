using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SliderPull : MonoBehaviour
{

    public float threshold;
    public Transform targetLocation;
    public UnityEvent OnPostionReach;
    private bool reached = false;

    // Start is called before the first frame update
    private void FixedUpdate()
    {
        float dist = Vector3.Distance(transform.position,targetLocation.position);
        // Debug.Log(dist);
        if(dist < threshold && reached == false)
        {
            OnPostionReach.Invoke();
            reached = true;
        }
        else if(dist > threshold)
        {
            reached = false;
        }
    }
}

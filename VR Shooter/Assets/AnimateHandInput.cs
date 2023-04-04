using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AnimateHandInput : MonoBehaviour
{

    public InputActionProperty PinchAnimationAction;

    public InputActionProperty GripAnimationAction;
    public Animator HandAnimator; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float triggervalue = PinchAnimationAction.action.ReadValue<float>();
        HandAnimator.SetFloat("Trigger",triggervalue);
        // Debug.Log(triggervalue); 
        float gripvalue = GripAnimationAction.action.ReadValue<float>();
        HandAnimator.SetFloat("Grip",gripvalue);

    }
}

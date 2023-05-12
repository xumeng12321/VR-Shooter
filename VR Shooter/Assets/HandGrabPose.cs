using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HandGrabPose : MonoBehaviour
{
    public HandData RightHandPose;

    // Start is called before the first frame update
    void Start()
    { 
     XRGrabInteractable grabInteractable = GetComponent<XRGrabInteractable>();
     grabInteractable.selectEntered.AddListener(SetupPose);
     RightHandPose.gameObject.SetActive(false);
    }

    public void SetupPose(BaseInteractionEventArgs args)
    {
        if(args.interactorObject is XRDirectInteractor)
        {
            HandData handData = args.interactorObject.transform.GetComponentInChildren<HandData>();
            handData.Animator.enabled = false;

        }
    }
    
}

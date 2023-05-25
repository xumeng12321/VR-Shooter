using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HandGrabPose : MonoBehaviour
{
    public HandData RightHandPose;
    private Vector3 StartHandPos;
    private Vector3 EndHandPos;
    private Quaternion StartHandRot;
    private Quaternion EndHandRot;
    
    private Quaternion[] StartFingerRot;
    private Quaternion[] EndFingerRot;

    // private Vector3[] StartFingerPos;
    // private Vector3[] EndFingerPos;

    // Start is called before the first frame update
    void Start()
    { 
     XRGrabInteractable grabInteractable = GetComponent<XRGrabInteractable>();
     grabInteractable.selectEntered.AddListener(SetupPose);
     grabInteractable.selectExited.AddListener(UnSetPose);

     RightHandPose.gameObject.SetActive(false);
    }

    public void SetupPose(BaseInteractionEventArgs args)
    {
        if(args.interactorObject is XRDirectInteractor)
        {
            HandData handData = args.interactorObject.transform.GetComponentInChildren<HandData>();
            handData.Animator.enabled = false;

            SetHandDataValue(handData, RightHandPose);
            SetHandData(handData, EndHandPos, EndHandRot, EndFingerRot);
        }
    }

    public void UnSetPose(BaseInteractionEventArgs args)
    {
        if(args.interactorObject is XRDirectInteractor)
        {
            HandData handData = args.interactorObject.transform.GetComponentInChildren<HandData>();
            handData.Animator.enabled = true;

            SetHandData(handData, StartHandPos, StartHandRot, StartFingerRot);
        }
    }
    
    
    public void SetHandDataValue(HandData h1, HandData h2)
    {
        StartHandPos = new Vector3(h1.Root.localPosition.x/ h1.Root.localScale.x,
            h1.Root.localPosition.y/ h1.Root.localScale.y,
            h1.Root.localPosition.z/ h1.Root.localScale.z);

        EndHandPos = new Vector3(h2.Root.localPosition.x/ h2.Root.localScale.x,
            h2.Root.localPosition.y/ h2.Root.localScale.y,
            h2.Root.localPosition.z/ h2.Root.localScale.z);

        StartHandRot = h1.Root.localRotation;
        EndHandRot = h2.Root.localRotation;

        StartFingerRot = new Quaternion[h1.fingerBones.Length];
        EndFingerRot = new Quaternion[h2.fingerBones.Length];

        for (int i = 0; i < h1.fingerBones.Length; i++)
        {
            StartFingerRot[i] = h1.fingerBones[i].localRotation;
            // StartFingerPos[i] = h1.fingerBones[i].localPosition;
            EndFingerRot[i] = h2.fingerBones[i].localRotation;
            // EndFingerPos[i] = h2.fingerBones[i].localPosition;
        }
    }

    public void SetHandData(HandData h, Vector3 newpos, Quaternion newrot, Quaternion[] newbonerot)
    {
        h.Root.localPosition = newpos;
        h.Root.localRotation = newrot;
        for (int i = 0; i < h.fingerBones.Length; i++)
        {
            StartFingerRot[i] = newbonerot[i];
            // StartFingerPos[i] = newbonepos[i];
        }
    }
}

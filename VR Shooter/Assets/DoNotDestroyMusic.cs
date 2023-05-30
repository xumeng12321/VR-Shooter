using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoNotDestroyMusic : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Awake()
    {
        GameObject[] musicobj = GameObject.FindGameObjectsWithTag("Music");
        if (musicobj.Length > 1)
        {
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
        }
    }

}

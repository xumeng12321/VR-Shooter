// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class FallingObjects : MonoBehaviour
// {
//     // Start is called before the first frame update
//     void Start()
//     {
//         StartCoroutine(WaitForFalling());
//     }

//     IEnumerator WaitForFalling()
//     {
//         yield return new WaitForSeconds(10);
//         GameObject[] fallingObjects = GameObject.FindGameObjectsWithTag("fallingObjects");
        
//         foreach (GameObject falling in fallingObjects)
//         {
//             Rigidbody rb = falling.GetComponent<Rigidbody>();
//             rb.isKinematic = true;
//             rb.detectCollisions = false;
//         }

//     }
// }

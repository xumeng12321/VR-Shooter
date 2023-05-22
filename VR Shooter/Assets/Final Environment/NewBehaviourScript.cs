using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject[] myObjects;
   
    void Update(){
        //for(int i = 0; i < 50, i++){
            int rand = Random.Range(0, myObjects.Length);
            Vector3 randomSpawnPosition = new Vector3(Random.Range(-10,11),5,Random.Range(-10,11));
            Instantiate(myObjects[rand],randomSpawnPosition,Quaternion.identity);
       // }

    }
}

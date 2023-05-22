using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    public GameObject[] myObjects;
    public GameObject[] myContainers;
    public GameObject npc;
    public int counter1, counter2, countContainer;
   
    void Update(){
        if(counter1 < 250){
            int rand = Random.Range(0, myObjects.Length);
            Vector3 randomSpawnPosition = new Vector3(Random.Range(-10,11),5,Random.Range(-10,11));
            Instantiate(myObjects[rand],randomSpawnPosition,Quaternion.identity);
            counter1++;
        }
        if(countContainer < 25){
            int rand = Random.Range(0, myContainers.Length);
            Vector3 randomSpawnPosition = new Vector3(Random.Range(-10,11),5,Random.Range(-10,11));
            Instantiate(myContainers[rand],randomSpawnPosition,Quaternion.identity);
            countContainer++;
        }
        if(counter1 >= 250 && counter2 < 100){
            int rand = Random.Range(0, myObjects.Length);
            Vector3 randomSpawnPosition = new Vector3(Random.Range(-10,11),5,Random.Range(-10,11));
            Instantiate(npc,randomSpawnPosition,Quaternion.identity);
            counter2++;
        }
    }
}

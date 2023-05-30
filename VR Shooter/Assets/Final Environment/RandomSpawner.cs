using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    public GameObject[] myObjects;
    public GameObject[] myContainers;
    public GameObject npc;
    public float Planesize;
    private int counter1, countContainer;
    public int NumObject, NumContainer;
   
    void Update(){
        if(counter1 < NumObject){
            int rand = Random.Range(0, myObjects.Length);
            Vector3 randomSpawnPosition = new Vector3(Random.Range(-Planesize,Planesize),3,Random.Range(-Planesize,Planesize));
            Instantiate(myObjects[rand],randomSpawnPosition,Quaternion.identity);
            counter1++;
        }
        if(countContainer < NumContainer){
            int rand = Random.Range(0, myContainers.Length);
            Vector3 randomSpawnPosition = new Vector3(Random.Range(-Planesize,Planesize),3,Random.Range(-Planesize,Planesize));
            Instantiate(myContainers[rand],randomSpawnPosition,Quaternion.identity);
            countContainer++;
        }
        // if(counter1 >= 10 && counter2 < 10){
        //     int rand = Random.Range(0, myObjects.Length);
        //     Vector3 randomSpawnPosition = new Vector3(Random.Range(-Planesize,Planesize),5,Random.Range(-Planesize,Planesize));
        //     Instantiate(npc,randomSpawnPosition,Quaternion.identity);
        //     counter2++;
        // }
    }
}

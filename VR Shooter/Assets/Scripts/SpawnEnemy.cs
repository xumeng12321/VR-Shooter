using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] Spawners;
    public GameObject Enemy;
    private int WaveNumber;
    public int EnemyLeft = 20;
    public int EnemyPerWave = 2 ;
    public int EnemyKilled;

    void Start()
    {
        Spawners = new GameObject[5];
        
        for(int i =0; i < Spawners.Length; i++) 
        {
            Spawners[i] = transform.GetChild(i).gameObject;
        }
        StartWave();
    }
    void Update()
    {
        // if(Input.GetKeyDown(KeyCode.L)) Spawn();
        if(EnemyKilled >= EnemyPerWave)
        {
            NextWave();
        }
    }

    private void Spawn()
    {
        int spawnerID = Random.Range(0,Spawners.Length); 
        Instantiate(Enemy,Spawners[spawnerID].transform.position, Spawners[spawnerID].transform.rotation);
        EnemyLeft--;
    }

    private void StartWave()
    {
        WaveNumber = 1;
        EnemyKilled = 0;
        for (int i = 0; i < EnemyPerWave; i++)
        {
            Spawn();
            
        }
    }

    public void NextWave()
    {
        WaveNumber++;
        EnemyPerWave += 4;
        EnemyKilled = 0;
        for (int i = 0; i < EnemyPerWave; i++)
        {
            if(EnemyLeft > 0) Spawn();
        }
    }
}

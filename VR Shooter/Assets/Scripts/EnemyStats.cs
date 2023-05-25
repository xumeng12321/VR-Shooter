using UnityEngine;

public class EnemyStats : CharacterStats
{
    GameController gameController;
    SpawnEnemy Spawn;

    private int Score = 1;
    public override void Die()
    {
        // base.Die();
        gameController.AddScore(Score);       //<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<change to bullet hit
        
        Spawn.EnemyKilled++;
        Destroy(gameObject,2);
        
    }
    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        Spawn = gameController.GetComponentInChildren<SpawnEnemy>();
        maxHP = 100;
        currHP = maxHP;

    }

    // Update is called once per frame
    void Update()
    {
        CheckHP();
    }
}

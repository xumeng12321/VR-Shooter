using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public int EnemyNumber;

    [SerializeField] public TMPro.TMP_Text Score;
    [SerializeField] public GameOver gameOver;
    [SerializeField] public MissionComplete missionComplete;

    

    // Start is called before the first frame update
    void Start()
    {
        EnemyNumber = GetComponentInChildren<SpawnEnemy>().EnemyLeft;
        UpdateScoreUI();
    }

    // Update is called once per frame

    void Update()
    {
        if (EnemyNumber == 0)
        {
            MissionCompleteDisplay();
        } 
    }

    public void AddScore(int Score)
    {
        EnemyNumber -= Score;
        UpdateScoreUI();
    }

    private void UpdateScoreUI()
    {
        Score.text = EnemyNumber.ToString(); 
    }

    public void GameOverDisplay() 
    {
        gameOver.Setup();
    }

    public void MissionCompleteDisplay() 
    {
        missionComplete.Setup();
    }
}

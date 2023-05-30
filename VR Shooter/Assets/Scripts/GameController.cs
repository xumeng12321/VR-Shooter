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

    

    // Start is called before the first frame update
    void Start()
    {
        EnemyNumber = GetComponentInChildren<SpawnEnemy>().EnemyLeft;
        UpdateScoreUI();
    }

    // Update is called once per frame



    public void AddScore(int Score)
    {
        EnemyNumber -= Score;
        UpdateScoreUI();
    }

    private void UpdateScoreUI()
    {
        Score.text = EnemyNumber.ToString(); 
    }

    public void ReloadScene() 
    {
        SceneManager.LoadScene(1);
    }
}

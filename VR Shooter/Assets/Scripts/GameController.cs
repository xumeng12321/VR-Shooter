using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public int currScore = 0;

    [SerializeField] public TMPro.TMP_Text Score;

    // Start is called before the first frame update
    void Start()
    {
        currScore = 0;
        UpdateScoreUI();
    }

    // Update is called once per frame
    // void Update()
    // {
        
    // }


    public void AddScore(int Score)
    {
        currScore += Score;
        UpdateScoreUI();
    }

    private void UpdateScoreUI()
    {
        Score.text = currScore.ToString(); 
    }

    public void ReloadScene() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

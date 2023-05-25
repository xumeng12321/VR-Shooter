using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHUD : MonoBehaviour
{
    [SerializeField] public TMPro.TMP_Text currentHealthText;
    [SerializeField] public TMPro.TMP_Text maxHealthText;
    public void UpdateHP(int currentHealth, int maxHealth)
    {
        currentHealthText.text = currentHealth.ToString();
        maxHealthText.text = maxHealth.ToString();
        // Debug.Log(currentHealth.ToString().GetType());
    }
    // public void test(int currentHealth, int maxHealth)
    // {
    //     int test;
    //     test = currentHealth + maxHealth;
    //     Debug.Log(test);
    // }
}

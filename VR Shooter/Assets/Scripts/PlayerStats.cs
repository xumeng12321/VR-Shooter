using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharacterStats 
{
    // Start is called before the first frame update
    private PlayerHUD hud;
    GameController gameController;

    void Start()
    {
        hud = GetComponent<PlayerHUD>(); 
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        InitVariables();  
        // Debug.Log(maxHP);
    }
    
    public override void CheckHP()
    {
        base.CheckHP();
        hud.UpdateHP(currHP,maxHP);
        // hud.test(currHP,maxHP);
        // Debug.Log(maxHP);
    }

    // void Update()
    // {
    //     if(Input.GetKeyDown(KeyCode.L))
    //     {
    //         Takedmg(10);
    //         Debug.Log(currHP);
    //     }
    // }
    

    public override void Die()
    {
        Debug.Log("Died");
        gameController.ReloadScene();
    }
}

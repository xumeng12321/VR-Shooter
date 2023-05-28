using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerStats : CharacterStats 
{
    // Start is called before the first frame update
    private PlayerHUD hud;
    GameController gameController;

    public Image DamageOverlay;
    public float duration;
    public float fadespeed;

    private float durationTimer;

    void Start()
    {
        hud = GetComponent<PlayerHUD>(); 
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        InitVariables();  
        DamageOverlay.color = new Color(DamageOverlay.color.r,DamageOverlay.color.g,DamageOverlay.color.b,0);
        // Debug.Log(maxHP);
    }
    
    void Update()
    {
        if(DamageOverlay.color.a > 0)
        {
            durationTimer += Time.deltaTime;
            if (durationTimer > duration)
            {
                float tempAlpha = DamageOverlay.color.a ;
                tempAlpha -= Time.deltaTime * fadespeed;
                DamageOverlay.color = new Color(DamageOverlay.color.r,DamageOverlay.color.g,DamageOverlay.color.b,tempAlpha);
            }
        }
        
    }
    public override void CheckHP()
    {
        base.CheckHP();
        hud.UpdateHP(currHP,maxHP);
        // hud.test(currHP,maxHP);
        // Debug.Log(maxHP);
    }
    public override void Takedmg(int dmg)
    {
        base.Takedmg(dmg);
        durationTimer = 0;
        DamageOverlay.color = new Color(DamageOverlay.color.r,DamageOverlay.color.g,DamageOverlay.color.b,1);
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

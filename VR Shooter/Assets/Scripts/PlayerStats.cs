using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : CharacterStats 
{
    // Start is called before the first frame update
    private PlayerHUD hud;
    GameController gameController;
    public Image DamageOverlay;
    public float Duration;
    public float FadeSpeed;
    
    private float DurationTimer;
    void Start()
    {
        hud = GetComponent<PlayerHUD>(); 
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        InitVariables();  
        DurationTimer = 0;
        DamageOverlay.color = new Color(DamageOverlay.color.r,DamageOverlay.color.g,DamageOverlay.color.b,0);

        // Debug.Log(maxHP);
    }
    
    void Update()
    {
        if(DamageOverlay.color.a > 0)
        {
            DurationTimer += Time.deltaTime;
            if(DurationTimer > Duration)
            {
                float tempAlpha = DamageOverlay.color.a;
                tempAlpha -= Time.deltaTime * FadeSpeed;
                DamageOverlay.color = new Color(DamageOverlay.color.r,DamageOverlay.color.g,DamageOverlay.color.b,tempAlpha);
            }
        }

    }

    public override void Takedmg(int dmg)
    {
        base.Takedmg(dmg);
        DamageOverlay.color = new Color(DamageOverlay.color.r,DamageOverlay.color.g,DamageOverlay.color.b,1);
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

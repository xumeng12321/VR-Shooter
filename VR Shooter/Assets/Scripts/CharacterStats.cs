using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]public int currHP;
    [SerializeField]public int maxHP;

    [SerializeField]public bool isDead = false;


    private void Start()
    {
        InitVariables();
        
    }
    
    public virtual void CheckHP()
    {
        if(currHP >= maxHP)
        {
            currHP = maxHP;
        }

        if(currHP <= 0)
        {
            currHP = 0;
            if(isDead == false) Die();
            isDead = true;
        }
    }

    public virtual void Die()
    {
        
    }

    private void SetHP(int HPSetTo)
    {
        currHP = HPSetTo;
        CheckHP();
    }
    
    public virtual void Takedmg(int dmg)
    {
        int HPAfterDmg = currHP - dmg;
        SetHP(HPAfterDmg); 
        Debug.Log(currHP);
    }

    public void Heal(int heal)
    {
        int HPAfterHeal = currHP - heal;
        SetHP(HPAfterHeal);
    }

    public void InitVariables()
    {
        maxHP = 100;
        SetHP(maxHP);
        // Debug.Log(currHP);
        isDead = false;
    }
}

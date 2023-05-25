using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDamage : MonoBehaviour
{
    // Start is called before the first frame update
    private int Damage;

    public void SetDmg(int dmg)
    {
        Damage = dmg;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Enemy")
        {
            // do damage here, for example:
            collision.gameObject.GetComponent<EnemyStats>().Takedmg(Damage);
            Destroy(this.gameObject);
        }
    }
}

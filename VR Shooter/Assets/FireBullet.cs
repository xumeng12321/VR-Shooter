using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FireBullet : MonoBehaviour
{
    public GameObject Bullet;
    public Transform BulletStartPoint;
    public float BulletSpeed = 20;

    // Start is called before the first frame update
    void Start()
    {
        XRGrabInteractable grabbale = GetComponent<XRGrabInteractable>();
        grabbale.activated.AddListener(TriggerFire);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TriggerFire(ActivateEventArgs args)
    {
        GameObject spawnBullet = Instantiate(Bullet);
        spawnBullet.transform.position = BulletStartPoint.position;
        spawnBullet.GetComponent<Rigidbody>().velocity = BulletStartPoint.forward  * BulletSpeed;
        Destroy(spawnBullet,15); 
    }

}

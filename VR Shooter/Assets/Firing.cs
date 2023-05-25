using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;
using TMPro;

public class Firing : MonoBehaviour
{
    public GameObject Bullet;
    [SerializeField] private InputActionReference ReloadButton;
    public Transform BulletStartPoint;
    public float BulletSpeed = 20;
    // public float FireRate = 1;
    public float TimeBetweenShooting,ShootForce,Reloadtime;
    public int MagazineSize;
    private int BulletLeft,BulletShot; 
    private CharacterController _characterController;

    public GameObject MuzzleFlash;
    public TextMeshProUGUI AmmunitionDisplay;
    
    bool ReadyToShoot,Reloading;
    bool AllowInvoke;

    // Start is called before the first frame update
    void Start()
    {   
        _characterController = GetComponent<CharacterController>();
        BulletLeft = MagazineSize;
        ReadyToShoot = true;        
        Reloading = false;
    }

    // Update is called once per frame
    void Update()
    {
        MyInput();
        if(AmmunitionDisplay != null)
        {
            AmmunitionDisplay.SetText(BulletLeft + "/" + MagazineSize);
        }
        if(MuzzleFlash != null)
        {
            Instantiate(MuzzleFlash,BulletStartPoint.position,Quaternion.identity);
        }
    }

    public void MyInput()
    {
        if(ReadyToShoot && !Reloading && BulletLeft > 0)
        {    
            BulletShot = 0;
            XRGrabInteractable grabbale = GetComponent<XRGrabInteractable>();
            grabbale.activated.AddListener(TriggerFire);
        }    

        // Reloading
        if(!Reloading && BulletLeft < MagazineSize)
        {       
            ReloadButton.action.performed += Reload;
            Debug.Log("Reloading");
        }


        
    }
    public void TriggerFire(ActivateEventArgs args)
    {
        ReadyToShoot = false;

        GameObject spawnBullet = Instantiate(Bullet);
        spawnBullet.transform.position = BulletStartPoint.position;
        spawnBullet.GetComponent<Rigidbody>().velocity = BulletStartPoint.forward  * BulletSpeed;
        spawnBullet.GetComponent<Rigidbody>().AddForce(BulletStartPoint.forward.normalized * ShootForce, ForceMode.Impulse);

        Destroy(spawnBullet,10); 

        BulletShot ++;
        BulletLeft --;

        if(AllowInvoke)
        {
            Invoke("ResetShot",TimeBetweenShooting);
            AllowInvoke = false;           
        }

    }

    private void ResetShot()
    {
        ReadyToShoot = true;
        AllowInvoke = true;

    }

    private void Reload(InputAction.CallbackContext obj)
    {
        Reloading = true;
        Invoke("ReloadFinished",Reloadtime);
    }
    private void ReloadFinished()
    {
        BulletLeft = MagazineSize;
        Reloading = false;
    }

}

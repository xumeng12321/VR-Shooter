﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Nokobot/Modern Guns/Simple Shoot")]
public class SimpleShoot : MonoBehaviour
{
    [Header("Prefab Refrences")]
    public GameObject bulletPrefab;
    public int Damage = 50;
    public GameObject casingPrefab;
    public GameObject muzzleFlashPrefab;

    [Header("Location Refrences")]
    [SerializeField] private Animator gunAnimator;
    [SerializeField] private Transform barrelLocation;
    [SerializeField] private Transform casingExitLocation;

    [Header("Settings")]
    [Tooltip("Specify time to destory the casing object")] [SerializeField] private float destroyTimer = 2f;
    [Tooltip("Bullet Speed")] [SerializeField] private float shotPower = 500f;
    [Tooltip("Casing Ejection Speed")] [SerializeField] private float ejectPower = 150f;
    public TMPro.TextMeshPro Text;

    public AudioSource source;
    public AudioClip FireSound;
    public AudioClip NoAmmo;
    public AudioClip Reloading;

    public int maxAmmo = 8;
    private int currAmmo;

    public int totalAmmo = 40;
    private int ammoLeft;

    void Start()  
    {
        ammoLeft = totalAmmo;
        if (barrelLocation == null)
            barrelLocation = transform;

        if (gunAnimator == null)
            gunAnimator = GetComponentInChildren<Animator>();
    }

    public void PullTrigger()
    {
        //Calls animation on the gun that has the relevant animation events that will fire
        if(currAmmo > 0)
        {
            gunAnimator.SetTrigger("Fire");
    
        }
        else
        {
            source.PlayOneShot(NoAmmo);
        }
        
    }

    void Reload()
    {
        if(ammoLeft > maxAmmo)
        {
            currAmmo = maxAmmo;
            Debug.Log("currAmmo = maxAmmo");
            Debug.Log(currAmmo);
        }
        else
        {
            currAmmo = ammoLeft;
            Debug.Log("currAmmo = ammoLeft");
            Debug.Log(currAmmo);
        }
        ammoLeft = totalAmmo - currAmmo;
        Debug.Log("ammoLeft = totalAmmo - currAmmo");
        Debug.Log(ammoLeft);
        source.PlayOneShot(Reloading);
    
    }

    void Update()
    {
        if(Vector3.Angle(transform.up, Vector3.up) > 100 && currAmmo < maxAmmo)
        {
            Reload();
        }

        Text.text = currAmmo.ToString() + " / " + ammoLeft.ToString();
    }

    //This function creates the bullet behavior
    void Shoot()
    {
        currAmmo--;
        totalAmmo--;
        source.PlayOneShot(FireSound);
                
        if (muzzleFlashPrefab)
        {
            //Create the muzzle flash
            GameObject tempFlash;
            tempFlash = Instantiate(muzzleFlashPrefab, barrelLocation.position, barrelLocation.rotation);

            //Destroy the muzzle flash effect
            Destroy(tempFlash, destroyTimer);
        }

        //cancels if there's no bullet prefeb
        if (!bulletPrefab)
        { return; }

        // Create a bullet and add force on it in direction of the barrel and set damage
        GameObject bullet = Instantiate(bulletPrefab, barrelLocation.position, barrelLocation.rotation);
        bullet.GetComponent<DealDamage>().SetDmg(Damage);
        bullet.GetComponent<Rigidbody>().AddForce(barrelLocation.forward * shotPower);
        
    }

    //This function creates a casing at the ejection slot
    void CasingRelease()
    {
        //Cancels function if ejection slot hasn't been set or there's no casing
        if (!casingExitLocation || !casingPrefab)
        { return; }

        //Create the casing
        GameObject tempCasing;
        tempCasing = Instantiate(casingPrefab, casingExitLocation.position, casingExitLocation.rotation) as GameObject;
        //Add force on casing to push it out
        tempCasing.GetComponent<Rigidbody>().AddExplosionForce(Random.Range(ejectPower * 0.7f, ejectPower), (casingExitLocation.position - casingExitLocation.right * 0.3f - casingExitLocation.up * 0.6f), 1f);
        //Add torque to make casing spin in random direction
        tempCasing.GetComponent<Rigidbody>().AddTorque(new Vector3(0, Random.Range(100f, 500f), Random.Range(100f, 1000f)), ForceMode.Impulse);

        //Destroy casing after X seconds
        Destroy(tempCasing, destroyTimer);
    }

}

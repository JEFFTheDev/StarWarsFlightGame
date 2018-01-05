using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{

    public Vector3 targetLocation;
    public Transform originLocation;
    public GameObject laserPrefab;

    public float distance = 1500;

    public float fireRate = .5f;

    private bool isFiring = false;

    public Transform target;

    private float fireRateTimeStamp;

    private void Update()
    {
        if (isFiring)
        {
            Fire();
        }
    }

    void Fire()
    {
        if (CanFire())
        {
            GameObject laser = GameObject.Instantiate(laserPrefab);
            laser.transform.position = originLocation.transform.position;


            if (target == null)
            {
                targetLocation = transform.position + transform.forward * distance;
            }
            else
            {
                targetLocation = target.transform.position;
            }
            laser.transform.LookAt(targetLocation);

            laser.AddComponent<LaserProjectile>().target = targetLocation;
        }
    }

    bool CanFire()
    {
        if (Time.time >= fireRateTimeStamp)
        {
            fireRateTimeStamp = Time.time + fireRate;
            Debug.Log("Can fire");
            return true;
        }

        return false;
    }

    public void EnableFire()
    {
        isFiring = true;
        Fire();
    }

    public void DisableFire()
    {
        isFiring = false;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlightController : Controller {

   
    public float rotateStrength = 1.0f;
    public float normalSpeed;
    public float maxSpeed = 10.0f;
    public ParticleSystem speedParticle;
    public GameObject targetingReticle;
    public Transform aimPoint;

    private GameObject target;

    private float currentSpeed;

    private bool locking;

    private void Start()
    {

        NormalSpeed();

        speedParticle.enableEmission = false;
    }

    private void Update()
    {

        transform.Rotate((Vector3.right * z * rotateStrength) + (Vector3.up * x * rotateStrength));

        transform.Translate(Vector3.forward * Time.deltaTime * currentSpeed);

        if (locking)
        {
            Lock();
        }
    }

    public void Lock() {
        
        targetingReticle.transform.Rotate(0,0,-3);

        //Refactor to function

        if (target != null) { 
        Vector3 screenPointTarget = Camera.main.WorldToViewportPoint(target.transform.position);
        bool targetOnScreen = screenPointTarget.z > 0.25 && screenPointTarget.x > 0.25 && screenPointTarget.x < 0.75 && screenPointTarget.y > 0.25 && screenPointTarget.y < 0.75;

        if (!targetOnScreen){
            target = null;
        }

        }

        foreach (GameObject child in GameObject.FindGameObjectsWithTag("Actor"))
        {

            Debug.Log(child.name);

            Vector3 screenPoint = Camera.main.WorldToViewportPoint(child.transform.position);
            bool onScreen = screenPoint.z > 0.25 && screenPoint.x > 0.25 && screenPoint.x < 0.75 && screenPoint.y > 0.25 && screenPoint.y < 0.75;

            if (onScreen)
            {
                target = child;
            }
            else
            {
                target = aimPoint.gameObject;
            }
            
            targetingReticle.transform.position = Camera.main.WorldToScreenPoint(target.transform.position);
        }
    }

    public void SetLock() {
        locking = !locking;
        targetingReticle.SetActive(!targetingReticle.activeSelf);
    }

    public void Boost()
    {
        speedParticle.enableEmission = true;
        currentSpeed = maxSpeed;
    }

    public void NormalSpeed()
    {
        speedParticle.enableEmission = false;
        currentSpeed = normalSpeed;
    }

    public override void TouchUpOnScreen(Vector2 position)
    {
        base.TouchUpOnScreen(position);
        NormalSpeed();
    }

    public override void TouchDownOnScreen(Vector2 position)
    {
        base.TouchDownOnScreen(position);
        Boost();
    }
}
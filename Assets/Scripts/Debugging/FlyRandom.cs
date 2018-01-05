using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyRandom : MonoBehaviour {

    public bool forward;
    public bool around;
    public float speed = 10.0f;
    public GameObject target;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (forward)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        else if (around)
        {
           transform.RotateAround(target.transform.position, target.transform.position, speed * Time.deltaTime);
        }
	}
}

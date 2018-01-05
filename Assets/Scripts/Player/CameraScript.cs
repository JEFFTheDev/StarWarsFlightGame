using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

    public Transform target;
    public float rotationSpeed;
    public float height;
    public float positionSpeed;
    public float distance;
    public Vector3 positionOffset;
    public Quaternion rotationOffset;

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
 

       
    }

    private void LateUpdate()
    {

        Vector3 position = target.TransformPoint(0,height,-distance);
        transform.position = Vector3.Lerp(transform.position, position, Time.deltaTime * positionSpeed) + positionOffset;

        Quaternion rotation = Quaternion.LookRotation(target.position - transform.position, target.up);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rotationSpeed);

    }
}

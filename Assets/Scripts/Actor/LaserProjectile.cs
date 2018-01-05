using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserProjectile : MonoBehaviour {

    public Vector3 target;
    private float speed = 500.0f;
    private float damage = 40;

    private void Start()
    {
        Destroy(this.gameObject, 5);
    }

	// Update is called once per frame
	void Update () {
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        transform.LookAt(target);
	}

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);

        if(other.tag.Equals("Actor"))
        {
            other.GetComponent<Actor>().AddHealth(-damage);
            Destroy(this.gameObject);
        }
    }
}

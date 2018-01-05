using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor : MonoBehaviour {

    [SerializeField]
    private float health = 100;

    [SerializeField]
    private GameObject onDestroyFX;

    public void AddHealth(float health)
    {
        this.health += health;

        if(this.health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        GameObject explosionFX = Instantiate(onDestroyFX, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}

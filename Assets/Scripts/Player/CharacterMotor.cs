using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMotor : MonoBehaviour {

    public Transform center;
    public float degreesPerSecond = -65.0f;
    private bool turnedDirection = false;
    private float directionModifier = 1;
    private Vector3 direction = Vector3.forward;
    public float maxAngle = 10;

    [SerializeField]
    private bool startOpposite = false;

    private Vector3 v;

    void Start()
    {
        if (startOpposite)
        {
            directionModifier *= -1;
        }

        v = transform.position - center.position;
    }

    void Update()
    {
        UpdateLegMovement();
        UpdateArmMovement();
        UpdateBodyMovement();
    }

    void UpdateLegMovement()
    {
        Vector3 newPos = transform.position;

        if ((newPos + v).y > center.position.y - maxAngle && !turnedDirection)
        {
            directionModifier *= -1;

            turnedDirection = true;
        }
        
        v = Quaternion.AngleAxis(degreesPerSecond * Time.deltaTime, direction * directionModifier ) * v;
        
        newPos = center.position + v;

        transform.position = newPos;

        turnedDirection = false;
    }

    void UpdateArmMovement()
    {

    }

    void UpdateBodyMovement()
    {

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour{

    protected float x;
    protected float z;
    
    public virtual void TouchDownOnScreen(Vector2 position)
    {
        Debug.Log("Touched down on screen...");
    }

    public virtual void TouchUpOnScreen(Vector2 position)
    {
        Debug.Log("Touched up on screen...");
    }

    public virtual void TouchHoldOnScreen(Vector2 position)
    {
        Debug.Log("Dragging on screen...");
    }

    public void UpdateInput(Vector3 input)
    {
        this.x = input.x;
        this.z = input.z;
    }

    public void ResetInput()
    {
        this.x = 0;
        this.z = 0;
    }
}

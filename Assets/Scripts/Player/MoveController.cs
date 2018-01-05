using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveController : Controller {

    [SerializeField]
    private float moveStrength = 1;

    [SerializeField]
    private RectTransform cursor;

    public Text t;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += new Vector3(x,0,z) * moveStrength;
	}

    public override void TouchHoldOnScreen(Vector2 position)
    {
        base.TouchHoldOnScreen(position);

        t.text = position.ToString();

        cursor.position = position;
    }
}
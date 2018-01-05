using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour {

    public GUIBehaviour gui;
    public ParticleSystem hyperSpaceEffect;


    private void Awake()
    {
        
    }

    // Use this for initialization
    void Start () {
        gui.EnableOrDisableUIElements(false);
	}
	
	// Update is called once per frame
	void Update () {
        if (!hyperSpaceEffect.isEmitting)
        {
            hyperSpaceEffect.gameObject.transform.SetParent(null);
            gui.EnableOrDisableUIElements(true);
            gui.FadeIn();
            Destroy(this);
        }
	}


}

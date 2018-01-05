using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    private GameObject camera;
    private float y;

	// Use this for initialization
	void Start () {
        camera = Camera.main.gameObject;
        y = camera.transform.rotation.y;
	}
	
	// Update is called once per frame
	void Update () {
        y += 0.05f;
        camera.transform.rotation = Quaternion.Euler(camera.transform.rotation.x, y, camera.transform.rotation.z);
	}

    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}

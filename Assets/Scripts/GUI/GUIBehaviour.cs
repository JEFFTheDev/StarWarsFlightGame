using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIBehaviour : MonoBehaviour {

    private Graphic[] uiElements;

    [SerializeField]
    private bool isEnabled;

	// Use this for initialization
	void Awake () {
        uiElements = GetComponentsInChildren<Graphic>();
	}

   void Start()
    {
        EnableOrDisableUIElements(isEnabled);
        StartCoroutine(FadeInUI());
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void FadeIn()
    {
        StartCoroutine(FadeInUI());
    }

    public void EnableOrDisableUIElements(bool enable)
    {
        foreach (Graphic uiElement in uiElements)
        {
            uiElement.CrossFadeAlpha(0,0,false);
            uiElement.enabled = enable;
        }
    }

    public IEnumerator FadeInUI()
    {

        foreach (Graphic uiElement in uiElements)
        {
            uiElement.CrossFadeAlpha(1, 1.5f, true);

            yield return new WaitForEndOfFrame();
        }
    }

}

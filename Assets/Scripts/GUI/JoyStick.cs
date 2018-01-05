using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class JoyStick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler {

    [SerializeField]
    private Controller controller;
    private Image backgroundImage;
    private Image joyStickImage;
    private Vector3 inputVector;

    private int boostTouchId;

    private void Start()
    {
        backgroundImage = GetComponent<Image>();
        joyStickImage = transform.GetChild(0).GetComponent<Image>();

    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            foreach (Touch touch in Input.touches)
            {
                bool checkUI = CheckIfTouchIsOnUI(touch);

                if (touch.phase == TouchPhase.Began && touch.position.x > Screen.width / 2 && !checkUI)
                {
                    controller.TouchDownOnScreen(touch.position);
                    boostTouchId = touch.fingerId;
                    //flightController.Boost();
                }

                else if (touch.phase == TouchPhase.Ended && touch.fingerId == boostTouchId)
                {
                    controller.TouchUpOnScreen(touch.position);
                    //flightController.NormalSpeed();
                }
                else if (touch.phase == TouchPhase.Moved && !checkUI)
                {
                    controller.TouchHoldOnScreen(touch.position); 
                }

            }
        }

      
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 pos;

        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(backgroundImage.rectTransform, eventData.position, eventData.pressEventCamera, out pos)) {

            pos.x = (pos.x / backgroundImage.rectTransform.sizeDelta.x);
            pos.y = (pos.y / backgroundImage.rectTransform.sizeDelta.y);

            inputVector = new Vector3(pos.x * 2+ 1, 0, pos.y * 2 -1);

            inputVector = (inputVector.magnitude > 1.0f) ? inputVector.normalized : inputVector;

            joyStickImage.rectTransform.anchoredPosition = new Vector3(inputVector.x * (backgroundImage.rectTransform.sizeDelta.x/2), inputVector.z * (backgroundImage.rectTransform.sizeDelta.y / 2));

            controller.UpdateInput(inputVector);
            //flightController.UpdateInput(inputVector.x, inputVector.z);
        }
    }

    public virtual void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public virtual void OnPointerUp(PointerEventData eventData)
    {
        inputVector = Vector3.zero;
        joyStickImage.rectTransform.anchoredPosition = Vector3.zero;
        //flightController.Stop();
        controller.ResetInput();
    }

    bool CheckIfTouchIsOnUI(Touch t)
    {

        bool onUI = false;

        PointerEventData pointerData = new PointerEventData(EventSystem.current);

        pointerData.position = t.position;

        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointerData, results);

        

        if (results.Count > 0)
        {

            if (results[0].gameObject.layer == LayerMask.NameToLayer("UI"))
            {
                onUI = true;
            }
        }

        return onUI;
    }      
}

      

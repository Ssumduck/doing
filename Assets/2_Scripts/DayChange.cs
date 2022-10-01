using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DayChange : MonoBehaviour
{
    public CustomButton button;

    private bool isMouseDown = false;
    private Vector2 startPos;

    void Awake()
    {
        button.AddOnPointDownUp(OnPointerDown, OnPointerUp);
    }

    void Update()
    {
        if(isMouseDown)
        {
            if (Input.mousePosition.x - startPos.x > 1)
            {
                UIMain.Instance.ChangeDate(true);
                isMouseDown = false;
            }
            else if (Input.mousePosition.x - startPos.x < -1)
            {
                UIMain.Instance.ChangeDate(false);
                isMouseDown = false;
            }
        }
    }

    public void OnPointerDown(CustomButton btn)
    {
        isMouseDown = true;
        startPos = Input.mousePosition;
    }

    public void OnPointerUp(CustomButton btn)
    {
        isMouseDown = false;
    }
}

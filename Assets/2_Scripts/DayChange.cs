using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DayChange : MonoBehaviour, IPointerDownHandler
{
    public Button button;

    void Awake()
    {
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.scrollDelta.x > 1)
            UIMain.Instance.ChangeDate(true);
        else if (eventData.scrollDelta.x < -1)
            UIMain.Instance.ChangeDate(false);
    }
}

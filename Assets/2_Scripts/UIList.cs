using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIList : MonoBehaviour
{
    public MemoUI memoObj;
    [SerializeField] CalendarUI calendarUI;
    [HideInInspector] public int year, month, day;

    public void MemoActive(bool _isActive)
    {
        memoObj.gameObject.SetActive(_isActive);

        if(_isActive)
        {
            memoObj.Init();
        }
        calendarUI.Refresh();
    }

    public void Refresh()
    {
        calendarUI.Refresh();
    }
}

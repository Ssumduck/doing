using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMain : MonoBehaviour
{
    #region Singleton
    static UIMain instance;
    public static UIMain Instance { get { if (instance == null) instance = GameObject.FindObjectOfType<UIMain>(); return instance; } }
    #endregion

    public CustomButton btnList;
    public CustomButton btnToday;
    public CustomButton btnPlus;
    public CustomButton btnMore;

    public CustomButton btnEdit;

    public Text txtDate;
    public Transform tfToDoList;

    private DateTime selectDate; 
    
    private void Awake()
    {
        btnList.AddOnPointClick(OnClickList);
        btnToday.AddOnPointClick(OnClickToday);
        btnPlus.AddOnPointClick(OnClickPlus);
        btnMore.AddOnPointClick(OnClickMore);

        btnEdit.AddOnPointClick(OnClickEdit);

        selectDate = DateTime.Today;

        Refresh();
    }

    public void Refresh()
    {
        txtDate.text = string.Format("{0}/{1} {2}", selectDate.Month, selectDate.Day, selectDate.DayOfWeek);
    }

    void OnClickList(CustomButton btn)
    {
        Main.Instance.OpenListUI(true);
    }

    void OnClickToday(CustomButton btn)
    {
        if(!DateTime.Equals(selectDate.Date, DateTime.Today))
        {
            selectDate = DateTime.Today;

            Refresh();
        }
    }

    void OnClickPlus(CustomButton btn)
    {
        Main.Instance.OpenEditUI(true);
    }

    void OnClickMore(CustomButton btn)
    {

    }

    void OnClickEdit(CustomButton btn)
    {
    }
}

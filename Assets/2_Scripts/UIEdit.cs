using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIEdit : MonoBehaviour
{
    #region Singleton
    static UIEdit instance;
    public static UIEdit Instance { get { if (instance == null) instance = FindObjectOfType<UIEdit>(); return instance; } }
    #endregion

    public CustomButton btnClose;
    public Text txtDate;
    public InputField inputTodo;
    public GameObject isRepeatSelected;
    public CustomButton btnRepeat;

    public CustomButton[] repeatTypeBtns;

    public GameObject objRepeatOptions;
    public GameObject objWeekdays;

    public CustomButton[] weekdayBtns;

    public CustomButton btnSave;

    public ToDo newToDo = new ToDo();

    private bool isRepeat = false;

    private void Awake()
    {
        btnClose.AddOnPointClick(OnClickClose);
        btnSave.AddOnPointClick(OnClickSave);
        btnRepeat.AddOnPointClick(OnClickRepeat);

        for(int i = 0; i < repeatTypeBtns.Length; i++)
            repeatTypeBtns[i].AddOnPointClick(btn => SelectRepeatType((RepeatType)i+1));

        InitSet();
    }

    void InitSet()
    {
        newToDo = new ToDo();
        newToDo.date = UIMain.Instance.selectDate;
        txtDate.text = string.Format("{0}/{1}/{2}", newToDo.date.Year, newToDo.date.Month, newToDo.date.Day);
        inputTodo.text = "";

        objRepeatOptions.SetActive(false);
        objWeekdays.SetActive(false);
    }

    void OnClickRepeat(CustomButton btn)
    {
        isRepeat = !isRepeat;
        objRepeatOptions.SetActive(isRepeat);
        isRepeatSelected.SetActive(isRepeat);
    }

    void OnClickClose(CustomButton btn)
    {
        Main.Instance.OpenEditUI(false);
    }

    void OnClickSave(CustomButton btn)
    {
        UserData.Instance.AddToDo(newToDo);
        UIMain.Instance.Refresh();
        Main.Instance.OpenEditUI(false);
    }

    void SelectRepeatType(RepeatType type)
    {
        for(int i = 0; i < repeatTypeBtns.Length; i++)
        {
            repeatTypeBtns[i].transform.GetChild(1).gameObject.SetActive(i + 1 == (int)type);
            newToDo.repeatType = type;
        }
    }
}


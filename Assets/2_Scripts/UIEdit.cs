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


        for (int i = 0; i < weekdayBtns.Length; i++)
        {
            int idx = i;
            weekdayBtns[i].AddOnPointClick(btn => SelectRepeatWeekdays((DayOfWeek)idx));
        }

        for (int i = 0; i < repeatTypeBtns.Length; i++)
        {
            int idx = i;
            repeatTypeBtns[i].AddOnPointClick(btn => SelectRepeatType((RepeatType)(idx + 1)));
        }

        InitSet();
    }

    public void InitSet()
    {
        newToDo = new ToDo();
        newToDo.date = UIMain.Instance.selectDate;
        txtDate.text = string.Format("{0}/{1}/{2}", newToDo.date.Year, newToDo.date.Month, newToDo.date.Day);
        inputTodo.text = "";

        isRepeatSelected.SetActive(false);
        objRepeatOptions.SetActive(false);
        objWeekdays.SetActive(false);

        repeatTypeBtns[0].transform.GetChild(1).gameObject.SetActive(true);

        for (int i = 1; i < repeatTypeBtns.Length; i++)
            repeatTypeBtns[i].transform.GetChild(1).gameObject.SetActive(false);

        for (int i = 0; i < weekdayBtns.Length; i++)
            weekdayBtns[i].transform.GetChild(0).gameObject.SetActive(false);
    }

    void OnClickRepeat(CustomButton btn)
    {
        isRepeat = !isRepeat;
        objRepeatOptions.SetActive(isRepeat);
        isRepeatSelected.SetActive(isRepeat);

        if (isRepeat)
        {
            newToDo.repeatType = RepeatType.daily;
            repeatTypeBtns[0].transform.GetChild(1).gameObject.SetActive(true);

            for (int i = 1; i < repeatTypeBtns.Length; i++)
                repeatTypeBtns[i].transform.GetChild(1).gameObject.SetActive(false);

            for (int i = 0; i < weekdayBtns.Length; i++)
                weekdayBtns[i].transform.GetChild(0).gameObject.SetActive(false);
        }
        else
        {
            objWeekdays.SetActive(false);
            newToDo.repeatType = RepeatType.none;
            newToDo.repeatDays.Clear();
        }
    }

    void OnClickClose(CustomButton btn)
    {
        Main.Instance.OpenEditUI(false);
    }

    void OnClickSave(CustomButton btn)
    {
        newToDo.todo = inputTodo.text;

        UserData.Instance.AddToDo(newToDo);
        UIMain.Instance.Refresh();
        UserData.Instance.ToDoSave();
        Main.Instance.OpenEditUI(false);
    }

    void SelectRepeatType(RepeatType type)
    {
        for (int i = 0; i < repeatTypeBtns.Length; i++)
        {
            repeatTypeBtns[i].transform.GetChild(1).gameObject.SetActive((i + 1) == (int)type);
            newToDo.repeatType = type;
        }

        objWeekdays.SetActive(type == RepeatType.custom);
    }

    void SelectRepeatWeekdays(DayOfWeek day)
    {
        if (newToDo.repeatDays.Contains(day))
            newToDo.repeatDays.Remove(day);
        else
            newToDo.repeatDays.Add(day);

        weekdayBtns[(int)day].transform.GetChild(0).gameObject.SetActive(newToDo.repeatDays.Contains(day));
    }
}


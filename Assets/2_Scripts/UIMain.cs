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

    public DateTime selectDate { get; set; }

    public GameObject toDoItemPrefab;

    private List<ToDo> selDayToDos;
    private List<ToDoListItem> selDayToDoItems = new List<ToDoListItem>();
    
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

        selDayToDos = UserData.Instance.GetToDo(selectDate);

        foreach (var item in selDayToDoItems)
            item.gameObject.SetActive(false);

        for(int i = 0; i < selDayToDos.Count; i++)
        {
            if (selDayToDoItems.Count <= i)
                selDayToDoItems.Add(Instantiate(toDoItemPrefab, tfToDoList).GetComponent<ToDoListItem>());

            selDayToDoItems[i].gameObject.SetActive(true);
            selDayToDoItems[i].InitsetToDoInfo(selDayToDos[i]);
        }
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

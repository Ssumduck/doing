using System;
using UnityEngine;
using UnityEngine.UI;

public class DayListItem : MonoBehaviour
{
    [SerializeField] Text dayTxt;
    [SerializeField] CustomButton dayBtn;
    [SerializeField] GameObject checkObj;
    [SerializeField] GameObject memoObj;

    public bool IsCheck { get { return UserData.dateTime.Equals(new DateTime(year, month, day)); } } // 메모창이 켜져있는지
    public bool HasMemo { get { return false; } } // 메모가 있는지


    int year;
    int month;
    int day;

    private void Start()
    {
        dayBtn.AddOnPointClick(OnTouch);
    }

    public void Init(int year, int month, int day)
    {
        dayTxt.text = day.ToString();
        this.year = year;
        this.month = month;
        this.day = day;
        Refresh();
    }

    public void Refresh()
    {
        checkObj.SetActive(IsCheck);
        memoObj.SetActive(HasMemo);
    }

    public void OnTouch(CustomButton _btn)
    {
        UserData.dateTime = new System.DateTime(year, month, day);
        Main.Instance.uiList.MemoActive(true);
        checkObj.SetActive(IsCheck);
        memoObj.SetActive(HasMemo);
    }
}

using System;
using UnityEngine;
using UnityEngine.UI;

public class DayListItem : MonoBehaviour
{
    [SerializeField] Text dayTxt;
    [SerializeField] CustomButton dayBtn;
    [SerializeField] GameObject checkObj;
    [SerializeField] GameObject memoObj;

    DateTime dateTime;

    public bool IsCheck { get { return UserData.dateTime.Equals(dateTime); } } // 메모창이 켜져있는지
    public bool HasMemo { get { return UserData.Instance.dicMemo.ContainsKey(dateTime); } } // 메모가 있는지

    private void Start()
    {
        dayBtn.AddOnPointClick(OnTouch);
    }

    public void Init(int year, int month, int day)
    {
        dayTxt.text = day.ToString();
        dateTime = new DateTime(year, month, day);
        Refresh();
    }

    public void Refresh()
    {
        checkObj.SetActive(IsCheck);
        memoObj.SetActive(HasMemo);
    }

    public void OnTouch(CustomButton _btn)
    {
        UserData.dateTime = dateTime;
        Main.Instance.uiList.MemoActive(true);
        checkObj.SetActive(IsCheck);
        memoObj.SetActive(HasMemo);
    }
}

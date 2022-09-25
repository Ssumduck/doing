using UnityEngine;
using UnityEngine.UI;

public class MemoUI : MonoBehaviour
{
    [SerializeField] CustomButton closeBtn;
    [SerializeField] Text dateTxt;

    int Year;
    int Month;
    int Day;

    private void Awake()
    {
        closeBtn.AddOnPointClick(TouchClose);
    }

    public void Init()
    {
        dateTxt.text = $"{UserData.dateTime.Month}/{UserData.dateTime.Day} ({DefineClass.GetStringSimpleDay(UserData.dateTime.DayOfWeek)})";
    }

    void TouchClose(CustomButton _btn)
    {
        Main.Instance.uiList.MemoActive(false);
    }
}

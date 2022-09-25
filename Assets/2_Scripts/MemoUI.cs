using UnityEngine;
using UnityEngine.UI;

public class MemoUI : MonoBehaviour
{
    [SerializeField] CustomButton closeBtn;
    [SerializeField] Text dateTxt;

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
        UserData.dateTime = new System.DateTime();
        Main.Instance.uiList.MemoActive(false);
    }
}

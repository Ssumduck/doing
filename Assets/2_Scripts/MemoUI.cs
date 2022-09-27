using UnityEngine;
using UnityEngine.UI;

public class MemoUI : MonoBehaviour
{
    [SerializeField] CustomButton closeBtn;
    [SerializeField] Text dateTxt;
    [SerializeField] InputField memoField;

    private void Awake()
    {
        closeBtn.AddOnPointClick(TouchClose);
    }

    public void Init()
    {
        if(UserData.selectedTime.Ticks == UserData.dateTime.Ticks)
        {
            UserData.selectedTime = new System.DateTime();
            TouchClose();
            return;
        }
        UserData.selectedTime = new System.DateTime(UserData.dateTime.Ticks);

        dateTxt.text = $"{UserData.dateTime.Month}/{UserData.dateTime.Day} ({DefineClass.GetStringSimpleDay(UserData.dateTime.DayOfWeek)})";
        if (UserData.Instance.dicMemo.ContainsKey(UserData.dateTime))
        {
            memoField.text = UserData.Instance.dicMemo[UserData.dateTime];
        }
        else
            memoField.text = string.Empty;
    }

    void MemoSave()
    {
        if (!string.IsNullOrEmpty(memoField.text))
        {
            if (UserData.Instance.dicMemo.ContainsKey(UserData.dateTime))
            {
                UserData.Instance.dicMemo[UserData.dateTime] = memoField.text;
            }
            else
                UserData.Instance.dicMemo.Add(UserData.dateTime, memoField.text);
        }else
        {
            if (UserData.Instance.dicMemo.ContainsKey(UserData.dateTime))
                UserData.Instance.dicMemo.Remove(UserData.dateTime);
        }
        UserData.Instance.MemoSave();
    }

    void TouchClose(CustomButton _btn = null)
    {
        MemoSave();
        UserData.dateTime = new System.DateTime();
        Main.Instance.uiList.MemoActive(false);
    }
}

using UnityEngine;
using UnityEngine.UI;

public class DayListItem : MonoBehaviour
{
    [SerializeField] Text dayTxt;
    [SerializeField] CustomButton dayBtn;
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
    }

    public void OnTouch(CustomButton _btn)
    {
        Main.Instance.uiList.MemoActive(true);
    }
}

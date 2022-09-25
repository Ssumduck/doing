using UnityEngine;
using UnityEngine.UI;

public class DayListItem : MonoBehaviour
{
    [SerializeField] Text dayTxt;

    public void Init(int day)
    {
        dayTxt.text = day.ToString();
    }

    public void OnTouch()
    {
    }
}

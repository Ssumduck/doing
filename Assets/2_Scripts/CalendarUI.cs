using System;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class CalendarUI : MonoBehaviour
{
    #region Inspector
    [SerializeField] GameObject containerObj;
    [SerializeField] GameObject listItemPrefab;
    [SerializeField] Text yearTxt;
    [SerializeField] Text monthTxt;
    [SerializeField] CustomButton beforeBtn;
    [SerializeField] CustomButton nextBtn;
    #endregion

    List<DayListItem> Objs = new List<DayListItem>();

    [SerializeField] DateTime time;

    float xStartPos = 60f;
    float yStartPos = 380f;
    float xPadding = 125f;
    float yPadding = 105f;

    void Start()
    {
        beforeBtn.AddOnPointClick(DescMonth);
        nextBtn.AddOnPointClick(IncMonth);
        time = DateTime.Now;
        Init(time);
    }

    public void IncMonth(CustomButton _btn)
    {
        time = time.AddMonths(1);

        Init(time);
    }

    public void DescMonth(CustomButton _btn)
    {
        time = time.AddMonths(-1);

        Init(time);
    }

    public void Refresh()
    {
        for (int i = 0; i < Objs.Count; i++)
        {
            Objs[i].Refresh();
        }
    }

    void Init(DateTime _time)
    {
        Calendar cal = new KoreanCalendar();

        int year = cal.GetYear(_time);
        int month = cal.GetMonth(_time);
        int days = cal.GetDaysInMonth(year, month);
        DayOfWeek startDay = cal.GetDayOfWeek(new DateTime(_time.Year, _time.Month, 1));

        yearTxt.text = _time.Year.ToString();
        monthTxt.text = $"{DefineClass.GetStringMonth(month)}";

        int i = 0;

        float xPos = xStartPos;
        float yPos = yStartPos;

        while (i != (int)startDay)
        {
            xPos += xPadding;
            i++;
        }

        for (int j = 0; j < Objs.Count; j++)
        {
            Objs[j].gameObject.SetActive(false);
        }

        for (int j = 0; j < days; j++, i++)
        {
            if (Objs.Count <= j)
            {
                GameObject obj = Instantiate(listItemPrefab, containerObj.transform);

                Objs.Add(obj.GetComponent<DayListItem>());
            }

            Objs[j].gameObject.SetActive(true);
            Objs[j].GetComponent<RectTransform>().anchoredPosition = new Vector2(xPos, yPos);
            Objs[j].Init(_time.Year, _time.Month, j + 1);

            if (i >= 6)
            {
                xPos = xStartPos;
                yPos = yPos - yPadding;
                i = -1;
            }
            else
                xPos += xPadding;
        }
    }
}

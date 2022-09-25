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
    #endregion

    List<DayListItem> Objs = new List<DayListItem>();

    [SerializeField] DateTime time;

    float xStartPos = 60f;
    float yStartPos = 400f;
    float xPadding = 125f;
    float yPadding = 115f;

    void Start()
    {
        Init(DateTime.Now);
        time = DateTime.Now;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            time = time.AddMonths(1);

            Init(time);
        }
    }

    void Init(DateTime _time)
    {
        Calendar cal = new KoreanCalendar();

        int year = cal.GetYear(_time);
        int month = cal.GetMonth(_time);
        int days = cal.GetDaysInMonth(year, month);
        DayOfWeek startDay = cal.GetDayOfWeek(new DateTime(_time.Year, _time.Month, 1));

        yearTxt.text = _time.Year.ToString() ;
        monthTxt.text = $"{_time.Month.ToString()}월";

        int i = 0;

        float xPos = xStartPos;
        float yPos = yStartPos;

        while(i != (int)startDay)
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

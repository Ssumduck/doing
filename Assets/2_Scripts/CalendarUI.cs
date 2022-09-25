using System;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class CalendarUI : MonoBehaviour
{
    [SerializeField] GameObject containerObj;
    [SerializeField] GameObject listItemPrefab;

    List<GameObject> Objs = new List<GameObject>();

    float xStartPos = 60f;
    float yStartPos = 400f;
    float xPadding = 125f;
    float yPadding = 125f;

    void Start()
    {
        Init(DateTime.Now);
    }

    void Init(DateTime _time)
    {
        Calendar cal = new KoreanCalendar();

        int year = cal.GetYear(_time);
        int month = cal.GetMonth(_time);
        int days = cal.GetDaysInMonth(year, month);
        DayOfWeek startDay = cal.GetDayOfWeek(new DateTime(_time.Year, _time.Month, 1));

        int i = 0;

        float xPos = xStartPos;
        float yPos = yStartPos;

        while(i != (int)startDay)
        {
            xPos += xPadding;
            i++;
        }

        for (int j = 0; j < days; j++, i++)
        {

            GameObject obj = Instantiate(listItemPrefab, containerObj.transform);

            obj.GetComponent<RectTransform>().anchoredPosition = new Vector2(xPos, yPos);

            Objs.Add(obj);

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

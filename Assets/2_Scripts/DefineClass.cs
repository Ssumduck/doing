using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public enum SaveType
{
    None = 0,
    Memo = 1, // 1. 메모
}

public class DefineClass
{
    public static string GetStringMonth(int months)
    {
        switch (months)
        {
            case 1:
                return "January";
            case 2:
                return "February";
            case 3:
                return "March";
            case 4:
                return "April";
            case 5:
                return "May";
            case 6:
                return "June";
            case 7:
                return "July";
            case 8:
                return "August";
            case 9:
                return "September";
            case 10:
                return "October";
            case 11:
                return "November";
            case 12:
                return "December";
        }
        return string.Empty;
    }

    public static string GetStringSimpleDay(DayOfWeek dayOfWeek)
    {
        switch (dayOfWeek)
        {
            case DayOfWeek.Friday:
                return "Fri";
            case DayOfWeek.Monday:
                return "Mon";
            case DayOfWeek.Saturday:
                return "Sat";
            case DayOfWeek.Sunday:
                return "Sun";
            case DayOfWeek.Thursday:
                return "Thu";
            case DayOfWeek.Tuesday:
                return "Tue";
            case DayOfWeek.Wednesday:
                return "Wed";
        }
        return string.Empty;
    }

    public static string GetSaveTypeFileName(SaveType _type)
    {
        switch (_type)
        {
            case SaveType.Memo:
                return "dicMemo";
        }
        return string.Empty;
    }

    public static string FilePath(string _fileName)
    {
        if(Application.platform == RuntimePlatform.IPhonePlayer)
        {
            string path = Application.dataPath.Substring(0, Application.dataPath.Length - 5);
            path = path.Substring(0, path.LastIndexOf('/'));
            return Path.Combine(Path.Combine(path, "Documents"), _fileName);
        }else if(Application.platform == RuntimePlatform.Android){
            string path = Application.persistentDataPath;
            path = path.Substring(0, path.LastIndexOf('/'));
            return Path.Combine(path, _fileName);
        }
        else
        {
            string path = Application.dataPath;
            path = path.Substring(0, path.LastIndexOf('/'));
            return Path.Combine(path, _fileName);
        }
    }

    public static string FilePath(SaveType _type)
    {
        string _fileName = GetSaveTypeFileName(_type);
        if (Application.platform == RuntimePlatform.IPhonePlayer)
        {
            string path = Application.dataPath.Substring(0, Application.dataPath.Length - 5);
            path = path.Substring(0, path.LastIndexOf('/'));
            return Path.Combine(Path.Combine(path, "Documents"), _fileName);
        }
        else if (Application.platform == RuntimePlatform.Android)
        {
            string path = Application.persistentDataPath;
            path = path.Substring(0, path.LastIndexOf('/'));
            return Path.Combine(path, _fileName);
        }
        else
        {
            string path = Application.dataPath;
            path = path.Substring(0, path.LastIndexOf('/'));
            return Path.Combine(path, _fileName);
        }
    }

    public static void WriteStringToFile(string _str, string _fileName)
    {
        string path = FilePath(_fileName);
        FileStream file = new FileStream(path, FileMode.Create, FileAccess.Write);

        StreamWriter sw = new StreamWriter(file);
        sw.WriteLine(_str);

        sw.Close();
        file.Close();
    }

    public static void WriteStringToFile(string _str, SaveType _type)
    {
        string path = FilePath(_type);
        FileStream file = new FileStream(path, FileMode.Create, FileAccess.Write);

        StreamWriter sw = new StreamWriter(file);
        sw.WriteLine(_str);

        sw.Close();
        file.Close();
    }

    public static string ReadStringFromFile(string _fileName)
    {
        string path = FilePath(_fileName);

        if(File.Exists(path))
        {
            FileStream file = new FileStream(path, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(file);

            string str = null;
            str = sr.ReadLine();

            sr.Close();
            file.Close();

            return str;
        }
        return null;
    }

    public static string ReadStringFromFile(SaveType _type)
    {
        string path = FilePath(_type);

        if (File.Exists(path))
        {
            FileStream file = new FileStream(path, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(file);

            string str = null;
            str = sr.ReadLine();

            sr.Close();
            file.Close();

            return str;
        }
        return null;
    }
}

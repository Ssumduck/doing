using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System.Linq;

public class UserData
{
    static UserData instance;
    public static UserData Instance
    {
        get
        {
            if (instance == null)
                instance = new UserData();
            return instance;
        }
    }

    //UserData()
    //{
    //    // 초기화
    //    if (PlayerPrefs.HasKey(JsonKey.MemoKey))
    //    {
    //        string json = PlayerPrefs.GetString(JsonKey.MemoKey);

    //        json = Main.Instance.memoLoad.text;

    //        dicMemo = JsonConvert.DeserializeObject<Dictionary<DateTime, string>>(json);
    //    }
    //}

    UserData()
    {
        // 초기화
        if (DefineClass.ReadStringFromFile(SaveType.Memo) != null)
        {
            string json = DefineClass.ReadStringFromFile(SaveType.Memo);
            Debug.Log($"jsonLoad : {json}");
            dicMemo = JsonConvert.DeserializeObject<Dictionary<DateTime, string>>(json);
        }
        else
        {
#if UNITY_EDITOR
            Debug.LogError("dicMemo is null !!");
#endif
        }

        // ToDo 리스트 로드
        if (DefineClass.ReadStringFromFile(SaveType.ToDo) != null)
        {
            string json = DefineClass.ReadStringFromFile(SaveType.ToDo);
            Debug.Log($"Todo Lst Load : {json}");
            //ltToDo = JsonConvert.DeserializeObject<Dictionary<DateTime, List<ToDo>>>(json);
        }
        else
        {
            Debug.LogError("ToDo lst Json is null!");
        }
    }

    public void MemoSave()
    {
        string json = JsonConvert.SerializeObject(dicMemo);
        DefineClass.WriteStringToFile(json, SaveType.Memo);
    }

    public void ToDoSave()
    {
        string json = JsonConvert.SerializeObject(ltToDo);
        DefineClass.WriteStringToFile(json, SaveType.ToDo);
    }

    //public void MemoSave()
    //{
    //    string json = JsonConvert.SerializeObject(dicMemo);
    //    PlayerPrefs.SetString(JsonKey.MemoKey, json);
    //}

    public void AddToDo(ToDo toDoData)
    {
        ltToDo.Add(toDoData);
    }

    public List<ToDo> GetToDo(DateTime date)
    {
        return ltToDo.Where(todo => todo.isToDoOfDay(date)).ToList();
    }

    public List<ToDo> ltToDo = new List<ToDo>();
    public Dictionary<DateTime, string> dicMemo = new Dictionary<DateTime, string>();

    #region Memo
    public static DateTime dateTime = new DateTime();
    public static DateTime selectedTime = new DateTime();
    #endregion
}
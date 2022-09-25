using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIEdit : MonoBehaviour
{
    #region Singleton
    static UIEdit instance;
    public static UIEdit Instance { get { if (instance == null) instance = FindObjectOfType<UIEdit>(); return instance; } }
    #endregion

    public CustomButton btnClose;
    public Text txtDate;
    public Text txtTodo;
    public CustomButton btnRepeat;

    public CustomButton btnDaily;
    public CustomButton btnWeekly;
    public CustomButton btnMonthly;
    public CustomButton btnCustom;

    public GameObject objRepeatOptions;
    public GameObject objWeekdays;

    public CustomButton btnSave;



}


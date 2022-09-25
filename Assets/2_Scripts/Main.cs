using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    #region Singleton
    static Main instance;
    public static Main Instance { get { if (instance == null) instance = GameObject.FindObjectOfType<Main>(); return instance; } }
    #endregion
    public UIMain uiMain;
    public UIList uiList;
    public UIEdit uiEdit;

    public void OpenListUI(bool isOpen)
    {
        uiList.gameObject.SetActive(isOpen);
    }

    public void OpenEditUI(bool isOpen)
    {
        uiEdit.gameObject.SetActive(isOpen);
    }
}

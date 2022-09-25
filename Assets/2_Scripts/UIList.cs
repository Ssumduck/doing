using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIList : MonoBehaviour
{
    public MemoUI memoObj;
    [HideInInspector] public int year, month, day;

    public void MemoActive(bool _isActive)
    {
        memoObj.gameObject.SetActive(_isActive);

        if(_isActive)
        {
            memoObj.Init();
        }
    }
}

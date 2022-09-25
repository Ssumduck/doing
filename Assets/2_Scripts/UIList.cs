using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIList : MonoBehaviour
{
    public GameObject memoObj;

    public void MemoActive(bool _isActive)
    {
        memoObj.SetActive(_isActive);
    }
}

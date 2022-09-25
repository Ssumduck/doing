using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoUI : MonoBehaviour
{
    [SerializeField] CustomButton closeBtn;

    private void Awake()
    {
        closeBtn.AddOnPointClick(TouchClose);
    }

    void TouchClose(CustomButton _btn)
    {
        Main.Instance.uiList.MemoActive(false);
    }
}

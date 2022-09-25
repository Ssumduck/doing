using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMain : MonoBehaviour
{
    public CustomButton btnList;
    public CustomButton btnToday;
    public CustomButton btnPlus;
    public CustomButton btnMore;

    public CustomButton btnEdit;

    public Text txtDate;
    public Transform tfToDoList;

    private void Awake()
    {
        btnList.AddOnPointClick(OnClickList);
        btnToday.AddOnPointClick(OnClickToday);
        btnPlus.AddOnPointClick(OnClickPlus);
        btnMore.AddOnPointClick(OnClickMore);

        btnEdit.AddOnPointClick(OnClickEdit);
    }

    void OnClickList(CustomButton btn)
    {
        
    }

    void OnClickToday(CustomButton btn)
    {

    }

    void OnClickPlus(CustomButton btn)
    {

    }

    void OnClickMore(CustomButton btn)
    {

    }

    void OnClickEdit(CustomButton btn)
    {

    }
}

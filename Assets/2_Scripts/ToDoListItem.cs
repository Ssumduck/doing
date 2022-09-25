using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToDoListItem : MonoBehaviour
{
    public InputField inputToDo;
    public Text txtToDo;
    public CustomButton btnCheck;
    public GameObject imgRemove;
    public GameObject imgComplete;
    public CustomButton btnMove;

    bool isEditMode = false;
    bool isCompleted = false;

    public void SetEditMode(bool _isEditMode)
    {
        isEditMode = _isEditMode;

        if(_isEditMode)
        {
            inputToDo.interactable = true;

            btnCheck.gameObject.SetActive(false);

            txtToDo.color = Color.gray;

            imgRemove.SetActive(true);
            imgComplete.SetActive(false);

            btnMove.gameObject.SetActive(true);
        }
        else
        {
            inputToDo.interactable = false;

            btnCheck.gameObject.SetActive(true);

            txtToDo.color = Color.black;

            imgRemove.SetActive(false);
            imgComplete.SetActive(true);

            btnMove.gameObject.SetActive(false);
        }
    }

    void OnClickCheck(CustomButton btn)
    {
        if(isEditMode)
        {
            
            Destroy(this.gameObject);
        }
        else
        {
            isCompleted = !isCompleted;
        }
    }

    void OnClickMove(CustomButton btn)
    {

    }
}

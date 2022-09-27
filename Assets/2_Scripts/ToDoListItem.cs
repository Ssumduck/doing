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

    private bool isEditMode = false;
    private bool isCompleted = false;
    private ToDo todoData;

    private void Awake()
    {
        btnCheck.AddOnPointClick(OnClickCheck);
        btnMove.AddOnPointClick(OnClickMove);
    }

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
            imgComplete.SetActive(todoData.isToDoDone(UIMain.Instance.selectDate));

            btnMove.gameObject.SetActive(false);
        }
    }

    public void InitsetToDoInfo(ToDo _todoData)
    {
        todoData = _todoData;

        txtToDo.text = todoData.todo;
        isCompleted = todoData.isToDoDone(UIMain.Instance.selectDate);
        imgComplete.gameObject.SetActive(true);

        SetEditMode(false);
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
            UIMain.Instance.Refresh();
        }
    }

    void OnClickMove(CustomButton btn)
    {

    }
}

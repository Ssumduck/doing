using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MovingObj : MonoBehaviour, IPointerDownHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] GameObject moveObj;
    GraphicRaycaster gr;
    float dragStartTime = 0.5f;
    bool m_bDrag;

    private void Start()
    {
        gr = Main.Instance.GetComponent<GraphicRaycaster>();
    }

    void Update()
    {
        if (m_bDrag)
        {
            dragStartTime -= Time.deltaTime;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        List<RaycastResult> results = new List<RaycastResult>();
        gr.Raycast(eventData, results);

        for (int i = 0; i < results.Count; i++)
        {
            if (results[i].gameObject.GetComponent<MovingObj>() != null)
            {
                m_bDrag = true;
            }
        }
    }

    bool bTr = false;
    int sortIdx = 0;

    public void OnDrag(PointerEventData eventData)
    {
        if (dragStartTime > 0f)
            return;

        if(!bTr)
        {
            sortIdx = moveObj.transform.GetSiblingIndex();
    
            bTr = true;
        }
        moveObj.transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        List<RaycastResult> results = new List<RaycastResult>();
        gr.Raycast(eventData, results);

        for (int i = 0; i < results.Count; i++)
        {
            if(results[i].gameObject.name.Contains("bg"))
            {
                if (results[i].gameObject.transform.parent.parent == Main.Instance.uiMain.tfToDoList)
                {
                    if(eventData.position.y > results[i].gameObject.transform.position.y)
                        sortIdx = results[i].gameObject.transform.parent.GetSiblingIndex();
                    else
                        sortIdx = results[i].gameObject.transform.parent.GetSiblingIndex() + 1;
                }
            }
        }

        m_bDrag = false;
        dragStartTime = 0.5f;
        bTr = false;
        moveObj.transform.SetParent(Main.Instance.uiMain.tfToDoList);
        moveObj.transform.SetSiblingIndex(sortIdx);
    }
}

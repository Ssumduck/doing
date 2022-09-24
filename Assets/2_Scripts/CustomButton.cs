using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

#if UNITY_EDITOR
[CustomEditor(typeof(CustomButton))]
public class CustomButtonEditor : UnityEditor.UI.ButtonEditor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        EditorGUILayout.Space();
        EditorGUILayout.LabelField("[Sound Option]");
        CustomButton component = (CustomButton)target;
        component.soundIdx = (int)EditorGUILayout.IntField("Sound Index", component.soundIdx);

        EditorGUILayout.Space();
        EditorGUILayout.LabelField("[Tween Option]");
        component.useTween = EditorGUILayout.Toggle("Use Tween", component.useTween);
        component.tweenObject = (GameObject)EditorGUILayout.ObjectField("Tween Transform", component.gameObject, typeof(Transform), true);
        component.tweenTime = EditorGUILayout.FloatField("Tween Time", component.tweenTime);
        component.tweenScaleUp = EditorGUILayout.Vector3Field("Tween Scale Up", component.tweenScaleUp);
        component.tweenScaleDown = EditorGUILayout.Vector3Field("Tween Scale Down", component.tweenScaleDown);

        EditorGUILayout.Space();

        if (GUI.changed) EditorUtility.SetDirty(target);
    }
}
#endif

[AddComponentMenu("UI/CustomButton")]
[RequireComponent(typeof(Image))]
public class CustomButton : Button
{
    private Dictionary<EventTriggerType, UnityAction<CustomButton>> eventTriggerTypeDic = new Dictionary<EventTriggerType, UnityAction<CustomButton>>();
    private ScrollRect scrollRectParent;

    [Header("[Sound Setting]")]
    public int soundIdx;

    [Header("[Tween Setting]")]
    public bool useTween = true;
    public GameObject tweenObject;
    public float tweenTime = 0.1f;
    public Vector3 tweenScaleUp = Vector3.one;
    public Vector3 tweenScaleDown = Vector3.one * 0.95f;

    public bool bPossibleScroll = false;

    protected override void Awake()
    {
        if (tweenObject == null) tweenObject = gameObject;
    }

    public override void OnPointerClick(PointerEventData eventData)
    {
        //Debug.LogError("CustomBtn Click");
        if (Input.touchCount >= 2) return;      //???? ???? ???? ???? ??????

        if (scrollRectParent != null && eventData.dragging)
            return;

        if (bPossibleScroll)
        {
            //?????? ???? ?????????? ???????? ???? ????????
            if ((eventData.pressPosition - eventData.position).sqrMagnitude > 50 * 50)
                return;
        }

        base.OnPointerClick(eventData);
        //        InputManager.Instance.SetInputOnLockedArea();
        EventTriggerAction(EventTriggerType.PointerClick);
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        //Debug.LogError("CustomBtn Down");
        if (Input.touchCount >= 2) return;      //???? ???? ???? ???? ??????

        base.OnPointerClick(eventData);

        EventTriggerAction(EventTriggerType.PointerDown);

        if (useTween) iTween.ScaleTo(tweenObject, tweenScaleDown, tweenTime);
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        //Debug.LogError("CustomBtn Up");
        if (Input.touchCount >= 2) return;      //???? ???? ???? ???? ??????

        base.OnPointerClick(eventData);
        EventTriggerAction(EventTriggerType.PointerUp);

        if (useTween) iTween.ScaleTo(tweenObject, tweenScaleUp, tweenTime);
    }

    public void RemoveAllEventTriggerType()
    {
        eventTriggerTypeDic.Clear();
    }

    public void AddEventTriggerType(EventTriggerType eventTriggerType, UnityAction<CustomButton> unityAction)
    {
        eventTriggerTypeDic[eventTriggerType] = unityAction;
    }

    public void AddOnPointClick(UnityAction<CustomButton> clickAction)
    {
        eventTriggerTypeDic[EventTriggerType.PointerClick] = clickAction;

        //        if (soundName == SoundName.None)
        //            soundName = SoundName.icon_tab2;
    }

    public void AddOnPointDownUp(UnityAction<CustomButton> downAction, UnityAction<CustomButton> upAction)
    {
        eventTriggerTypeDic[EventTriggerType.PointerDown] = downAction;
        eventTriggerTypeDic[EventTriggerType.PointerUp] = upAction;
    }

    public void EventTriggerAction(EventTriggerType eventTriggerType)
    {
        if (interactable == false) return;

        if (eventTriggerTypeDic.ContainsKey(eventTriggerType))
        {
            eventTriggerTypeDic[eventTriggerType](this);

            switch (eventTriggerType)
            {
                case EventTriggerType.PointerClick:
                    //if (soundIdx >= 0 && soundIdx < SoundManager.instance.Audio_Clip.Length)
                    //    SoundManager.instance.Sound_One_Play(SoundManager.instance.Audio_Source_Effect, soundIdx);
                    break;
            }
        }
    }
}
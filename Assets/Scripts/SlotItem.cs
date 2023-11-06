using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SlotItem : MonoBehaviour,IBeginDragHandler, IEndDragHandler,IDragHandler
{
    public int SlotID;
    Vector2 initialPosition;
    RectTransform rectTransform;
    MoveTween moveTween;
    public SlotManager slotManager;
    public RectTransform canvasRect;
    public Camera cam;
    private void Awake()
    {
        cam = Camera.main;
        rectTransform = GetComponent<RectTransform>();
        initialPosition = rectTransform.localPosition;
        moveTween = GetComponent<MoveTween>();
        moveTween.movePosition = initialPosition;
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        GetComponent<Image>().raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRect, Input.mousePosition, cam, out Vector2 pos);
        rectTransform.position = canvasRect.TransformPoint(pos);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (eventData.pointerCurrentRaycast.gameObject != null)
        {
           if(eventData.pointerCurrentRaycast.gameObject.GetComponent<Slot>()  != null)
           {
                Slot slot = eventData.pointerCurrentRaycast.gameObject.GetComponent<Slot>();
                if(slot.slotid == SlotID)
                {
                    slot.GetComponent<Image>().sprite = GetComponent<Image>().sprite;
                    slot.GetComponent<Image>().color = Color.white;
                    if (transform.parent.childCount < 2)
                    {
                        slotManager.CallGameEndEvent();
                    }
                    Destroy(this.gameObject);
                    return;
                }
           }
        }
        Debug.Log(eventData.pointerCurrentRaycast.gameObject.transform.name);
        moveTween.MoveIn();
        GetComponent<Image>().raycastTarget = true;
    }
}

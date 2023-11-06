using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public enum MatchOptionSide
{
    left,
    right
}

public class MatchOption : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public MatchOptionSide matchOptionSide;
    public int optionIndex;
    public int connectedOptionIndex;
    public bool isConnected = false;

    public Transform matchLinePosition;
    OptionMatchingManager matchingManager;
    public LineRenderer lineRenderer;
    Camera mainCamera;
    private void Awake()
    {
        matchingManager = GetComponentInParent<OptionMatchingManager>();
        mainCamera = Camera.main;
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.enabled = false;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (isConnected) { return; }
        lineRenderer.enabled = true;
        lineRenderer.SetPosition(0, new Vector2(matchLinePosition.position.x, matchLinePosition.position.y));
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (isConnected) { return; }
        Vector2 worldPoint = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        lineRenderer.SetPosition(1, worldPoint);
        
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (!eventData.pointerCurrentRaycast.gameObject.GetComponent<MatchOption>())
        {
            lineRenderer.SetPosition(0, Vector3.zero);
            lineRenderer.enabled = false;
        }
        else
        {
            MatchOption matchOption = eventData.pointerCurrentRaycast.gameObject.GetComponent<MatchOption>();
            
            if (matchOptionSide == matchOption.matchOptionSide || matchOption.isConnected)
            {
                lineRenderer.SetPosition(0, Vector3.zero);
                lineRenderer.enabled = false;
                return;
            }

            lineRenderer.SetPosition(1, new Vector2(matchOption.matchLinePosition.position.x, matchOption.matchLinePosition.position.y));
            matchOption.isConnected = true;
            isConnected = true;
            connectedOptionIndex = matchOption.optionIndex;
            matchOption.connectedOptionIndex = optionIndex;
        }
        matchingManager.CheckIfAllOptionConnected();
    }
}

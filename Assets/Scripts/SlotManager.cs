using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SlotManager : MonoBehaviour
{
    public UnityEvent onEndGameEvent;

    public void CallGameEndEvent()
    {
        onEndGameEvent?.Invoke();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonDelay : MonoBehaviour
{
    public float delay;
    public bool doOnStart = false;
    Image buttonImage;
    private void Awake()
    {
        buttonImage = GetComponent<Image>();
    }

    private void Start()
    {
        if(doOnStart)
        {
            DoButtonDelay();
        }
    }

    public void DoButtonDelay()
    {
        StartCoroutine(DelayRoutine());
    }

   IEnumerator DelayRoutine()
   {
        yield return new WaitForSeconds(delay);
        buttonImage.enabled = true;
   }
}

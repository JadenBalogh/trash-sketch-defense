using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasGroup))]
public class HUDMenu : MonoBehaviour
{
    private CanvasGroup canvasGroup;
    private bool visible = false;

    private void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void ToggleVisible()
    {
        visible = !visible;
        canvasGroup.alpha = visible ? 1 : 0;
        canvasGroup.blocksRaycasts = visible;
    }
}

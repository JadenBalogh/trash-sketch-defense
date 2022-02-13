using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Indicator : MonoBehaviour
{
    public void Select()
    {
        GameManager.BuildSystem.SelectedIndicator = GetComponent<HUDMenu>();
    }
}

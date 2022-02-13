using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathSystem : MonoBehaviour
{
    [SerializeField] private Transform[] movePoints;

    public Transform GetPosition(int index)
    {
        return index < movePoints.Length ? movePoints[index] : null;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD : MonoBehaviour
{
    private static HUD instance;

    public static HUDMenu BuildPanel { get => instance.buildPanel; }
    [SerializeField] private HUDMenu buildPanel;

    public static HUDMenu LosePanel { get => instance.losePanel; }
    [SerializeField] private HUDMenu losePanel;

    public static HUDMenu WinPanel { get => instance.winPanel; }
    [SerializeField] private HUDMenu winPanel;

    [SerializeField] private Transform errorSpawn;
    [SerializeField] private Transform errorTextPrefab;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }

    public static void SendError() => instance.ISendError();
    public void ISendError()
    {
        Instantiate(errorTextPrefab, errorSpawn.position, Quaternion.identity, transform);
    }
}

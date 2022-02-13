using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildSystem : MonoBehaviour
{
    public HUDMenu SelectedIndicator { get; set; }

    public void BuildTurret(GameObject prefab)
    {
        GameObject obj = Instantiate(prefab, SelectedIndicator.transform.position, Quaternion.identity);
        int cost = obj.GetComponent<Turret>().Cost;
        if (cost > GameManager.ScoreSystem.Gold)
        {
            // we dont have enough gold
            Debug.Log("yo");
            HUD.SendError();
            Destroy(obj);
            return;
        }
        GameManager.ScoreSystem.Gold -= cost;
        SelectedIndicator.ToggleVisible();
        HUD.BuildPanel.ToggleVisible();
    }
}


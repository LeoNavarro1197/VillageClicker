using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlMenus : MonoBehaviour
{
    [SerializeField] private GameObject panelPowerUps;

    private void OnMouseDown()
    {
        if (gameObject.tag == "Ayuntamiento")
        {
            panelPowerUps.SetActive(true);
        }
    }

    public void ClosePanelPowerUps()
    {
        panelPowerUps.SetActive(false);
    }
}

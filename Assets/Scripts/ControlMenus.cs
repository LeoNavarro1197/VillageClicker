using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlMenus : MonoBehaviour
{
    [SerializeField] private GameObject panelPowerUps;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip audioClip;

    private void OnMouseDown()
    {
        audioSource.PlayOneShot(audioSource.clip);

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

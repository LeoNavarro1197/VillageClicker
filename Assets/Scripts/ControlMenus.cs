using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlMenus : MonoBehaviour
{
    [SerializeField] private GameObject panelPowerUps;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip audioClip;

    [SerializeField] private GameObject flecha;

    private void OnMouseDown()
    {
        audioSource.PlayOneShot(audioSource.clip);

        if (gameObject.tag == "Ayuntamiento")
        {
            panelPowerUps.SetActive(true);
            flecha.SetActive(false);
        }
    }

    public void ClosePanelPowerUps()
    {
        panelPowerUps.SetActive(false);
    }
}

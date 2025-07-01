using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockLevels : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [HideInInspector] public bool isLevel1Unlocked, isLevel2Unlocked, isLevel3Unlocked;

    public float targetSizeLevel1, targetSizeLevel2, targetSizeLevel3;
    public float zoomSpeed = 2f;

    [SerializeField] private GameObject ayuntamientoBase, ayuntamientoLevel1, ayuntamientoLevel2, ayuntamientoLevel3;
    [SerializeField] private GameObject aserraderoBase, aserraderoLeven2, aserraderoLevel3;

    // Update is called once per frame
    void Update()
    {
        if (isLevel1Unlocked)
        {
            mainCamera.orthographicSize = Mathf.Lerp(mainCamera.orthographicSize, targetSizeLevel1, zoomSpeed * Time.deltaTime);
            ayuntamientoBase.SetActive(false);
            ayuntamientoLevel1.SetActive(true);
            aserraderoBase.SetActive(false);
            aserraderoLeven2.SetActive(true);
        }

        if (isLevel2Unlocked)
        {
            mainCamera.orthographicSize = Mathf.Lerp(mainCamera.orthographicSize, targetSizeLevel2, zoomSpeed * Time.deltaTime);
            ayuntamientoLevel1.SetActive(false);
            ayuntamientoLevel2.SetActive(true);
            aserraderoLeven2.SetActive(false);
            aserraderoLevel3.SetActive(true);
        }

        if (isLevel3Unlocked)
        {
            mainCamera.orthographicSize = Mathf.Lerp(mainCamera.orthographicSize, targetSizeLevel3, zoomSpeed * Time.deltaTime);
            ayuntamientoLevel2.SetActive(false);
            ayuntamientoLevel3.SetActive(true);
        }
    }
}

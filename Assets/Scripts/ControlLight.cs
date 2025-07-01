using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlLight : MonoBehaviour
{
    public DayNightManager dayNightManager;
    public GameObject lightObject;

    // Update is called once per frame
    void Update()
    {
        if (dayNightManager.isLight)
        {
            lightObject.SetActive(true);
        }
        else if (!dayNightManager.isLight)
        {
            lightObject.SetActive(false);
        }
    }
}

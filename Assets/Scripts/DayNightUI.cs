using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DayNightUI : MonoBehaviour
{
    public TextMeshProUGUI timeText; // UI Text para mostrar tiempo
    private DayNightManager dayNightCycle;

    void Start()
    {
        dayNightCycle = FindObjectOfType<DayNightManager>();

        // Suscribirse a eventos
        dayNightCycle.OnDayStart += () => Debug.Log("UI: Comenzó el día");
        dayNightCycle.OnNightStart += () => Debug.Log("UI: Comenzó la noche");
    }

    void Update()
    {
        if (timeText != null && dayNightCycle != null)
        {
            float timeRemaining = dayNightCycle.GetTimeRemaining();
            int minutes = Mathf.FloorToInt(timeRemaining / 60);
            int seconds = Mathf.FloorToInt(timeRemaining % 60);

            timeText.text = $"{dayNightCycle.GetCurrentPhase()}: {minutes:00}:{seconds:00}";
        }
    }
}

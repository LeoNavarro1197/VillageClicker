using UnityEngine;

public class DayNightManager : MonoBehaviour
{
    [Header("Configuración de Tiempo")]
    public float dayDuration = 300f; // 5 minutos en segundos
    public float nightDuration = 180f; // 3 minutos en segundos

    [Header("Estado Actual")]
    [SerializeField] private bool isDay = true;
    [SerializeField] private float currentTime = 0f;
    [SerializeField] private float transitionSpeed = 2f;

    // Eventos para notificar cambios
    public System.Action OnDayStart;
    public System.Action OnNightStart;

    void Update()
    {
        UpdateTimeOfDay();
    }

    void UpdateTimeOfDay()
    {
        currentTime += Time.deltaTime;

        float currentPhaseDuration = isDay ? dayDuration : nightDuration;

        if (currentTime >= currentPhaseDuration)
        {
            ToggleDayNight();
            currentTime = 0f;
        }
    }

    void ToggleDayNight()
    {
        isDay = !isDay;

        if (isDay)
        {
            // Cambiar a día
            OnDayStart?.Invoke();
            Debug.Log("¡Amanecer! Comenzó el día");
        }
        else
        {
            // Cambiar a noche
            OnNightStart?.Invoke();
            Debug.Log("¡Atardecer! Comenzó la noche");
        }
    }

    // Métodos públicos para control externo
    public void ForceDay()
    {
        isDay = true;
        currentTime = 0f;
        ToggleDayNight();
    }

    public void ForceNight()
    {
        isDay = false;
        currentTime = 0f;
        ToggleDayNight();
    }

    public float GetTimeProgress()
    {
        float currentPhaseDuration = isDay ? dayDuration : nightDuration;
        return currentTime / currentPhaseDuration;
    }

    public string GetCurrentPhase()
    {
        return isDay ? "Día" : "Noche";
    }

    public float GetTimeRemaining()
    {
        float currentPhaseDuration = isDay ? dayDuration : nightDuration;
        return currentPhaseDuration - currentTime;
    }
}

using UnityEngine;

public class DayNightManager : MonoBehaviour
{
    [Header("Configuraci�n de Tiempo")]
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
            // Cambiar a d�a
            OnDayStart?.Invoke();
            Debug.Log("�Amanecer! Comenz� el d�a");
        }
        else
        {
            // Cambiar a noche
            OnNightStart?.Invoke();
            Debug.Log("�Atardecer! Comenz� la noche");
        }
    }

    // M�todos p�blicos para control externo
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
        return isDay ? "D�a" : "Noche";
    }

    public float GetTimeRemaining()
    {
        float currentPhaseDuration = isDay ? dayDuration : nightDuration;
        return currentPhaseDuration - currentTime;
    }
}

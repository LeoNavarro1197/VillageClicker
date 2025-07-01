using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class DayNightManager : MonoBehaviour
{
    [Header("Configuración de Tiempo")]
    public float dayDuration = 300f; // 5 minutos en segundos
    public float nightDuration = 180f; // 3 minutos en segundos

    [Header("Estado Actual")]
    [SerializeField] private bool isDay = true;
    [SerializeField] private float currentTime = 0f;
    [SerializeField] private float transitionSpeed = 2f;

    [Header("Referencias")]
    public Volume globalVolume;

    [Header("Configuración")]
    public float postExposureTarget = 0f;
    public float velocidadCambio = 1f;

    private ColorAdjustments colorAdjustments;

    public bool isLight = false;

    // Eventos para notificar cambios
    public System.Action OnDayStart;
    public System.Action OnNightStart;

    void Start()
    {
        // Obtener el componente ColorAdjustments del Volume
        if (globalVolume != null)
        {
            if (globalVolume.profile.TryGet<ColorAdjustments>(out colorAdjustments))
            {
                Debug.Log("ColorAdjustments encontrado!");
            }
            else
            {
                Debug.LogWarning("No se encontró ColorAdjustments en el Volume Profile");
            }
        }
    }

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
            isLight = false;
            StartCoroutine(CambiarPostExposureSuave(2f, 1f));
            Debug.Log("¡Amanecer! Comenzó el día");
        }
        else
        {
            // Cambiar a noche
            OnNightStart?.Invoke();
            isLight = true;
            StartCoroutine(CambiarPostExposureSuave(-2f, 1f));
            Debug.Log("¡Atardecer! Comenzó la noche");
        }
    }
    System.Collections.IEnumerator CambiarPostExposureSuave(float cambio, float duracion)
    {
        if (colorAdjustments == null) yield break;

        float valorInicial = colorAdjustments.postExposure.value;
        float valorObjetivo = valorInicial + cambio;
        float tiempo = 0f;

        while (tiempo < duracion)
        {
            tiempo += Time.deltaTime;
            float t = tiempo / duracion;

            colorAdjustments.postExposure.value = Mathf.Lerp(valorInicial, valorObjetivo, t);
            yield return null;
        }

        colorAdjustments.postExposure.value = valorObjetivo;
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

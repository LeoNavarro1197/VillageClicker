using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class HumanWood : MonoBehaviour
{
    public AIPath aiPath;
    public Items items;
    [SerializeField] private int automaticClickSecondsWood = 1;
    private bool isArrived = false;
    [SerializeField] private GameObject walkHuman, crunshHuman;

    void Start()
    {
        StartCoroutine(AutomaticClickWood(automaticClickSecondsWood));
    }

    void Update()
    {
        if (aiPath.reachedDestination && !isArrived)
        {
            isArrived = true;
            OnLlegarAlDestino();
        }

        if (!aiPath.reachedDestination)
        {
            isArrived = false;
        }
    }

    private void OnLlegarAlDestino()
    {
        walkHuman.SetActive(false);
        crunshHuman.SetActive(true);
    }

    IEnumerator AutomaticClickWood(float seconds)
    {
        while (true)
        {
            yield return new WaitForSeconds(seconds);
            items.woodScore++;
            UpdateScore();
        }
    }

    public void UpdateScore()
    {
        if (items.woodScoreText != null)
        {
            items.woodScoreText.text = items.itemWoodName + ": " + items.woodScore.ToString();
        }
    }
}

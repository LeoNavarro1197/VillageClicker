using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpAutomaticClick : MonoBehaviour
{
    public List<Clicker> clicker;
    public Items items;
    public UnlockLevels unlockLevels;
    [SerializeField] private int automaticClickSecondsWood, automaticClickSecondsRock;
    private Coroutine autoClickCoroutineWood, autoClickCoroutineRock;
    [SerializeField] private Button buttonAutomaticClickWoodLevel1, buttonAutomaticClickWoodLevel2, buttonAutomaticClickWoodLevel3,
        buttonAutomaticClickRockLevel1, buttonAutomaticClickRockLevel2, buttonAutomaticClickRockLevel3;
    [SerializeField] private List<Button> activeButtonsWood, activeButtonsRock;

    private bool isWoodFinished = false, isRockFinished = false;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip audioClip;

    void Update()
    {
        if(isWoodFinished && isRockFinished)
        {
            unlockLevels.isLevel1Unlocked = true;
        }
    }

    IEnumerator AutomaticClickWood(float seconds)
    {
        while (true)
        {
            for(int i = 0; i < clicker.Count; i++)
            {
                if (clicker[i].isClickedTree)
                {
                    yield return new WaitForSeconds(seconds);
                    items.woodScore++;
                    clicker[i].UpdateScore();
                }
                else
                {
                    yield return null; // Wait for the next frame if nothing is clicked

                }
            }
        }
    }

    IEnumerator AutomaticClickRock(float seconds)
    {
        while (true)
        {
            for (int i = 0; i < clicker.Count; i++)
            {
                if (clicker[i].isClickedRock)
                {
                    yield return new WaitForSeconds(seconds);
                    items.rockScore++;
                    clicker[i].UpdateScore();
                }
                else
                {
                    yield return null; // Wait for the next frame if nothing is clicked

                }
            }
        }
    }

    private void RestartAutomaticClickWood(float newInterval)
    {
        if (autoClickCoroutineWood != null)
        {
            StopCoroutine(autoClickCoroutineWood);
        }

        autoClickCoroutineWood = StartCoroutine(AutomaticClickWood(newInterval));
    }

    private void RestartAutomaticClickRock(float newInterval)
    {
        if (autoClickCoroutineRock != null)
        {
            StopCoroutine(autoClickCoroutineRock);
        }

        autoClickCoroutineRock = StartCoroutine(AutomaticClickRock(newInterval));
    }

    public void AutomaticClickWoodLevel1()
    {
        if (items.woodScore >= 10)
        {
            audioSource.PlayOneShot(audioSource.clip);
            RestartAutomaticClickWood(automaticClickSecondsWood);
            buttonAutomaticClickWoodLevel1.gameObject.SetActive(false);
            buttonAutomaticClickWoodLevel2.gameObject.SetActive(true);
            items.woodScore = items.woodScore - 10;
            items.woodScoreText.text = items.itemWoodName + ": " + items.woodScore.ToString();
        }
    }

    public void AutomaticClickWoodLevel2()
    {
        if (items.woodScore >= 20)
        {
            audioSource.PlayOneShot(audioSource.clip);
            RestartAutomaticClickWood(automaticClickSecondsWood - 5f);
            buttonAutomaticClickWoodLevel2.gameObject.SetActive(false);
            buttonAutomaticClickWoodLevel3.gameObject.SetActive(true);
            items.woodScore = items.woodScore - 20;
            items.woodScoreText.text = items.itemWoodName + ": " + items.woodScore.ToString();
        }
    }

    public void AutomaticClickWoodLevel3()
    {
        if (items.woodScore >= 30)
        {
            audioSource.PlayOneShot(audioSource.clip);
            RestartAutomaticClickWood(automaticClickSecondsWood - 9f);
            items.woodScore = items.woodScore - 30;
            items.woodScoreText.text = items.itemWoodName + ": " + items.woodScore.ToString();
            buttonAutomaticClickWoodLevel3.interactable = false;

            isWoodFinished = true;

            for (int i = 0; i < activeButtonsWood.Count; i++)
            {
                activeButtonsWood[i].interactable = true;
            }
        }
    }

    public void AutomaticClickRockLevel1()
    {
        if (items.rockScore >= 10)
        {
            audioSource.PlayOneShot(audioSource.clip);
            RestartAutomaticClickRock(automaticClickSecondsRock);
            buttonAutomaticClickRockLevel1.gameObject.SetActive(false);
            buttonAutomaticClickRockLevel2.gameObject.SetActive(true);
            items.rockScore = items.rockScore - 10;
            items.rockScoreText.text = items.itemRockName + ": " + items.rockScore.ToString();
        }
    }

    public void AutomaticClickRockLevel2()
    {
        if (items.rockScore >= 20)
        {
            audioSource.PlayOneShot(audioSource.clip);
            RestartAutomaticClickRock(automaticClickSecondsRock - 5f);
            buttonAutomaticClickRockLevel2.gameObject.SetActive(false);
            buttonAutomaticClickRockLevel3.gameObject.SetActive(true);
            items.rockScore = items.rockScore - 20;
            items.rockScoreText.text = items.itemRockName + ": " + items.rockScore.ToString();
        }
    }

    public void AutomaticClickRockLevel3()
    {
        if (items.rockScore >= 30)
        {
            audioSource.PlayOneShot(audioSource.clip);
            RestartAutomaticClickRock(automaticClickSecondsRock - 9f);
            items.rockScore = items.rockScore - 30;
            items.rockScoreText.text = items.itemRockName + ": " + items.rockScore.ToString();
            buttonAutomaticClickRockLevel3.interactable = false;

            isRockFinished = true;

            for (int i = 0; i < activeButtonsRock.Count; i++)
            {
                activeButtonsRock[i].interactable = true;
            }
        }
    }
}

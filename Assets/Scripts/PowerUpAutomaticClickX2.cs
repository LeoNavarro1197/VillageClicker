using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpAutomaticClickX2 : MonoBehaviour
{
    public List<Clicker> clicker;
    public Items items;
    public UnlockLevels unlockLevels;
    [SerializeField] private float automaticClickSecondsWood, automaticClickSecondsRock;
    private Coroutine autoClickCoroutineWood, autoClickCoroutineRock;
    [SerializeField] private Button buttonAutomaticClickWoodLevel1, buttonAutomaticClickWoodLevel2, buttonAutomaticClickWoodLevel3,
        buttonAutomaticClickRockLevel1, buttonAutomaticClickRockLevel2, buttonAutomaticClickRockLevel3;
    [SerializeField] private List<Button> activeButtonsWood, activeButtonsRock;

    private bool isWoodFinished = false, isRockFinished = false;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip audioClip;

    void Update()
    {
        if (isWoodFinished && isRockFinished)
        {
            unlockLevels.isLevel2Unlocked = true;
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

    public void AutomaticClickWoodLevel1X2()
    {
        if (items.woodScore >= 100)
        {
            audioSource.PlayOneShot(audioSource.clip);
            RestartAutomaticClickWood(automaticClickSecondsWood - 9.1f);
            buttonAutomaticClickWoodLevel1.gameObject.SetActive(false);
            buttonAutomaticClickWoodLevel2.gameObject.SetActive(true);
            items.woodScore = items.woodScore - 100;
            items.woodScoreText.text = items.itemWoodName + ": " + items.woodScore.ToString();
        }
    }

    public void AutomaticClickWoodLevel2X2()
    {
        if (items.woodScore >= 200)
        {
            audioSource.PlayOneShot(audioSource.clip);
            RestartAutomaticClickWood(automaticClickSecondsWood - 9.2f);
            buttonAutomaticClickWoodLevel2.gameObject.SetActive(false);
            buttonAutomaticClickWoodLevel3.gameObject.SetActive(true);
            items.woodScore = items.woodScore - 200;
            items.woodScoreText.text = items.itemWoodName + ": " + items.woodScore.ToString();
        }
    }

    public void AutomaticClickWoodLevel3X2()
    {
        if (items.woodScore >= 300)
        {
            audioSource.PlayOneShot(audioSource.clip);
            RestartAutomaticClickWood(automaticClickSecondsWood - 9.3f);
            items.woodScore = items.woodScore - 300;
            items.woodScoreText.text = items.itemWoodName + ": " + items.woodScore.ToString();
            buttonAutomaticClickWoodLevel3.interactable = false;

            isWoodFinished = true;
        }

        for (int i = 0; i < activeButtonsWood.Count; i++)
        {
            activeButtonsWood[i].interactable = true;
        }
    }

    public void AutomaticClickRockLevel1X2()
    {
        if (items.rockScore >= 100)
        {
            audioSource.PlayOneShot(audioSource.clip);
            RestartAutomaticClickRock(automaticClickSecondsRock - 9.1f);
            buttonAutomaticClickRockLevel1.gameObject.SetActive(false);
            buttonAutomaticClickRockLevel2.gameObject.SetActive(true);
            items.rockScore = items.rockScore - 100;
            items.rockScoreText.text = items.itemRockName + ": " + items.rockScore.ToString();
        }
    }

    public void AutomaticClickRockLevel2X2()
    {
        if (items.rockScore >= 200)
        {
            audioSource.PlayOneShot(audioSource.clip);
            RestartAutomaticClickRock(automaticClickSecondsRock - 9.2f);
            buttonAutomaticClickRockLevel2.gameObject.SetActive(false);
            buttonAutomaticClickRockLevel3.gameObject.SetActive(true);
            items.rockScore = items.rockScore - 200;
            items.rockScoreText.text = items.itemRockName + ": " + items.rockScore.ToString();
        }
    }

    public void AutomaticClickRockLevel3X2()
    {
        if (items.rockScore >= 300)
        {
            audioSource.PlayOneShot(audioSource.clip);
            RestartAutomaticClickRock(automaticClickSecondsRock - 9.3f);
            items.rockScore = items.rockScore - 300;
            items.rockScoreText.text = items.itemRockName + ": " + items.rockScore.ToString();
            buttonAutomaticClickRockLevel3.interactable = false;

            isRockFinished = true;
        }

        for (int i = 0; i < activeButtonsRock.Count; i++)
        {
            activeButtonsRock[i].interactable = true;
        }
    }
}

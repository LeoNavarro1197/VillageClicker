using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpAutomaticClickX3 : MonoBehaviour
{
    public List<Clicker> clicker;
    public Items items;
    public UnlockLevels unlockLevels;
    [SerializeField] private float automaticClickSecondsWood, automaticClickSecondsRock;
    private Coroutine autoClickCoroutineWood, autoClickCoroutineRock;
    [SerializeField] private Button buttonAutomaticClickWoodLevel1, buttonAutomaticClickWoodLevel2, buttonAutomaticClickWoodLevel3,
        buttonAutomaticClickRockLevel1, buttonAutomaticClickRockLevel2, buttonAutomaticClickRockLevel3;

    private bool isWoodFinished = false, isRockFinished = false;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip audioClip;

    void Update()
    {
        if (isWoodFinished && isRockFinished)
        {
            unlockLevels.isLevel3Unlocked = true;
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

    public void AutomaticClickWoodLevel1X3()
    {
        if (items.woodScore >= 1000)
        {
            audioSource.PlayOneShot(audioSource.clip);
            RestartAutomaticClickWood(automaticClickSecondsWood - 9.5f);
            buttonAutomaticClickWoodLevel1.gameObject.SetActive(false);
            buttonAutomaticClickWoodLevel2.gameObject.SetActive(true);
            items.woodScore = items.woodScore - 1000;
            items.woodScoreText.text = items.itemWoodName + ": " + items.woodScore.ToString();
        }
    }

    public void AutomaticClickWoodLevel2X3()
    {
        if (items.woodScore >= 2000)
        {
            audioSource.PlayOneShot(audioSource.clip);
            RestartAutomaticClickWood(automaticClickSecondsWood - 9.7f);
            buttonAutomaticClickWoodLevel2.gameObject.SetActive(false);
            buttonAutomaticClickWoodLevel3.gameObject.SetActive(true);
            items.woodScore = items.woodScore - 2000;
            items.woodScoreText.text = items.itemWoodName + ": " + items.woodScore.ToString();
        }
    }

    public void AutomaticClickWoodLevel3X3()
    {
        if (items.woodScore >= 3000)
        {
            audioSource.PlayOneShot(audioSource.clip);
            RestartAutomaticClickWood(automaticClickSecondsWood - 9.9f);
            items.woodScore = items.woodScore - 3000;
            items.woodScoreText.text = items.itemWoodName + ": " + items.woodScore.ToString();
            buttonAutomaticClickWoodLevel3.interactable = false;

            isWoodFinished = true;
        }
    }

    public void AutomaticClickRockLevel1X3()
    {
        if (items.rockScore >= 1000)
        {
            audioSource.PlayOneShot(audioSource.clip);
            RestartAutomaticClickRock(automaticClickSecondsRock - 9.5f);
            buttonAutomaticClickRockLevel1.gameObject.SetActive(false);
            buttonAutomaticClickRockLevel2.gameObject.SetActive(true);
            items.rockScore = items.rockScore - 1000;
            items.rockScoreText.text = items.itemRockName + ": " + items.rockScore.ToString();
        }
    }

    public void AutomaticClickRockLevel2X3()
    {
        if (items.rockScore >= 2000)
        {
            audioSource.PlayOneShot(audioSource.clip);
            RestartAutomaticClickRock(automaticClickSecondsRock - 9.7f);
            buttonAutomaticClickRockLevel2.gameObject.SetActive(false);
            buttonAutomaticClickRockLevel3.gameObject.SetActive(true);
            items.rockScore = items.rockScore - 2000;
            items.rockScoreText.text = items.itemRockName + ": " + items.rockScore.ToString();
        }
    }

    public void AutomaticClickRockLevel3X3()
    {
        if (items.rockScore >= 3000)
        {
            audioSource.PlayOneShot(audioSource.clip);
            RestartAutomaticClickRock(automaticClickSecondsRock - 9.9f);
            items.rockScore = items.rockScore - 3000;
            items.rockScoreText.text = items.itemRockName + ": " + items.rockScore.ToString();
            buttonAutomaticClickRockLevel3.interactable = false;

            isRockFinished = true;
        }
    }
}

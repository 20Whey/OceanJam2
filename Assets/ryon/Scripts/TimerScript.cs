using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
public class TimerScript : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public float startTime = 600; 


    private float currentTime;


    public float difficulty = 5f;
    void Start()
    {
        StartCoroutine(DecreaseDifficultyOverTime());
        currentTime = startTime;
        UpdateTimerText();
    }

    void Update()
    {
        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            currentTime = Mathf.Clamp(currentTime, 0, startTime);
            UpdateTimerText();
        }
        else
        {
            SceneManager.LoadScene("TitleScreen");
            //Debug.Log("Game Over");
        }
    }

    void UpdateTimerText()
    {
        // Calculate minutes and seconds
        int minutes = Mathf.FloorToInt(currentTime / 60);
        int seconds = Mathf.FloorToInt(currentTime % 60);

        // Format the timer text as MM:SS
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    private IEnumerator DecreaseDifficultyOverTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(20); // Wait for 20 seconds
            difficulty -= 0.1f; // Decrease difficulty by 0.1
            difficulty = Mathf.Max(difficulty, 0); // Ensure difficulty doesn't go below 0
            Debug.Log("Difficulty decreased to: " + difficulty);
        }
    }
}

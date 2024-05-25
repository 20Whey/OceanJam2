using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    public TextMeshProUGUI timerText; // Reference to the Text component to display the timer
    public float startTime = 600; // Starting time in seconds (10 minutes)


    private float currentTime;


    public float difficulty = 5f;
    void Start()
    {
        // Initialize the current time
        currentTime = startTime;
        UpdateTimerText();
    }

    void Update()
    {
        if (currentTime > 0)
        {
            // Decrease the current time
            currentTime -= Time.deltaTime;

            // Clamp the current time to ensure it doesn't go below 0
            currentTime = Mathf.Clamp(currentTime, 0, startTime);

            // Update the timer text
            UpdateTimerText();
        }
        else
        {
            Debug.Log("Game Over");
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
}

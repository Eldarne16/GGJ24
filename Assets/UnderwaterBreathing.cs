using UnityEngine;
using UnityEngine.UI;

public class UnderwaterBreathing : MonoBehaviour
{
    public Image breathingBar;
    public float maxBreathingTime = 60.0f; // Adjust the maximum breathing time as needed
    public float currentBreathingTime;
    public float decreaseRate = 2.0f; // Adjust the rate at which the bar decreases

    private void Start()
    {
        currentBreathingTime = maxBreathingTime;
    }

    private void Update()
    {
        // Decrease the current breathing time over time
        currentBreathingTime -= decreaseRate * Time.deltaTime;

        // Clamp the breathing time to ensure it doesn't go below zero
        currentBreathingTime = Mathf.Clamp(currentBreathingTime, 0f, maxBreathingTime);

        // Update the UI breathing bar fill amount
        UpdateBreathingBar();

        // Check if the player is out of breath
        if (currentBreathingTime <= 0f)
        {
            // Add your logic here for what happens when the player runs out of breath
            Debug.Log("Out of breath!");
            Infos.instance.GetHandler<SceneHandler>().NextLevel(false);
        }
    }

    private void UpdateBreathingBar()
    {
        // Calculate the fill amount for the breathing bar based on currentBreathingTime
        float fillAmount = currentBreathingTime / maxBreathingTime;

        // Update the UI Image's fillAmount property to reflect the current breathing status
        breathingBar.fillAmount = fillAmount;
    }
}

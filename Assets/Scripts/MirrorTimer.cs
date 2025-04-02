using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimerScript : MonoBehaviour
{
    public float timeLeft;
    public float startTime;
    public bool TimerOn = false;

    public Canvas mirrorSwapCanvas;

    public TMP_Text TimerTxt;
   
    void Start()
    {
        TimerOn = false;
        startTime = timeLeft;
    }

    void Update()
    {
        if(TimerOn)
        {
            
            if(timeLeft > 0)
            {
                timeLeft -= Time.deltaTime;
                updateTimer(timeLeft);
                mirrorSwapCanvas.gameObject.SetActive(true); // Activate canvas
            }
            else
            {
                Debug.Log("Time is UP!");
                timeLeft = 0;
                TimerOn = false;
            }
        }
        else 
        {
            timeLeft = startTime; // Reset when TimerOn is false
            mirrorSwapCanvas.gameObject.SetActive(false);
        }
    }

    void updateTimer(float currentTime)
    {
        currentTime += 1;

        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        TimerTxt.text = string.Format("{00}",seconds);
    }

}

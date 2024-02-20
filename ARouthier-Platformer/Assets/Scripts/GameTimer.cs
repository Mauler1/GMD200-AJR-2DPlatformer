using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameTimer : MonoBehaviour
{

        private float timer = 0.00f;
        [SerializeField] private TextMeshProUGUI timerText;


    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.resetTimer(); // calls the reset timer from gamemanager to make the timer 0, and calling on start so it resets every time the level scene is loaded
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime; // increase time
        timerText.text = TimerFormat(timer); // sets the screen timer with formatted visuals
        GameManager.Instance.setTimer(timer); // updates the gamemanager timer for the end screen
    }

    //formats the timer for a smooth countdown
    private string TimerFormat(float timer){
        float minutes = Mathf.FloorToInt(timer/60); //minutes format
        float seconds = Mathf.FloorToInt(timer%60); //seconds format
        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}

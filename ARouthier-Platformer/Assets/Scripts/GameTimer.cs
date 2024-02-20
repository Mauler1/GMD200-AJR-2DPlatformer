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
        GameManager.Instance.resetTimer();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        timerText.text = TimerFormat(timer);
        GameManager.Instance.setTimer(timer);
    }

    //formats the timer for a smooth countdown
    private string TimerFormat(float timer){
        float minutes = Mathf.FloorToInt(timer/60);
        float seconds = Mathf.FloorToInt(timer%60);
        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}

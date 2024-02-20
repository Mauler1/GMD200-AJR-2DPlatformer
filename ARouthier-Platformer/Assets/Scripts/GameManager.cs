using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private float timer = 0.00f;

    private void Awake(){
    if (Instance != null)
    {
        Destroy(gameObject); // destroy duplicate gamemanager on scene switching
        return;
    }
    Instance = this;
    DontDestroyOnLoad(gameObject); // stayin alive
    }

    public void resetTimer(){ // resets the timer - called when the level scene is loaded so that the timer is fresh each time
        timer = 0.00f;
    }

    public void setTimer(float time){ // sets the timer
        timer = time;
    }

    //get timer - for end screen only
    public float getTimer(){
        return timer;
    }
}
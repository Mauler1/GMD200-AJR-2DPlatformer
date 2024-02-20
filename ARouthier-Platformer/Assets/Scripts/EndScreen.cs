using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreen : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timer;

    // takes the timer from the Game Manager and displays it
    void Start(){
        timer.text = GameManager.Instance.getTimer().ToString();
    }

    // load title screen on click
    public void ChangeScene(){
        SceneManager.LoadScene("TitleScene");
    }

    // quits the game on click
    public void QuitGame(){
        Application.Quit();
    }
}

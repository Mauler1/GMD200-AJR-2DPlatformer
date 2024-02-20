using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreen : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timer;

    void Start(){
        timer.text = GameManager.Instance.getTimer().ToString();
    }

    public void ChangeScene(){
        SceneManager.LoadScene("TitleScene");
    }

    public void QuitGame(){
        Application.Quit();
    }
}

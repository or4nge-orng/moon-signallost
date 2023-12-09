using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame() {
        PlayerPrefs.SetInt("finishedToday", 0);
        PlayerPrefs.SetInt("newDay", 0);
        PlayerPrefs.SetInt("day", 0);
        PlayerPrefs.SetInt("lost", 0);
        SceneManager.LoadScene("bedroom");
    }
}

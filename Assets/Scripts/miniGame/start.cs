using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class start : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("lost", 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown) {
            SceneManager.LoadScene("miniGame");
        }
    }
}

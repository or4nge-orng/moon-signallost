using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class movie : MonoBehaviour
{

public Animation anim;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (anim.isPlaying == false) {
            if (Input.anyKeyDown) {
                SceneManager.LoadScene("bedroom");
            }
        }
    }
}

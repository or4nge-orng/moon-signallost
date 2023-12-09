using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneChange : MonoBehaviour
{
    
    public static int day;
    private SpriteRenderer renderer;
    public Sprite[] sprites;
    
    void Start()
    {
        day = PlayerPrefs.GetInt("day");
        renderer = gameObject.GetComponent<SpriteRenderer>();
        renderer.sprite = sprites[day];
        Debug.Log(day);
    }

    // Update is called once per frame
    
    void Update() {
        
    }
}

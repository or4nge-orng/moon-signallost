using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class bullet : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other) {
        Destroy(gameObject.transform.parent.gameObject);
        Debug.Log("hit");
        PlayerPrefs.SetInt("lost", 1);
    }

    void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.name == "background") {
            Destroy(gameObject.transform.parent.gameObject);
        }
    }

}

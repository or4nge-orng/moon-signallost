using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class loneMovement : MonoBehaviour
{

    public GameObject bullet;
    public float time;
    [HideInInspector] public Canvas end_title_win;
    [HideInInspector] public Canvas end_title_lost;
    public Transform player;
    public GameObject spawnY;
    public Transform bg;
    public Canvas UI;
    [HideInInspector] public bool isTimerRunning = true;
    public TMP_Text timer;
    private Vector2 bulletSpawnPoint;
    public DoorReactions mainPlayerScript;

    

    // Start is called before the first frame update
    void Start()
    {
        UI = UI.GetComponent<Canvas>();
        end_title_win = UI.transform.GetChild(2).GetComponent<Canvas>();
        end_title_win.enabled = !end_title_win.enabled;
        end_title_lost = UI.transform.GetChild(3).GetComponent<Canvas>();
        end_title_lost.enabled = !end_title_lost.enabled;
        InvokeRepeating("Shoot", 0.75f, 0.5f);
        PlayerPrefs.SetInt("finishedToday", 0);
    }

    // Update is called once per frame
    void Update()
    {

        if (isTimerRunning) {
            if (time > 0 && PlayerPrefs.GetInt("lost") == 0)
            {
                time -= Time.deltaTime;
            } else if (time > 00 && PlayerPrefs.GetInt("lost") == 1) {
                Debug.Log("lost");
                EndGame("You lost!");
            } else {
                Debug.Log("Win");
                PlayerPrefs.SetInt("finishedToday", 1);
                EndGame("You win!");
                
            }
        } else if (isTimerRunning == false && PlayerPrefs.GetInt("lost") == 0) {
            if (Input.anyKeyDown) {
                SceneManager.LoadScene("moon");
            }
        }
        timer.text = time.ToString();
        if (GameObject.Find("player") != null)
        {
            bulletSpawnPoint = new Vector2(player.position.x, spawnY.transform.position.y);
        }
            
    }

    void Shoot() {
        Instantiate(bullet, bulletSpawnPoint, Quaternion.identity);
    }

    public void EndGame (string finishText) {
        isTimerRunning = false;
        time = 0f;
        CancelInvoke();
        bg.position = new Vector3(bg.position.x, bg.position.y, -2f);
        UI.transform.GetChild(0).GetComponent<TMP_Text>().enabled = !UI.transform.GetChild(0).GetComponent<TMP_Text>().enabled;
        UI.transform.GetChild(1).GetComponent<TMP_Text>().enabled = !UI.transform.GetChild(1).GetComponent<TMP_Text>().enabled;
        
        if (finishText == "You lost!") {
            end_title_lost.enabled = !end_title_lost.enabled;
            end_title_lost.transform.GetChild(0).GetComponent<TMP_Text>().text = finishText;
        } else if (finishText == "You win!") {
            end_title_win.enabled = !end_title_win.enabled;
            end_title_win.transform.GetChild(0).GetComponent<TMP_Text>().text = finishText;
        }
    }

    public void Restart() {
        SceneManager.LoadScene("miniGameStart");
    }

}

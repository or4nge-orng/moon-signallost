using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class DoorReactions : MonoBehaviour
{


    public Animation animDoor;
    public TMP_Text compHint;
    public TMP_Text bedHint;
    public TMP_Text miniGameHint;
    public Animation black;
    public Color startCol;
    public Color finCol;
    public TMP_Text compPhrase;
    public Animation compPhraseAnim;

    private bool isOpened = false;
    public static bool canInteractComp;
    public static bool canInteractMiniGame = false;
    public static bool canSleep;
    public static bool usedComp = false;
    public float fadeSpeed = 1.5f;

    // Start is called before the first frame update
    void Start()
    {

        if (PlayerPrefs.GetInt("finishedToday") == 1) {
            transform.position = new Vector3(3.37f, -0.94f, -0.91f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        startCol = new Color(0, 0, 0, 0);
        finCol = new Color(0, 0, 0, 255);
        


		if (canInteractComp && PlayerPrefs.GetInt("finishedToday") == 0 && Input.GetKeyDown(KeyCode.E)) {
            usedComp = true;
			if (PlayerPrefs.GetInt("day") == 0) {
                compPhrase.text = "Вчера я обнаружил что вышка связи не подает признаков жизни, я думаю стоит выйти из моего жилища и попробовать ее починить";
            } else if (PlayerPrefs.GetInt("day") == 1) {
                compPhrase.text = "Спиной я чувствую холодное, безжизненное дыхание. Я знаю, что я далеко не один на этой, казалось бы, безжизненной планете. Мой гниющий мозг заставляет меня вновь пойти чинить груду металлолома, именующую себя вышкой.";
            } else if (PlayerPrefs.GetInt("day") == 2) {
                compPhrase.text = "Сквозь бесперебойный бубнёж голосов в голове, я слышу отчетливо один голос, который говорит, казалось бы, на непонятном мне языке, но я отчетливо разбираю смысл. Он умоляет выйти из убежища и сделать выбор.";
            }
            compPhraseAnim.Play("compPhrase");
		}
        if (canInteractMiniGame && PlayerPrefs.GetInt("finishedToday") == 0 && Input.GetKeyDown(KeyCode.E)) {
			if (PlayerPrefs.GetInt("day") == 2) {
                SceneManager.LoadScene("finalRoom");
            } else {
                SceneManager.LoadScene("miniGameStart");
            }
		}
        if (canSleep && PlayerPrefs.GetInt("finishedToday") == 1 && Input.GetKeyDown(KeyCode.E)) {
            PlayerPrefs.SetInt("day", PlayerPrefs.GetInt("day") + 1);
            PlayerPrefs.SetInt("finishedToday", 0);
            PlayerPrefs.SetInt("newDay", 0);
            PlayerPrefs.SetInt("lost", 0);
            usedComp = false;
            black.Play("sceneChange");
        }
        if (usedComp) {
            animDoor.gameObject.GetComponent<Collider2D>().enabled = !animDoor.gameObject.GetComponent<Collider2D>().enabled;
        } else {
            animDoor.gameObject.GetComponent<Collider2D>().enabled = !animDoor.gameObject.GetComponent<Collider2D>().enabled;
        }

    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "doorTrigger" && usedComp) {
                isOpened = true;
                animDoor.Play("doorOpen");
        } 
        if (other.gameObject.tag == "levelChangeTrigger") {
            if (SceneManager.GetActiveScene().name == "moon") {
                SceneManager.LoadScene("bedroom");
            } else {
                SceneManager.LoadScene("moon");
            }
        }
        if (other.gameObject.tag == "compTrigger" && PlayerPrefs.GetInt("finishedToday") == 0 && usedComp == false) {
            canInteractComp = true;
            compHint.enabled = !compHint.enabled;
            Debug.Log(canInteractComp);
        }
        if (other.gameObject.tag == "miniGameTrigger") {
            miniGameHint.enabled = !miniGameHint.enabled;
            canInteractMiniGame = true;
        }
        if (other.gameObject.tag == "bedTrigger" && PlayerPrefs.GetInt("finishedToday") == 1) {
            bedHint.enabled = !bedHint.enabled;
            canSleep = true;
        }
    }
    void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.tag == "doorTrigger") {
            if (isOpened) {
                isOpened = false;
                animDoor.Play("doorClose");
            }
        }
        if (other.gameObject.tag == "compTrigger" && PlayerPrefs.GetInt("finishedToday") == 0 && compHint.enabled == true) {
            canInteractComp = false;
            compHint.enabled = !compHint.enabled;
            Debug.Log(canInteractComp);
        }
        if (other.gameObject.tag == "miniGameTrigger") {
            miniGameHint.enabled = !miniGameHint.enabled;
            canInteractMiniGame = false;
        }
        if (other.gameObject.tag == "bedTrigger" && PlayerPrefs.GetInt("finishedToday") == 1) {
            bedHint.enabled = !bedHint.enabled;
            canSleep = false;
        }
        
    }

    
}


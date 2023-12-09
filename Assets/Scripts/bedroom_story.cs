using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class bedroom_story : MonoBehaviour
{
    
    public TMP_Text compPhrase;
    public Animation compPhraseAnim;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("day") == 0 && PlayerPrefs.GetInt("newDay") == 0) {
            compPhrase.text = "Моя утренняя, а может вечерняя(не знаю, на луне для меня не существует определенного времени) рутина начинается с записывания новых данных в компьютер, нужно записать жизненные показатели";
        } else if (PlayerPrefs.GetInt("day") == 1 && PlayerPrefs.GetInt("newDay") == 0) {
            compPhrase.text = "Вчера я еле смог уснуть, потому что они смотрели на меня сквозь непроглядную тьму. Нужно ввести нужные показатели в компьютер, хотя не знаю кому они нужны, может быть тем, чьи пустые глазницы не отражают эмоций";
        } else if (PlayerPrefs.GetInt("day") == 2 && PlayerPrefs.GetInt("newDay") == 0) {
            compPhrase.text = "Этой ночью я не спал, а лишь наблюдал за медленными метаморфозами моего окружения. Все вещи, от шкафа с непонятными устройствами, до пола претерпели небольшие изменения. Я слышу инородные запахи, чувствую вибрацию космоса. Экран бортового компьютера станет проводником в мир одиночества и безнадежности.";
        } else {
            compPhrase.text = "";
        }
        compPhraseAnim.Play("compPhrase");
        Debug.Log(PlayerPrefs.GetInt("newDay"));
        PlayerPrefs.SetInt("newDay", 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

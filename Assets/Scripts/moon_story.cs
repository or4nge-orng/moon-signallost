using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class moon_story : MonoBehaviour
{

    public TMP_Text compPhrase;
    public Animation compPhraseAnim;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("day") == 0 && PlayerPrefs.GetInt("finishedToday") == 1) {
            compPhrase.text = "Дерьмо, еще позавчера она работала как швейцарские часы, а сейчас превратилась в кучу космического мусора, остается надеяться на скорую помощь, нужно вернуться в убежище и попробовать отвлечь себя от гнетущих мыслей о бренном существовании";
        } else if (PlayerPrefs.GetInt("day") == 1 && PlayerPrefs.GetInt("finishedToday") == 1) {
            compPhrase.text = "Другого исхода я не ожидал, голоса в голове говорят, что он придет и поможет, направит на путь истины";
        } else if (PlayerPrefs.GetInt("day") == 2 && PlayerPrefs.GetInt("finishedToday") == 1) {
            compPhrase.text = "Волшебное ощущение, будто я оказался на давно забытых лужайках психиатрического интерната. Вышка зовет и я не в силах воспротивиться ее воле. Она просит починить ее.";
        } else {
            compPhrase.text = "";
        }
        compPhraseAnim.Play("compPhrase");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

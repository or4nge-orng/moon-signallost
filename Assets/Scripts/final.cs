using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class final : MonoBehaviour
{


    public Animation dialog;
    public Animation final_anim;
    public SpriteRenderer final_sprite;
    public Canvas dialog_sprite;
    // Start is called before the first frame update
    void Start()
    {
        dialog.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (dialog.isPlaying == false) {
            final_anim.Play("1");
        }
    }
}

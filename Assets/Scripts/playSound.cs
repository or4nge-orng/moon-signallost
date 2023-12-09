using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playSound : MonoBehaviour
{

    public AudioSource doorOpenSound;

    // Start is called before the first frame update
    public void fdoorOpenSound() {
        doorOpenSound.Play(0);
    }
    public void fdoorCloseSound() {
        doorOpenSound.Play(1);
    }
}

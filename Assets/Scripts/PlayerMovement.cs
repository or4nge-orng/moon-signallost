using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;
    private Vector3 newDayPos = new Vector3(-4.920519f, -1.540103f, -0.91f);
    public float runSpeed = 40f;
    float horizontalMove = 0f;
    void Awake()
    {
        if (PlayerPrefs.GetInt("newDay") == 0) {
            transform.position = new Vector3(-4.920519f, -1.540103f, -0.91f);
            
        }
    }

    // Update is called once per frame
    void Update()
    {

        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("speed", Mathf.Abs(horizontalMove));

    }

    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, false);
    }
}

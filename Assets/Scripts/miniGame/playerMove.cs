using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    
    private float horizontal;
    public float speed;
    private Vector3 scale;
    private bool isFacingRight = false;
    [HideInInspector] public bool lost = false;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private loneMovement main;


    void Start() {
        scale = transform.localScale;
    }
    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        Flip();

        if (main.isTimerRunning == false) {
            Destroy(gameObject);
        }

    }

    void FixedUpdate() {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private void Flip() {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f) {
            isFacingRight = !isFacingRight;
            scale.x *= -1;
            transform.localScale = scale;
        }
    }
}

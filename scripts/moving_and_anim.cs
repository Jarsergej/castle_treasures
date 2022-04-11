using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moving_and_anim : MonoBehaviour
{
    public float speed;

    private Rigidbody2D rb;
    private Animator anime;
    private bool IsLastForward;
    private Vector2 moveVelocity;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anime = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        moveVelocity = moveInput * speed;
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);

        if (Input.GetKey(KeyCode.D))
        {
            anime.Play("Going_right");
            IsLastForward = false;
        }

        else if (Input.GetKey(KeyCode.A))
        {
            anime.Play("Going_left");
            IsLastForward = false;
        }

        else if (Input.GetKey(KeyCode.W))
        {
            anime.Play("Going_forward");
            IsLastForward = true;
        }

        else if (Input.GetKey(KeyCode.S))
        {
            anime.Play("Going_back");
            IsLastForward = false;
        }

        else
        {
            if(IsLastForward == false)
                anime.Play("idle_back");
            if(IsLastForward == true)
                anime.Play("idle_forward");
        }
    }
}

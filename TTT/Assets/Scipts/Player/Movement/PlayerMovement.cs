using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float Move;
    float speed = 0.6f;
    private Animator animator;
    int looking = 1;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        MovementLogic();
    }

    private void MovementLogic()
    {
        //Ускорение персонажа
        /*
        if (Input.GetKey(KeyCode.LeftShift))
            speed = 0.95f;
        else
            speed = 0.8f;
        */
        //Движение персонажа
        if (Input.GetAxis("Vertical") > 0)
        {
            if (looking != 1) Rotation(1);
            Move = Input.GetAxis("Vertical") * speed;
            animator.SetBool("isRunning", true);
        }
        else if (Input.GetAxis("Vertical") < 0)
        {
            if (looking != 2) Rotation(2);
            Move = Input.GetAxis("Vertical") * speed * -1.0f;
            animator.SetBool("isRunning", true);
        }
        else if (Input.GetAxis("Horizontal") > 0)
        {
            if (looking != 4) Rotation(4);
            Move = Input.GetAxis("Horizontal") * speed;
            animator.SetBool("isRunning", true);
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            if (looking != 3) Rotation(3);
            Move = Input.GetAxis("Horizontal") * speed * -1.0f;
            animator.SetBool("isRunning", true);
        } 
        else
        {
            animator.SetBool("isRunning", false);
        }
        Vector3 movement = new Vector3(0.0f, 0.0f, Move);
        GetComponent<Rigidbody>().AddRelativeForce(movement * speed, ForceMode.Impulse);
    }

    private void Rotation(int need)
    {
        switch(looking)
        {
            case 1:
                {
                    switch (need)
                    {
                        case 2: transform.Rotate(0.0f, 180.0f, 0.0f); looking = 2; break;
                        case 3: transform.Rotate(0.0f, -90.0f, 0.0f); looking = 3; break;
                        case 4: transform.Rotate(0.0f, 90.0f, 0.0f); looking = 4; break;
                        default: break;
                    }
                    break;
                }
            case 2:
                {
                    switch (need)
                    {
                        case 1: transform.Rotate(0.0f, 180.0f, 0.0f); looking = 1; break;
                        case 3: transform.Rotate(0.0f, 90.0f, 0.0f); looking = 3; break;
                        case 4: transform.Rotate(0.0f, -90.0f, 0.0f); looking = 4; break;
                        default: break;
                    }
                    break;
                }
            case 3:
                {
                    switch (need)
                    {
                        case 1: transform.Rotate(0.0f, 90.0f, 0.0f); looking = 1; break;
                        case 2: transform.Rotate(0.0f, -90.0f, 0.0f); looking = 2; break;
                        case 4: transform.Rotate(0.0f, 180.0f, 0.0f); looking = 4; break;
                        default: break;
                    }
                    break;
                }
            case 4:
                {
                    switch (need)
                    {
                        case 1: transform.Rotate(0.0f, -90.0f, 0.0f); looking = 1; break;
                        case 2: transform.Rotate(0.0f, 90.0f, 0.0f); looking = 2; break;
                        case 3: transform.Rotate(0.0f, 180.0f, 0.0f); looking = 3; break;
                        default: break;
                    }
                    break;
                }
            default: break;
        }
    }
}

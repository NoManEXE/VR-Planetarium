using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalk : MonoBehaviour
{
    // Start is called before the first frame update
    public int playerSpeed;
    public bool isGrounded;

  


    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();


    }

    void OnCollisionStay()
    {
        isGrounded = true;
    }

    


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetButton("Fire1") || Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += Camera.main.transform.forward * playerSpeed * Time.deltaTime;

            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                playerSpeed += 3;
            }
            else if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                playerSpeed -= 3;
            }
        }
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            transform.position -= Camera.main.transform.forward * playerSpeed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Camera.main.transform.right * playerSpeed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position -= Camera.main.transform.right * playerSpeed * Time.deltaTime;
        }


        if (Input.GetButton("Jump") && isGrounded)
        {
            rb.AddForce(new Vector3(0, 3, 0), ForceMode.Impulse);
            isGrounded = false;

        }

    }

}
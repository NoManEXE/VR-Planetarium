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
        if (Input.GetButton("Fire1"))
        {
            transform.position = transform.position + Camera.main.transform.forward * playerSpeed * Time.deltaTime;
        }

        if(Input.GetButton("Jump") && isGrounded)
        {
            rb.AddForce(new Vector3(0, 3, 0), ForceMode.Impulse);
            isGrounded = false;

        }

    }

}
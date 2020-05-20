using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveShuttle : MonoBehaviour
{
    public float speed = 10;
   
    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }
}

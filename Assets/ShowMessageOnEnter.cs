using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ShowMessageOnEnter : MonoBehaviour
{
    public GameObject welcomeMessage;
    public float time = 5; //Seconds to read the text

    private void OnTriggerEnter(Collider myCollider)
    {
        if(myCollider.tag == ("Player"))
        {
            Debug.Log("Trigger executed");
            welcomeMessage.SetActive(true);
            

            Debug.Log("object found and set active");
            Destroy(welcomeMessage, time);
        }
    }
}

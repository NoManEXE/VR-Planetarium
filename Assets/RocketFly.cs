using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketFly : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        LeanTween.moveLocalY(gameObject, 40, 60f).setEaseOutQuad().setOnComplete(DestroyMe);


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void DestroyMe()
    {
        Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cosmonautFly : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        LeanTween.moveLocalY(gameObject, -10, 60f).setEaseOutQuad().setOnComplete(DestroyMe);


        LeanTween.rotate(gameObject, new Vector3(180f, 30f, 0f), 20f);

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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
public class gvrButton : MonoBehaviour
{
    public UnityEvent GVRClick;
    public float totalTime = 2;
    bool gvrStatus;
    public float gvrTimer;
    // Start is called before the first frame update
   

    // Update is called once per frame
    void Update()
    {
        if (gvrStatus)
        {
            gvrTimer += Time.deltaTime;
        }

        if(gvrTimer > totalTime)
        {
            GVRClick.Invoke();
        }
        Debug.Log("update executed");
    }

    public void GvrOn()
    {
        gvrStatus = true;
        Debug.Log("GVR ON");
    }

    public void GvrOff()
    {
        gvrStatus = false;
        gvrTimer = 0;
        Debug.Log("GVR OFF");
    }
}

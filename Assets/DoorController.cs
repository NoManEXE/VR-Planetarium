using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public int id; 

    void Start()
    {
        GameEvents.current.onDoorwayTriggerEnter += OnDoorwayOpen;
        GameEvents.current.onDoorwayTriggerExit += OnDoorwayClose;
    }

    private void OnDoorwayClose(int id)
    {
       if (id == this.id) { 
       LeanTween.moveLocalY(gameObject, 3.548f, 5f).setEaseInQuad();
        }
    }

    private void OnDoorwayOpen(int id)
    {
        if(id == this.id) { 
        LeanTween.moveLocalY(gameObject, 5.5f, 5f).setEaseOutQuad();
        }
    }

    private void OnDestroy()
    {
        GameEvents.current.onDoorwayTriggerEnter -= OnDoorwayOpen;
        GameEvents.current.onDoorwayTriggerExit -= OnDoorwayClose;
    }
}

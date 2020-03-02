using UnityEngine;
using System.Collections;

public class EarthSpinScript : MonoBehaviour {
    public float speed = 10f;
    public bool rotateX;

    void Update() {
        if (rotateX == true)
        {
            transform.Rotate(Vector3.right, speed * Time.deltaTime, Space.World);
        }

        else
        {
            transform.Rotate(Vector3.up, speed * Time.deltaTime, Space.World);
        }
    }
}
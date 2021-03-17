using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed = -6f;
   

    // Update is called once per frame
    void Update()
    {
        MoveMush();
    }
    public void MoveMush()
    {
        Vector3 newPosition = new Vector3(0, 0, 0);
        float posMouse = Input.mousePosition.x / Screen.width * speed;
        newPosition.x = Mathf.Clamp(posMouse - 8.1f, -9.5f, 9.5f);
        this.transform.position = newPosition;
    }
}

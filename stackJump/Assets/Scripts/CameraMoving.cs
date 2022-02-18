using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoving : MonoBehaviour
{
    Player thePlayer;

    float maxY = 0;
    void Awake()
    {
        thePlayer = FindObjectOfType<Player>();
    }
    public void Init()
    {
        maxY = 0;
    }
    void LateUpdate()
    {
        MoveCamera();
    }
    void MoveCamera()
    {
        if (thePlayer.transform.position.y > maxY)
        {
            maxY = thePlayer.transform.position.y;
            Camera.main.transform.position = new Vector3(transform.position.x, maxY + 2f, -15);
        }
    }
}

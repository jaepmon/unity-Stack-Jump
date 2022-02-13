using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plate : MonoBehaviour
{
    public float speed = 0;
    public bool isMove;
    
    public void Init(float speed)
    {
        this.speed = speed;
        isMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isMove)
        {
            transform.position += new Vector3(speed * Time.deltaTime, 0f, 0f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        isMove = false;

        if (transform.position.y + 0.4f < collision.transform.position.y)
        {
            PlateSpawn.instance.SpawnPosUp();
            GameManager.instance.AddScore();

            if (transform.position.x < Player.instance.transform.position.x - 0.3f
                || transform.position.x > Player.instance.transform.position.x + 0.3f)
            {
                GameManager.instance.ComboSuccess();
            }
            else 
            {
                GameManager.instance.ComboFail();
                  
            }
        }
        else
        {
            Player.instance.PlayerDie();
        }
    }

    public void HidePlate()
    {
        gameObject.SetActive(false);
    }
}

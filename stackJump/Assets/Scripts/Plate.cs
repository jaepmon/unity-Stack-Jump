using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plate : MonoBehaviour
{
    public float speed = 0;
    public bool isMove;

    GameManager gm;
    PlateSpawn ps;
    Player thePlayer;

    void Awake()
    {
        thePlayer = FindObjectOfType<Player>();
        ps = FindObjectOfType<PlateSpawn>();
        gm = FindObjectOfType<GameManager>();
    }
    public void Init(float speed)
    {
        this.speed = speed;
        isMove = true;
    }
    void Update()
    {
        if (isMove)
        {
            transform.position += new Vector3(speed * Time.deltaTime, 0f, 0f);         
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        isMove = false;
        if ((transform.position.y + 0.4f < collision.transform.position.y) && !isMove)
        {
            ps.SpawnPosUp();
            RaycastHit hit;
            Physics.Raycast(transform.position, Vector3.down, out hit, 0.5f);
            if(hit.transform == null)
            {
                gm.AddScore();
                gm.ComboFail();
                return;
            }
            float value = transform.position.x - hit.transform.position.x;

            if ((value < -0.3f || value > 0.3f) && hit.transform.CompareTag("Plate") )
            {
                gm.ComboFail();
            }
            gm.AddScore();

            
        }
        else
        {
            thePlayer.PlayerDie();
        }
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
    [SerializeField] Rigidbody rb = null;

    public GameObject comboEffect;
    public float jumpPower = 0;

    GameManager gm;
    PlateSpawn ps;
    Animator anim;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();

        gm = FindObjectOfType<GameManager>();
        ps = FindObjectOfType<PlateSpawn>();
    }

    public void Jump()
    {
        if (rb.velocity.y != 0)
        {
            return;
        }
        rb.AddForce(new Vector3(0, jumpPower, 0));
    }

    public void Init()
    {
        transform.position = Vector3.zero;
        anim.enabled = true;
        anim.Play("Idle");      
    }
    public void PlayerDie()
    {
        if (ps.randomSpawnPos == 0)
        {
            anim.Play("Rotate");
            rb.AddForce(new Vector3(200, 0, 0));
        }
        else
        {
            anim.Play("RotateLeft");
            rb.AddForce(new Vector3(-200, 0, 0));  
        }
        StartCoroutine(DelayCoroutine());
    }

    IEnumerator DelayCoroutine()
    {
        yield return new WaitForSeconds(3f);

        ps.RemovePlate();
        
        gm.Init();
    }
}

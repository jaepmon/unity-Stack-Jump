using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
    public static Player instance;
    [SerializeField] Rigidbody rb = null;
    public float jumpPower = 0;
    public GameObject comboEffect;
    private Animator anim;
    private Vector3 playerPos;
    bool isRotate = false;
    private void Awake()
    {
        instance = this;
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        playerPos = transform.position;            
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
        transform.position = playerPos;
        anim.enabled = true;
        anim.Play("Idle");      
    }
    public void PlayerDie()
    {
        isRotate = true;

        if (PlateSpawn.randomSpawnPos == 0)
        {
            anim.Play("Rotate");
            rb.AddForce(new Vector3(200, 0, 0));
        }
        else
        {
            anim.Play("RotateLeft");
            rb.AddForce(new Vector3(-200, 0, 0)); 
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(isRotate && collision.transform.gameObject.tag == "Ground")
        {
            anim.enabled = false;
            
            isRotate = false;

            StartCoroutine(DelayCoroutine());
        }   
    }

    IEnumerator DelayCoroutine()
    {
        yield return new WaitForSeconds(3f);

        PlateSpawn.instance.RemovePlate();
        
        GameManager.instance.Init();
    }
}

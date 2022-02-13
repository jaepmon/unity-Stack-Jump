using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool instance;

    [SerializeField] GameObject goPreFab = null;

    [SerializeField] Transform pool = null;

    [SerializeField] int poolSize;

    public Queue<GameObject> plateList = new Queue<GameObject>();

    GameManager theGameManager;

    void Awake()
    {
        instance = this;

        plateList = InsertQueue();

        theGameManager = FindObjectOfType<GameManager>();
    }

    Queue<GameObject> InsertQueue()
    {
        Queue<GameObject> tempObject = new Queue<GameObject>();

        for( int i = 0; i < poolSize; i++)
        {
            GameObject clone = Instantiate(goPreFab, transform.position, Quaternion.identity);

            clone.SetActive(false);

            if(pool != null)
            {
                clone.transform.SetParent(pool);
            }
            else
            {
                clone.transform.SetParent(this.transform);
            }

            tempObject.Enqueue(clone);          
        }

        return tempObject;
    }
}

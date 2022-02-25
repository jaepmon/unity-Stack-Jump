using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ObjInfo
{
    public GameObject goPrefab;
    public int poolSize;
    public Transform pool;
}


public class ObjectPool : MonoBehaviour
{
    [SerializeField] ObjInfo[] ObjInfo = null;

    public static ObjectPool instance;

    public Queue<GameObject> plateList = new Queue<GameObject>();

    GameManager theGameManager;

    void Awake()
    {
        instance = this;

        plateList = InsertQueue(ObjInfo[0]);

        theGameManager = FindObjectOfType<GameManager>();
    }
    Queue<GameObject> InsertQueue(ObjInfo objInfo)
    {
        Queue<GameObject> tempQueue = new Queue<GameObject>();

        for (int i = 0; i < objInfo.poolSize; i++)
        {
            GameObject clone = Instantiate(objInfo.goPrefab, transform.position, Quaternion.identity);

            clone.SetActive(false);

            if (objInfo.pool != null)
            {
                clone.transform.SetParent(objInfo.pool);
            }
            else
            {
                clone.transform.SetParent(this.transform);
            }

            tempQueue.Enqueue(clone);
        }

        return tempQueue;
    }
}

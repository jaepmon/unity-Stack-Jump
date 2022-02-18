using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateSpawn : MonoBehaviour
{
    [SerializeField] Transform[] spawnSpot = null;

    public float plateSpeed = 5;
    public int randomSpawnPos;

    Vector3 initPos;

    public List<GameObject> boxPlateList = new List<GameObject>();

    GameManager gm;
    void Awake()
    {
        gm = FindObjectOfType<GameManager>();
    }
    public void CreatePlate()
    {
        if(gm.isGameStart)
        {
            GameObject tempPlate = ObjectPool.instance.plateList.Dequeue();
            randomSpawnPos = Random.Range(0, 2);
            tempPlate.transform.position = spawnSpot[randomSpawnPos].position;
            tempPlate.gameObject.SetActive(true);
            boxPlateList.Add(tempPlate);
            float plateSpeed = this.plateSpeed;
            if (randomSpawnPos == 1)
            {
                plateSpeed *= -1;
            }
            Plate createPlate = tempPlate.GetComponent<Plate>();
            createPlate.Init(plateSpeed);
        }
    }
    public void Init()
    {
        transform.position = initPos;     
    }
    public void SpawnPosUp()
    {
        if(gm.isGameStart)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + 0.8f, transform.position.z);

            CreatePlate();
        }
    }

    public void RemovePlate()
    {
        gm.isGameStart = false;

        for(int i = 0; i < boxPlateList.Count; i++)
        {
            boxPlateList[i].SetActive(false);
            ObjectPool.instance.plateList.Enqueue(boxPlateList[i]);
        }

        boxPlateList.Clear();
    }
}

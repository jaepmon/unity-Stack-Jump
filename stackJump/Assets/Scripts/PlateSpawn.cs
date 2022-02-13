using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateSpawn : MonoBehaviour
{
    public static PlateSpawn instance;
    public static int randomSpawnPos;

    [SerializeField] Plate plate = null;
    [SerializeField] Transform[] spawnSpot = null;
    public float plateSpeed = 5;

    public List<GameObject> boxPlateList = new List<GameObject>();
    private Vector3 initPos;
    private void Awake()
    {
        instance = this;
    }
    
    public void CreatePlate()
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
    public void Init()
    {
        transform.position = initPos;     
    }
    public void SpawnPosUp()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + 0.8f, transform.position.z);
        
        CreatePlate();
    }

    public void RemovePlate()
    {
        GameManager.instance.isGameStart = false;

        for(int i = 0; i < boxPlateList.Count; i++)
        {
            boxPlateList[i].SetActive(false);
            ObjectPool.instance.plateList.Enqueue(boxPlateList[i]);
        }

        boxPlateList.Clear();
    }
}

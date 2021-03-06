using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BacktoObjectPool : MonoBehaviour
{
    PlateSpawn ps;

    void Awake()
    {
        ps = FindObjectOfType<PlateSpawn>();
    }
    public void MoveLine()
    {
        transform.position += new Vector3(0f, 0.8f, 0f);
    }

    public void Init()
    {
        transform.position = new Vector3(0f, -15f, 0f);
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Plate"))
        {
            ps.boxPlateList.Remove(other.gameObject);

            ObjectPool.instance.plateList.Enqueue(other.gameObject);
            other.gameObject.SetActive(false);
        }
    }
}

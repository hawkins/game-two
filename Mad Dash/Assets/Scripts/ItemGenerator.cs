using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour {

    public ObjectPooler mushroomPool;
    public ObjectPooler pillPool;
    public ObjectPooler security_1pool;
    public ObjectPooler benchPool;

	public void SpawnMushrooms(Vector3 startPosition)
    {
        GameObject shroom = mushroomPool.GetPooledObject();
        shroom.transform.position = startPosition;
        shroom.SetActive(true);
    }

    public void SpawnPills(Vector3 startPosition)
    {
        GameObject pill = pillPool.GetPooledObject();
        pill.transform.position = startPosition;
        pill.SetActive(true);
    }

    public void SpawnSecurity_1(Vector3 startPosition)
    {
        GameObject security_1 = security_1pool.GetPooledObject();
        security_1.transform.position = startPosition;
        security_1.SetActive(true);
    }

    public void SpawnBench(Vector3 startPosition)
    {
        GameObject bench = benchPool.GetPooledObject();
        bench.transform.position = startPosition;
        bench.SetActive(true);
    }
}

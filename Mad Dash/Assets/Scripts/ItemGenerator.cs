using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour {

    public ObjectPooler mushroomPool;
    public ObjectPooler pillPool;
    public ObjectPooler security_1pool;
    public ObjectPooler benchPool;
    public ObjectPooler doctorPool;
    public ObjectPooler security_2pool;
    public ObjectPooler dogPool;
    public ObjectPooler birdPool;
    public ObjectPooler clockPool;
    public ObjectPooler chairPool;

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

    public void SpawnDoctor(Vector3 startPosition)
    {
        GameObject doctor = doctorPool.GetPooledObject();
        doctor.transform.position = startPosition;
        doctor.SetActive(true);
    }

    public void SpawnSecurity_2(Vector3 startPosition)
    {
        GameObject security_2 = security_2pool.GetPooledObject();
        security_2.transform.position = startPosition;
        security_2.SetActive(true);
    }

    public void SpawnDog(Vector3 startPosition)
    {
        GameObject dog = dogPool.GetPooledObject();
        dog.transform.position = startPosition;
        dog.SetActive(true);
    }

    public void SpawnBird(Vector3 startPosition)
    {
        GameObject bird = birdPool.GetPooledObject();
        bird.transform.position = startPosition;
        bird.SetActive(true);
    }

    public void SpawnClock(Vector3 startPosition)
    {
        GameObject clock = clockPool.GetPooledObject();
        clock.transform.position = startPosition;
        clock.SetActive(true);
    }

    public void SpawnChair(Vector3 startPosition)
    {
        GameObject chair = chairPool.GetPooledObject();
        chair.transform.position = startPosition;
        chair.SetActive(true);
    }
}

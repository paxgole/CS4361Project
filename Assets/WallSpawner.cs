using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSpawner : MonoBehaviour
{
    private float nextSpawnTime; //when next wall will spawn

    // [SerializeField] private GameObject Wall1;
    // [SerializeField] private GameObject Wall2;
    // [SerializeField] private GameObject Wall3;
    // [SerializeField] private GameObject Wall4;
    [SerializeField] private float spawnDelay;
    [SerializeField] private List<GameObject> walls;
    [SerializeField] private Queue<GameObject> wallOrder;
    
    // Start is called before the first frame update
    void Start()
    {
        wallOrder = new();
        int rand = UnityEngine.Random.Range(0,walls.Count);
        wallOrder.Enqueue(walls[rand]);
        rand = UnityEngine.Random.Range(0,walls.Count);
        wallOrder.Enqueue(walls[rand]);
        rand = UnityEngine.Random.Range(0,walls.Count);
        wallOrder.Enqueue(walls[rand]);
        rand = UnityEngine.Random.Range(0,walls.Count);
        wallOrder.Enqueue(walls[rand]);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ShouldSpawn() && !Globals.endCondition)
        {
            nextSpawnTime = Time.time + Math.Max(1,spawnDelay * 1/Globals.speed);
            Globals.speed += .01f;
            Instantiate(wallOrder.Dequeue(), transform.position, transform.rotation);
            int rand = UnityEngine.Random.Range(0,walls.Count);
            wallOrder.Enqueue(walls[rand]);
        }
        
            

    }

    // private void Spawn1()
    // {
    //     nextSpawnTime = Time.time + spawnDelay;
    //     Instantiate(Wall1, transform.position, transform.rotation);
    //     spawnCount++;
    // }
    // private void Spawn2()
    // {
    //     nextSpawnTime = Time.time + spawnDelay;
    //     Instantiate(Wall2, transform.position, transform.rotation);
    //     spawnCount++;
    // }
    // private void Spawn3()
    // {
    //     nextSpawnTime = Time.time + spawnDelay;
    //     Instantiate(Wall3, transform.position, transform.rotation);
    //     spawnCount++;
    // }
    // private void Spawn4()
    // {
    //     nextSpawnTime = Time.time + spawnDelay;
    //     Instantiate(Wall4, transform.position, transform.rotation);
    //     spawnCount=1;
    //     spawnDelay--;
    // }

    private bool ShouldSpawn()
    {
        return Time.time >= nextSpawnTime;

    }

}

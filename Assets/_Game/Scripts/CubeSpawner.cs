using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [Header("SPAWNER")]
    public GameObject SpawnCube;
    public List<Transform> SpawnPointList;
    public float spawnrate;
    public bool canSpawn;
    [Space(10)]
    [Header("DELETER")]
    private int deleteCounter;
    public float cubeDeleteTimer;

    private void Start()
    {
        StartCoroutine(spawnerEnumerator());
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Q) && !canSpawn)
        {
            canSpawn = true;
            StartCoroutine(spawnerEnumerator());
        }
        if (Input.GetKey(KeyCode.E))
        {
            canSpawn = false;
            StopCoroutine(spawnerEnumerator());
        }
        if (deleteCounter > 15)
        {
            StartCoroutine(cubeDeleteEnumerator());
        }
    }

    IEnumerator spawnerEnumerator()
    {
        while(canSpawn)
        {
            int spawnerLocation = Random.Range(0, SpawnPointList.Count);
            Instantiate(SpawnCube, SpawnPointList[spawnerLocation].position, Quaternion.identity);
            deleteCounter++;
            yield return new WaitForSeconds(spawnrate);
        }        
    }

    IEnumerator cubeDeleteEnumerator()
    {
        Destroy(gameObject);
        yield return new WaitForSeconds(cubeDeleteTimer);
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    public GameObject SpawnCube;
    public List<Transform> SpawnPointList;
    public float spawnrate;
    public bool canSpawn;

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
    }

    IEnumerator spawnerEnumerator()
    {
        while(canSpawn)
        {
            int spawnerLocation = Random.Range(0, SpawnPointList.Count);
            Instantiate(SpawnCube, SpawnPointList[spawnerLocation].position, Quaternion.identity);
            yield return new WaitForSeconds(spawnrate);
        }        
    }
}

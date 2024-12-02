using System.Collections;
using UnityEngine;

public class cubeSettings : MonoBehaviour
{
    public float cubeDeleteTimer;
    void Start()
    {
        StartCoroutine(cubeDeleteEnumerator());
    }
    IEnumerator cubeDeleteEnumerator()
    {
        Destroy(gameObject);
        yield return new WaitForSeconds(cubeDeleteTimer);
    }
}

using System.Collections;
using UnityEngine;

public class cubeSettings : MonoBehaviour
{
    public float cubeDeleteTimer;
    void Start()
    {
        Invoke(nameof(cubeDelete), 5);
    }

    // Update is called once per frame
    void cubeDelete()
    {
        StartCoroutine(cubeDeleteEnumerator());
    }

    IEnumerator cubeDeleteEnumerator()
    {
        Destroy(gameObject);
        yield return new WaitForSeconds(cubeDeleteTimer);
    }
}

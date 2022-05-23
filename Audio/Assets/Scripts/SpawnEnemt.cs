using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemt : MonoBehaviour
{
    public GameObject prefabEnemy;
    void Start()
    {
        
    }

    void Update()
    {
        StartCoroutine(SpawnEnemy());
    }
    private IEnumerator SpawnEnemy()
    {
        yield return new WaitForSeconds(5);
        GameObject enemy = Instantiate(prefabEnemy, );
        yield return null;
    }
}

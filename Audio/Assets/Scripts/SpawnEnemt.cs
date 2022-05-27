using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemt : MonoBehaviour
{
    public GameObject prefabEnemy;
    public Transform position;
    public int MoveEnemy;
    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }
    private IEnumerator SpawnEnemy()
    {
        yield return new WaitForSeconds(2);
        position.position = new Vector3(Random.Range(-22, 23), position.position.y, position.position.z);
        GameObject enemy = Instantiate(prefabEnemy, position.position, Quaternion.identity);
        enemy.GetComponent<Rigidbody>().AddForce(Vector3.back * MoveEnemy, ForceMode.Impulse);
        StartCoroutine(SpawnEnemy());
    }
}

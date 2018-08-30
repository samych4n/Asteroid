using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonSpawn : MonoBehaviour
{


    [SerializeField] Poison poison;
    [SerializeField] float timeToSpawn = 1;

    private void Start()
    {
        StartCoroutine(SpawnPoison());
    }
    IEnumerator SpawnPoison()
    {
        yield return new WaitForSeconds(timeToSpawn);
        Instantiate(poison, new Vector2(Random.Range(-GameBounds.instance.BoundX + 1, GameBounds.instance.BoundX - 1), Random.Range(-GameBounds.instance.BoundY + 1, GameBounds.instance.BoundY - 1)), Quaternion.identity);
        StartCoroutine(SpawnPoison());
    }



}

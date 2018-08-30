using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ETSpawn : MonoBehaviour
{

    [SerializeField] Alien alien;
    [SerializeField] float timeToSpawn = 1;
    [SerializeField] float YlocationToSpawn = 4;

    private void Start()
    {
        StartCoroutine(SpawnAlien());
    }
    IEnumerator SpawnAlien()
    {
        yield return new WaitForSeconds(timeToSpawn);
        switch (Random.Range(0, 2))
        {
            case 0:
                Instantiate(alien, new Vector2(GameBounds.instance.BoundX + 1.2f, YlocationToSpawn), Quaternion.identity);
                break;
            case 1:
                Instantiate(alien, new Vector2(-GameBounds.instance.BoundX - 1.2f, YlocationToSpawn), Quaternion.identity);
                break;
        }
        StartCoroutine(SpawnAlien());
    }
}
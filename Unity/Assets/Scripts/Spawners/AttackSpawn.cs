using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSpawn : MonoBehaviour {

   
    [SerializeField] Attack attack;
    [SerializeField] float timeToSpawn = 1;

    private void Start()
    {
        StartCoroutine(SpawnAttack());
    }
    IEnumerator SpawnAttack()
    {
        yield return new WaitForSeconds(timeToSpawn);
        Instantiate(attack, new Vector2(Random.Range(-GameBounds.instance.BoundX + 1, GameBounds.instance.BoundX - 1), Random.Range(-GameBounds.instance.BoundY + 1, GameBounds.instance.BoundY - 1)), Quaternion.identity);
        StartCoroutine(SpawnAttack());
    }



}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawn : MonoBehaviour {

    [SerializeField] int spawners = 4;
    [SerializeField] float timeMin = 0.9f;
    [SerializeField] float timeMax = 1.3f;
    [SerializeField] Asteroid asteroid;




    // Update is called once per frame
    void Start() {
		for(int i=0;i < spawners; i++)
        {
            StartCoroutine(SpawnAsteroid());
        }
	}
    IEnumerator SpawnAsteroid()
    {
        Vector2 pos = new Vector2(Random.Range(-GameBounds.instance.BoundX, GameBounds.instance.BoundX), Random.Range(-GameBounds.instance.BoundY, GameBounds.instance.BoundY));
        switch (Random.Range(0, 4))
        {
            case 0:
                pos.x = GameBounds.instance.BoundX + 0.9f;
                break;
            case 1:
                pos.x = -GameBounds.instance.BoundX - 0.9f;
                break;
            case 2:
                pos.y = GameBounds.instance.BoundY + 0.9f;
                break;
            case 3:
                pos.y = -GameBounds.instance.BoundY - 0.9f;
                break;
        }
        Instantiate(asteroid,pos,Quaternion.identity);
        yield return new WaitForSeconds(Random.Range(timeMin, timeMax));
        StartCoroutine(SpawnAsteroid());
    }
}

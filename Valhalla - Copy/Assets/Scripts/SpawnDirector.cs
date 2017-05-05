using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDirector : MonoBehaviour
{
    public GameObject testEnemy;

	// Use this for initialization
	void Start ()
    {
        CenterPoint = new Vector3(0, 0, 15);
	}
	
	// Update is called once per frame
	void Update ()
    {
        SpawnEnemies();
	}

    float spawnDelay = 1.5f;
    void SpawnEnemies()
    {
        spawnDelay -= Time.deltaTime;
        if (spawnDelay <= 0)
        {
            GameObject e = Instantiate(testEnemy);
            e.transform.position = calcRandomSpawnPosition(e.GetComponent<Collider2D>());
            e.GetComponent<Enemy>().clone = true;
            spawnDelay = 0.15f;
        }
    }

    Vector3 CenterPoint;
    Vector3 calcRandomSpawnPosition(Collider2D col)
    {
        float randomDist = Random.Range(20 + (col.bounds.extents.x + col.bounds.extents.y), 
                                        35 + (col.bounds.extents.x + col.bounds.extents.y));
        float angle = Random.Range(0, 6.2f);
        Vector3 RandomPosition = Vector3.zero;

        RandomPosition.x = randomDist * Mathf.Cos(angle);
        RandomPosition.y = randomDist * Mathf.Sin(angle);
        RandomPosition.z = 15;
        return RandomPosition;
    }
}

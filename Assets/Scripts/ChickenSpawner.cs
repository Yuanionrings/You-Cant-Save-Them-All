using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenSpawner : MonoBehaviour
{
    public int numberOfChicks = 8;
    public List<GameObject> spawnPool;
    private static float spawnTime = 15;
    [SerializeField]private float[] spawnTimer = { spawnTime, spawnTime, spawnTime, spawnTime, spawnTime, spawnTime, spawnTime, spawnTime };
    private bool[] isSpawning = { true, true, true, true, true, true, true, true };


    void Update()
    {
        for (int i = 0; i < numberOfChicks; i++)
        {
            if (!spawnPool[i].activeSelf)
            {
                isSpawning[i] = false;
            } else
            {
                isSpawning[i] = true;
            }
        }

        for (int i = 0; i < numberOfChicks; i++)
        {
            if (!isSpawning[i])
            {
                spawnTimer[i] -= Time.deltaTime;

                if (spawnTimer[i] <= 0)
                {
                    spawnPool[i].SetActive(true);
                    spawnPool[i].gameObject.GetComponent<SpriteRenderer>().enabled = true;
                    spawnTimer[i] = 5;
                }
            }
        }
    }
}

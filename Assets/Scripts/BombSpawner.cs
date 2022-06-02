using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSpawner : MonoBehaviour
{
    public GameObject Bomb;
    public static int spawnedBombs = 0;
    public static int maxSpawnedBombs = 1;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && spawnedBombs<maxSpawnedBombs)
        {
            Instantiate(Bomb, transform.position, transform.rotation);
            spawnedBombs++;
        }
    }
}

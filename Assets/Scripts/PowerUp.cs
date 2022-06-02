using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public GameObject effect;

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player") {
            Instantiate(effect, this.gameObject.transform.position, this.gameObject.transform.rotation);
            Destroy(this.gameObject);
            BombSpawner.maxSpawnedBombs++;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructable : MonoBehaviour
{
    public GameObject explosionEffect;
    public GameObject powerUpSpawn;
    public GameObject doorObject;
    public bool doorSpawn = false;

    // Start is called before the first frame update
    public void Destroy()
    {
        Debug.Log("Destroy");
        Debug.Log(this);
        
        Instantiate(explosionEffect, transform.position, transform.rotation);
        Destroy(this.gameObject);

        
        if (doorSpawn)
        {
            Vector3 v3 = new Vector3(transform.position.x, 0, transform.position.z);
            Instantiate(doorObject, v3, transform.rotation);
            return;
        }

        if (Random.Range(0, 100) < 10)
        {
            Instantiate(powerUpSpawn, transform.position, transform.rotation);
        }


    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructable : MonoBehaviour
{
    public GameObject explosionEffect;
    public GameObject powerUpSpawn;
    public bool isPowerUp = false;

    // Start is called before the first frame update
    public void Destroy()
    {
        Debug.Log("Destroy");
        Debug.Log(this);
        
        Instantiate(explosionEffect, transform.position, transform.rotation);
        Destroy(this.gameObject);

         if (isPowerUp)
         {
             Instantiate(powerUpSpawn, transform.position, transform.rotation);

         }

    }
}

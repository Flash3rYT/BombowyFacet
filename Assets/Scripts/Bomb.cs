using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float delay = 3f;
    public float radius = 5f;

    public GameObject explosionEffect;
    //public Material[] material;
    Renderer rend;

    float countdown;
    bool hasExploded = false;


    // Start is called before the first frame update
    void Start()
    {
        countdown = delay;
        rend = transform.GetChild(0).GetComponent<Renderer>();
        //rend.enabled = true;
        //rend.sharedMaterial = material[0];
    }

    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime;
                
        float r = (3f - countdown) / 3f;

        rend.material.SetColor("_Color", new Color(r, 0, 0));
        

        if (countdown <= 0f && !hasExploded)
        {
            Explode();
            hasExploded = true;
        }
    }

    void Explode()
    {
        BombSpawner.spawnedBombs--;

        Instantiate(explosionEffect, transform.position, transform.rotation);

        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider nearbyObject in colliders)
        {
            Destructable dest;
            if (nearbyObject.TryGetComponent(out dest))
            {
                Vector3 direction = (dest.transform.position - transform.position).normalized;
                RaycastHit hit;
                if (Physics.Raycast(transform.position, direction, out hit))
                {                                        
                    if (hit.transform.gameObject == dest.gameObject) dest.Destroy();

                }
            }
        }

        Destroy(gameObject);
    }
}
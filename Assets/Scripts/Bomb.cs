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
    public bool isTrap = false;


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
        if (isTrap){
            rend.material.SetColor("_Color", new Color(0, 0, r));
        }else {
            rend.material.SetColor("_Color", new Color(r, 0, 0));
        }

        if (countdown <= 0f && !hasExploded)
        {
            Explode();
            hasExploded = true;
        }
    }

    void Explode()
    {
        if (isTrap) {
            Debug.Log("wybucha trap");
        }
        BombSpawner.spawnedBombs--;

        Instantiate(explosionEffect, transform.position, transform.rotation);

        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider nearbyObject in colliders)
        {
            if (!isTrap)
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
            

            PlayerHp playerHp;
            if (nearbyObject.TryGetComponent<PlayerHp>(out playerHp)) {
                Debug.Log("Player checking");
                Vector3 direction = (playerHp.transform.position - transform.position).normalized;
                RaycastHit hit;
                if (Physics.Raycast(transform.position, direction, out hit))
                {
                    if (Vector3.Distance(hit.point, playerHp.transform.position) < 0.5f) playerHp.TakeDamage(0.5f);
                }
            }

        }

        Destroy(gameObject);
    }
}
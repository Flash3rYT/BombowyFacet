
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHp : MonoBehaviour
{
    public GameScript gameScript;
    [SerializeField] float health, maxHealth = 3;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    public void TakeDamage(float damageAmount)
    {
        Debug.Log("damage taken");
        health -= damageAmount;

        if (health <= 0)
        {
            //Do zrobienia: Obs³u¿ œmieræ Gracza
 
        }
    }
}
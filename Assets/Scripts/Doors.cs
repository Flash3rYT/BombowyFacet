using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{
    public static GameObject maybeLevelGenerator;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log(maybeLevelGenerator);
            LevelGenerator levelGenerator = maybeLevelGenerator.GetComponent<LevelGenerator>();
            levelGenerator.GenerateLevel();
            Debug.Log("Nastêpny poziom!");
        }
    }
}

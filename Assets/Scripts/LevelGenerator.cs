using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] public TextAsset[] txtFiles;
    [SerializeField] public GameObject box;
    [SerializeField] public GameObject metal;
    [SerializeField] public GameObject player;
    [SerializeField] public int currentLevel = 0;

    void Start()
    {
        Doors.maybeLevelGenerator = this.gameObject;
        GenerateLevel();
    }


    public void GenerateLevel()
    {
        if (currentLevel == 1)
        {
            Debug.Log("Poziom 1");
            return;
        }
        string str = txtFiles[currentLevel++].ToString();
        // Debug.Log(str);
        string[] rows = str.Split('\n');
        // Debug.Log(rows[0]);
        string[] row0 = rows[0].Split(' ');
        int numberOfRows = Int32.Parse(row0[0]);
        int numberOfColumns = Int32.Parse(row0[1]);

        float dx = -(numberOfColumns - 1) / 2f;
        float dz = (numberOfRows - 1) / 2f;        

        for (int i = 1; i <= numberOfRows; i++)
        {
            for (int j = 0; j < numberOfColumns; j++)
            {
                Vector3 v3 = new Vector3(j + dx, 0.5f, -(i-1) + dz);
                Quaternion q = new Quaternion();
                if (rows[i][j] == 'P')
                {
                    v3.y = 0;
                    Instantiate(player, v3, q);
                }
                if (rows[i][j] == 'M')
                {
                    Instantiate(metal, v3, q);
                }
                if (rows[i][j] == 'B') { 
                    Instantiate(box, v3, q);
                    continue;
                }
                if (rows[i][j] == 'D')
                {
                    GameObject door = Instantiate(box, v3, q);
                    Destructable dest = door.GetComponent<Destructable>();
                    if (dest != null)
                    {
                        dest.doorSpawn = true;
                    }
                    continue;
                }
            }
        }
    }
}

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
    private List<GameObject> mapGameObjects = new List<GameObject>();

    void Start()
    {        
        Doors.maybeLevelGenerator = this.gameObject;
        GenerateLevel();
    }


    public void GenerateLevel()
    {        
        foreach (GameObject gameObject in mapGameObjects){
            Destroy(gameObject);
        }
        mapGameObjects.Clear();
        if (currentLevel >= txtFiles.Length) {
            Debug.Log("KONIEC");
            return;
        }
        string str = txtFiles[currentLevel++].ToString();        
        
        string[] rows = str.Split('\n');
        
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
                    mapGameObjects.Add(Instantiate(player, v3, q));
                    continue;
                }
                if (rows[i][j] == 'M')
                {
                    mapGameObjects.Add(Instantiate(metal, v3, q));
                    continue;
                }
                if (rows[i][j] == 'B') { 
                    mapGameObjects.Add(Instantiate(box, v3, q));
                    continue;
                }
                if (rows[i][j] == 'D')
                {
                    GameObject door = Instantiate(box, v3, q);
                    mapGameObjects.Add(door);
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

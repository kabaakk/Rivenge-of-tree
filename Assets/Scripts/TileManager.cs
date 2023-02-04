using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public GameObject[] objects;
    private int amnTileLength = 10;
    private float spawnX = -5.2f;
    private int tileLength = 1;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < amnTileLength; i++)
        {
            GameObject go = Instantiate(objects[0], transform.position, Quaternion.identity);
            go.transform.SetParent(transform);
            go.transform.localScale = new Vector3(3, 3, 3);
            go.transform.localPosition = new Vector3(spawnX, 0, 5);
            spawnX += tileLength;
        }
    }
} 

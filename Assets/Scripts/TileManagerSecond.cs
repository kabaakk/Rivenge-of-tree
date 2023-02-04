using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManagerSecond : MonoBehaviour
{
    public GameObject[] objects;
    private int amnTileLengths = 10;
    private float spawnZ = -4f;
    private int tileLength = 1;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < amnTileLengths; i++)
        {
            GameObject go = Instantiate(objects[0], transform.position, Quaternion.identity);
            go.transform.SetParent(transform);
            go.transform.localScale = new Vector3(3, 3, 3);
            go.transform.localPosition = new Vector3(5.5f, 0, spawnZ);
            go.transform.localRotation = Quaternion.Euler(0, 90, 0);
            spawnZ += tileLength;
        }   
    }
}

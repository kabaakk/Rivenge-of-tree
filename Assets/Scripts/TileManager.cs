using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public GameObject[] objects;
    private int tileLength = 1;

    public void LevelGenerateX(float spawnX, float positionY, float positionZ, int sizeX, int fenceSizeX,
        int fenceSizeY, int fenceSizeZ)
    {
        int amnTileLengthX = sizeX / fenceSizeX;
        for (int i = 0; i < amnTileLengthX; i++)
        {
            GameObject go = Instantiate(objects[0], transform.position, Quaternion.identity);
            go.transform.SetParent(transform);
            go.transform.localScale = new Vector3(fenceSizeX, fenceSizeY, fenceSizeZ);
            go.transform.localPosition = new Vector3(spawnX, positionY, positionZ);
            spawnX += tileLength;
        }
    }
} 

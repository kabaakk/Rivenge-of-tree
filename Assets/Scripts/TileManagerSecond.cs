using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManagerSecond : MonoBehaviour
{
    public GameObject[] objects;
    private int tileLength = 1;

    public void LevelGenerateY(float spawnZ, float positionX, float positionY, int sizeY, int fenceSizeX, 
        int fenceSizeY, int fenceSizeZ)
    {
        int amnTileLengthsY = sizeY / fenceSizeX;
        for (int i = 0; i < amnTileLengthsY; i++)
        {
            GameObject go = Instantiate(objects[0], transform.position, Quaternion.identity);
            go.transform.SetParent(transform);
            go.transform.localScale = new Vector3(fenceSizeX, fenceSizeY, fenceSizeZ);
            go.transform.localPosition = new Vector3(positionX, positionY, spawnZ);
            go.transform.localRotation = Quaternion.Euler(0, 90, 0);
            spawnZ += tileLength;
        }
    }
}

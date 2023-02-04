using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] spawnPoints;

    public void SpawnPointGenerator(float positionX, float positionY, float positionZ)
    {
        GameObject point = Instantiate(spawnPoints[0], new Vector3(positionX, positionY, positionZ), Quaternion.identity);
        point.transform.SetParent(transform);
    }

    public void SpawnPointGenerator2(float positionX, float positionY, float positionZ)
    {
        GameObject _point = Instantiate(spawnPoints[1], new Vector3(positionX, positionY, positionZ), Quaternion.identity);
        _point.transform.SetParent(transform);
    }
}

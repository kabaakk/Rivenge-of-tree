using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seed : MonoBehaviour
{
    public int seedSpeed = 10;

    public void SeedPrefab()
    {
        Vector3 position = AiMovement.instance.ai.position;
        transform.Translate(position * seedSpeed * Time.deltaTime);

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seed : MonoBehaviour
{
    public static Seed instance;
    public int seedSpeed = 10;

    private void Awake()
    {
        instance = this;
    }

    public void SeedPrefab()
    {
        Vector3 position = AiMovement.instance.ai.position;
        transform.Translate(position * seedSpeed * Time.deltaTime);

    }
}

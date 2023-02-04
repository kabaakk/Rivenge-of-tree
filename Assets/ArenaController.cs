using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaController : Singleton<ArenaController>
{
    
    
    private int enemySpawnCount = 0;
    private int currentSpawnCount = 0;
    private int enemyDiedCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnemyDied()
    {
        enemyDiedCount++;
        if (enemyDiedCount == enemySpawnCount)
        {
            ActionManager.instance.ArenaSurvived?.Invoke();
        }


    }
    
    
    
}

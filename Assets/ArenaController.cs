using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaController : Singleton<ArenaController>
{
    
    
    private int enemySpawnCount = 5;
    private int currentSpawnCount = 0;
    private int enemyDiedCount = 0;

    [SerializeField] private GameObject basicEnemy;
    // Start is called before the first frame update
    void Start()
    {
        ActionManager.instance.ArenaSurvivalStarted += SurvivalStarted;
        
       // SpawnEnemies();
    }


    private void SpawnEnemies()
    {

        transform.position = PlayerArenaEndShoot.instance.transform.position;
        StartCoroutine(SpawnEnemiesCoroutine());


    }

    
    private void SurvivalStarted()
    {
        enemyDiedCount = 0;
        SpawnEnemies();
    }
    private IEnumerator SpawnEnemiesCoroutine()
    {
        for(int i=0;i<enemySpawnCount;i++)
        {
            Vector3 randomOffset = Random.onUnitSphere * 20;
            randomOffset.y = 0;
            Instantiate(basicEnemy, transform.position + randomOffset, Quaternion.identity);
            yield return new WaitForSeconds(0.3f);
        }
        
        
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

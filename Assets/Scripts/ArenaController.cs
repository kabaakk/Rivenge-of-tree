using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaController : Singleton<ArenaController>
{
    
    
    private int enemySpawnCount = 5;
    private int enemyDiedCount = 0;

    [SerializeField] private List<AiMovement> basicEnemies;
    
    int currentAreaLevel = 0;
    // Start is called before the first frame update
    void Start()
    {
        ActionManager.instance.ArenaSurvivalStarted += SurvivalStarted;
        ActionManager.instance.ArenaSurvived += ArenaSurvived;
        ActionManager.instance.PlayerDied += PlayerDied;
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
            var vector2 = Random.insideUnitCircle.normalized * 15f;
            Vector3 randomOffset = new Vector3(vector2.x, 0, vector2.y);
            randomOffset.y = 0;
            Instantiate(basicEnemies[Random.Range(0,Mathf.Clamp(currentAreaLevel,0,basicEnemies.Count))], transform.position + randomOffset, Quaternion.identity);
            yield return new WaitForSeconds(0.3f);
        }
        
        
    }
   

    public void EnemyDied()
    {
        enemyDiedCount++;
        if (enemyDiedCount == enemySpawnCount)
        {
            ActionManager.instance.ArenaSurvived?.Invoke();
        }


    }

    private void ArenaSurvived()
    {
        
        currentAreaLevel++;
       
        enemySpawnCount += 5;
        
    }


    private void PlayerDied()
    {
        //Despawn enemies
       
        List<AiMovement> enemies = new List<AiMovement>(FindObjectsOfType<AiMovement>());
        foreach (var enemy in enemies)
        {
            Destroy(enemy.gameObject);
        }
        
    }
    
    
}

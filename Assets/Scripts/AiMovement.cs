using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.AI;

public class AiMovement : MonoBehaviour
{
    public static AiMovement instance;
    protected NavMeshAgent nav;
    public CharacterHealthSystem chs;
    protected Transform target;

    protected bool isDead = false;

    [SerializeField] protected float health = 20f;
    [SerializeField] private float damageAmount = 20f;
    [SerializeField] private float damageTimer = 0.3f;

    private float timerCounter = 0f;
    // Start is called before the first frame update
    protected void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        target = PlayerArenaEndShoot.instance.transform;
        chs = target.GetComponent<CharacterHealthSystem>();
        
      
    }

    // Update is called once per frame
    protected void Update()
    {
        if (isDead)
        {
            return;
        }
        float distance = Vector3.Distance(target.position, transform.position);

        nav.SetDestination(target.position);
        //FaceTarget();

        if (distance <= 1)
        {
            timerCounter += Time.deltaTime;
            if (timerCounter >= damageTimer)
            {
                chs.GetDamage(damageAmount);
                timerCounter = 0f;
            }
            
            
        
        }
    }

  

    public void TakeDamage(float damageAmount)
    {
        
        health -= damageAmount;
        if (health <= 0)
        {
            isDead = true;
            ArenaController.instance.EnemyDied();
            GetComponent<Collider>().enabled = false;
            GetComponent<NavMeshAgent>().enabled = false;
            StartCoroutine(DyingCoroutine());
        }
        
      
        
        
    }

    private IEnumerator DyingCoroutine()
    {
        GetComponentInChildren<Animation>().Stop();
        GetComponentInChildren<Animation>().enabled = false;
        
        transform.DORotate(Vector3.right*90f, 0.5f);
        transform.DOJump(transform.position, 0.5f, 1, 0.5f);
        
        yield return new WaitForSeconds(1f);


        transform.DOScale(Vector3.zero, 0.3f).OnComplete(() => Destroy(gameObject));


    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiRanged : AiMovement
{
    [SerializeField] private FireBall _fireBall;
    
    [SerializeField] private float fireBallTimer = 5f;
    private float currentFireBallTimer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    protected void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        nav.SetDestination(target.position);

        if (distance <= nav.stoppingDistance+2f)
        {
            currentFireBallTimer += Time.deltaTime;
            if (currentFireBallTimer >= fireBallTimer)
            {
                //shoot fireball
                //FaceTarget();
                FireBall fireBall = Instantiate(_fireBall, transform.position, transform.rotation);
                fireBall.transform.LookAt(target);
                currentFireBallTimer = 0f;
            }
           
            
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AiMovement : MonoBehaviour
{
    public static AiMovement instance;
    NavMeshAgent nav;
    public CharacterHealthSystem chs;
    public CharacterMovement movement;
    public Transform ai;
    Transform target;

    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        target = movement.player;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        nav.SetDestination(target.position);

        if (distance <= 1)
        {
            if (chs.health > 0)
            {
                //attack animation;
                FaceTarget();
                chs.GetDamage(0.2f);
            }
        }
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }
}

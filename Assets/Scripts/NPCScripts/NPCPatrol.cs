using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class NPCPatrol : MonoBehaviour
{
    //[field: SerializeField] public Transform target { get; private set; }
    [SerializeField] Animator characterAnimation;
    [SerializeField] AnimationClip walkClip;
    [SerializeField] AnimationClip idleClip;

    [SerializeField] Transform shin;
    [SerializeField] LayerMask groundedMask;
    [SerializeField] LayerMask slopeMask;

    RaycastHit groundedCastHit;
    public NavMeshAgent navMeshAgent;

    public Vector3 patrolPosition;
    public Vector3 patrol;
    public Transform[] patrolPoint;
    public int patrolTimer;

    Vector3 targetPosition;
    Vector3 newPosition;
    Vector3 velocity;

    public Vector2 forwardDirection;
    public bool patrolling;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        //StartCoroutine(PatrolPosition());
    }

    // Update is called once per frame
    void Update()
    {
        //HandleCharacterMovement();
    }

    public void HandleCharacterMovement()
    {
        patrolPosition = new Vector3(transform.position.x, 0, transform.position.z);

        newPosition = targetPosition - patrolPosition;

        if (Vector3.Distance(patrolPosition, targetPosition) > .1f && patrolling && navMeshAgent.isStopped == false)
        {
                newPosition = newPosition.normalized;
                /*transform.position = Vector3.SmoothDamp(patrolPosition, targetPosition, ref velocity, .5f, 2);

                Quaternion rotate = Quaternion.LookRotation(newPosition);
                Quaternion smoothRotate = Quaternion.Slerp(transform.rotation, rotate, .05f);
                transform.rotation = smoothRotate;*/

            navMeshAgent.destination = targetPosition;

            if (!characterAnimation.GetNextAnimatorStateInfo(0).IsName(walkClip.name))
            {
                AnimationsManager.instance.PlayAnimation(characterAnimation, walkClip, .1f);
            }
        }
        else if (Vector3.Distance(patrolPosition, targetPosition) <= .1f || !NavMesh.SamplePosition(targetPosition, out NavMeshHit hit, 5.0f, NavMesh.AllAreas))
        {
            StartCoroutine(PatrolPosition());
        }
    }
   

public IEnumerator PatrolPosition()
    {
        int patrolIndex;
        patrolling = false;
        navMeshAgent.isStopped = true;

        if (!characterAnimation.GetNextAnimatorStateInfo(0).IsName(idleClip.name))
        {
            AnimationsManager.instance.PlayAnimation(characterAnimation, idleClip, .1f);
        }

        for (int i = 0; i < patrolPoint.Length; i++)
        {
            patrolIndex = Random.Range(0, patrolPoint.Length);
            targetPosition = new Vector3(Random.Range(transform.position.x, patrolPoint[patrolIndex].position.x), 0, Random.Range(transform.position.z, patrolPoint[patrolIndex].position.z));
        }

        yield return new WaitForSeconds(Random.Range(0, patrolTimer));
        navMeshAgent.isStopped = false;
        patrolling = true;
    }
}

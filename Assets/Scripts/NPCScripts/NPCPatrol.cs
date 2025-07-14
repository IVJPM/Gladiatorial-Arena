using System.Collections;
using UnityEngine;

public class NPCPatrol : MonoBehaviour
{
    [field: SerializeField] public Transform target { get; private set; }
    [SerializeField] Animator characterAnimation;
    [SerializeField] AnimationClip moveClip;
    [SerializeField] AnimationClip idleClip;

    public Vector3 patrolPosition;
    public Vector3 patrol;
    public Transform[] patrolPoint;
    [SerializeField] Vector2 collisionPosition;

    Vector3 targetPosition;
    Vector3 newPosition;
    Vector3 velocity;

    public Vector2 forwardDirection;
    public bool patrolling;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(PatrolPosition());
    }

    // Update is called once per frame
    void Update()
    {
        HandleCharacterMovement();
    }

    public void HandleCharacterMovement()
    {
        patrolPosition = new Vector3(transform.position.x, 0, transform.position.z);

        newPosition = targetPosition - patrolPosition;

        if (Vector3.Distance(patrolPosition, targetPosition) > 2f && patrolling)
        {
            newPosition = newPosition.normalized;
            transform.position = Vector3.SmoothDamp(patrolPosition, targetPosition, ref velocity, .5f, 2);
            
            Quaternion rotate = Quaternion.LookRotation(newPosition);
            Quaternion smoothRotate = Quaternion.Slerp(transform.rotation, rotate, .15f);
            transform.rotation = smoothRotate;
        }
        else if (Vector3.Distance(patrolPosition, targetPosition) <= 2f)
        {
            print("p");
            StartCoroutine(PatrolPosition());
        }
    }


    IEnumerator PatrolPosition()
    {
        int patrolIndex;
        patrolling = false;
        
        for (int i = 0; i < patrolPoint.Length; i++)
        {
            patrolIndex = Random.Range(0, patrolPoint.Length);
            targetPosition = new Vector3(Random.Range(transform.position.x, patrolPoint[patrolIndex].position.x), 0, Random.Range(transform.position.z, patrolPoint[patrolIndex].position.z));
        }

        yield return new WaitForSeconds(2);
        patrolling = true;
        Debug.Log(targetPosition);
    }
}

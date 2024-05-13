using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] GameObject target;
    public Rigidbody enemyRB { get; private set; }

    public bool chasingPlayer { get; private set; }
    public float enemyRunSpeed;
    

    // Start is called before the first frame update
    void Start()
    {
        enemyRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //transform.forward = (target.transform.position - transform.position) * -1;
        // float xRot = transform.rotation.x;
        // xRot = 0;

        // transform.LookAt(target.transform.position);

        //Quaternion xRot = Quaternion.Euler(transform.position.x, target.transform.position.y, transform.position.z);
        //Quaternion enemyRotation = Quaternion.LookRotation(transform.forward, Vector3.up);
        //Quaternion enemyLook = Quaternion.RotateTowards(enemyRotation, xRot, 90);

        //transform.rotation = xRot;
    }

    public void HandleEnemyMovement()
    {
        Vector3 targetPosition = target.transform.position;
        targetPosition.y = transform.position.y;

        float followDistance = Vector3.Distance(transform.position, targetPosition);

        if (followDistance < 5f && followDistance > 1f)
        {
            chasingPlayer = true;
            
            transform.LookAt(targetPosition);

            enemyRB.velocity = (transform.position - targetPosition);
            transform.position -= enemyRB.velocity * enemyRunSpeed * Time.deltaTime;
        }
        else
        {
            chasingPlayer = false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine;

public class CameraControls : MonoBehaviour
{
    [SerializeField] Transform player;
    public Camera camObject;
    PlayerInputManager playerInputManager;

    [SerializeField] Transform cameraPivotTransform;

    [Header("Camera Settings")]
    private float cameraSmoothSpeed = .25f;
    private float upDownRotationSpeed = 40;
    private float leftRightRotationSpeed = 50;
    [SerializeField] float minPivot = -20; // Lowest point to look down
    [SerializeField] float maxPivot = 40; // Highest point to look up
    [SerializeField] float cameraCollisionOffset = .2f;
    [SerializeField] LayerMask collideWithLayers;

    [Header("Camera Values")]
    private Vector3 cameraVelocity;
    private Vector3 cameraObjectPosition;
    [SerializeField] float leftRightLookAngle;
    [SerializeField] float upDownLookAngle;
    public float cameraHorizontalInput;
    public float cameraVerticalInput;
    private float defaultCameraPosition;
    private float targetCameraPosition;


    //private void Awake()
    /*{
        if (instance == null)
        {
            instance = this;
        }

        else
        {
            Destroy(gameObject);
        }

    }*/

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        defaultCameraPosition = camObject.transform.localPosition.z;
        playerInputManager = GameObject.Find("Player").GetComponent<PlayerInputManager>();
    }

    private void LateUpdate()
    {
        HandleCameraActions();
        if (playerInputManager == null)
        {
            Debug.Log("There's no camera found");
        }
    }

    
    public void HandleCameraActions()
    {
        if (player != null)
        {
            FollowTarget();
            HandleCameraRotations();
            HandleCameraCollisions();
        }
    }

    private void FollowTarget()
    {
        Vector3 targetCameraPosition = Vector3.SmoothDamp(transform.position, player.transform.position, ref cameraVelocity, cameraSmoothSpeed * Time.deltaTime);
        transform.position = targetCameraPosition;
       
    }

    private void HandleCameraRotations()
    {
        leftRightLookAngle -= (playerInputManager.cameraVerticalInput * leftRightRotationSpeed) * Time.deltaTime;
        upDownLookAngle += (playerInputManager.cameraHorizontalInput * upDownRotationSpeed) * Time.deltaTime;

        upDownLookAngle = Mathf.Clamp(upDownLookAngle, minPivot, maxPivot);

        Vector3 cameraRotation = Vector3.zero;
        cameraRotation.y = leftRightLookAngle;
        Quaternion targetRotation = Quaternion.Euler(cameraRotation);
        transform.rotation = targetRotation;

        cameraRotation = Vector3.zero;
        cameraRotation.x = upDownLookAngle;
        targetRotation = Quaternion.Euler(cameraRotation);
        cameraPivotTransform.localRotation = targetRotation;
    }

    private void HandleCameraCollisions()
    {
        targetCameraPosition = defaultCameraPosition;
        RaycastHit hit;
        Vector3 direction = camObject.transform.position - cameraPivotTransform.position;
        direction.Normalize();

        if (Physics.SphereCast(cameraPivotTransform.position, cameraCollisionOffset, direction, out hit, Mathf.Abs(targetCameraPosition), collideWithLayers))
        {
            float distanceFromHitObject = Vector3.Distance(cameraPivotTransform.position, hit.point);
            targetCameraPosition = -(distanceFromHitObject - cameraCollisionOffset);
        }

        if (Mathf.Abs(targetCameraPosition) < cameraCollisionOffset)
        {
            targetCameraPosition = -cameraCollisionOffset;
        }

        cameraObjectPosition.z = Mathf.Lerp(camObject.transform.localPosition.z, targetCameraPosition, .2f);
        camObject.transform.localPosition = cameraObjectPosition;
    }
}

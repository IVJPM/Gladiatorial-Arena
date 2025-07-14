using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControls : MonoBehaviour
{
    [SerializeField] PlayerInputManager playerInputManager;
    public Camera camObject;

    [SerializeField] Transform cameraPivotTransform;

    [Header("Camera Settings")]
    public float cameraSmoothSpeed = .25f;
    public float upDownRotationSpeed = 100;
    public float leftRightRotationSpeed = 100;
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
        //playerInputManager = GameObject.Find("Player").GetComponent<PlayerInputManager>();
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
        if (playerInputManager != null)
        {
            FollowTarget();
            HandleCameraRotations();
            HandleCameraCollisions();
        }
    }

    private void FollowTarget()
    {
        Vector3 targetCameraPosition = Vector3.SmoothDamp(transform.position, playerInputManager.transform.position, ref cameraVelocity, cameraSmoothSpeed );
        //Vector3 targetCameraPosition = Vector3.Lerp(transform.position, playerInputManager.transform.position, .5f);
        transform.position = targetCameraPosition;
       
    }

    private void HandleCameraRotations()
    {

        leftRightLookAngle += (playerInputManager.cameraVerticalInput * leftRightRotationSpeed) * Time.smoothDeltaTime;
        upDownLookAngle += (playerInputManager.cameraHorizontalInput * upDownRotationSpeed) * Time.smoothDeltaTime;

        upDownLookAngle = Mathf.Clamp(upDownLookAngle, minPivot, maxPivot);

        Vector3 cameraRotation = Vector3.zero;
        cameraRotation.y = leftRightLookAngle;
        Quaternion targetRotation = Quaternion.Euler(cameraRotation);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 1f);

        cameraRotation = Vector3.zero;
        cameraRotation.x = upDownLookAngle;
        targetRotation = Quaternion.Euler(cameraRotation);
        cameraPivotTransform.localRotation = Quaternion.Slerp(cameraPivotTransform.localRotation, targetRotation, 1f);
    }

    private void HandleCameraCollisions()
    {
        targetCameraPosition = defaultCameraPosition + .5f;
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

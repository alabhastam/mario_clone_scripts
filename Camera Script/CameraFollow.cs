using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public float resetSpeed = 0.5f;
    public float cameraSpeed = 0.3f;

    public Bounds cameraBounds; // Not used in this improved version

    private Transform target;
    private float offsetZ;
    private Vector3 lastTargetPosition;
    private Vector3 currentVelocity;
    private bool followsPlayer; 

    void Awake() {
        BoxCollider2D myCol = GetComponent<BoxCollider2D>();
        myCol.size = new Vector2 (Camera.main.aspect * 2f * Camera.main.orthographicSize,15f);
    }

    void Start()
    {
        target = GameObject.FindGameObjectWithTag(Tags.PLAYER_TAG).transform;
        lastTargetPosition = target.position;
        offsetZ = (transform.position - target.position).z;
        followsPlayer = true;
    }

    void FixedUpdate()
    {
        if (followsPlayer)
        {
            Vector3 targetDelta = target.position - lastTargetPosition;//not uesd in new version
            lastTargetPosition = target.position;//some times if player not in camera initially thats help 

            Vector3 newCameraPosition = Vector3.SmoothDamp(transform.position, target.position + Vector3.forward * offsetZ, ref currentVelocity, cameraSpeed);
            transform.position = new Vector3(newCameraPosition.x, transform.position.y, newCameraPosition.z);
        }
    }
}

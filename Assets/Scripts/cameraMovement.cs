using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Classes;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Player Player;
    public bool IsLockedToPlayer = false;
    public bool IsSmoothFollowingPlayer = false;
    public float InterpolationTime = 0.4f;
    private Vector3 PlayerCurrentPosition;
    private Vector3 CameraCurrentPosition;
    private Vector3 newCameraPosition;
    private Vector3 targetInterpolationPosition;
    private Vector3 velocity = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        CameraCurrentPosition = this.gameObject.transform.position;
        newCameraPosition = new Vector3(CameraCurrentPosition.x, CameraCurrentPosition.y, CameraCurrentPosition.z);
        targetInterpolationPosition = new Vector3(CameraCurrentPosition.x, CameraCurrentPosition.y, CameraCurrentPosition.z);
    }

    // Update is called once per frame
    void Update()
    {
      
    }
    private void LateUpdate()
    {
        PlayerCurrentPosition = Player.transform.position;
        CameraCurrentPosition = this.gameObject.transform.position;

        // Camera modes - TODO: change this to a class or enum, to make SWITCH statements
        if (IsLockedToPlayer)
        {
            newCameraPosition.x = PlayerCurrentPosition.x;
            newCameraPosition.y = PlayerCurrentPosition.y;
            //this.gameObject.transform.position = newCameraPosition;
        }
        else if (IsSmoothFollowingPlayer)
        {

            targetInterpolationPosition = new Vector3(PlayerCurrentPosition.x, PlayerCurrentPosition.y, CameraCurrentPosition.z);
            newCameraPosition = Vector3.SmoothDamp(CameraCurrentPosition, targetInterpolationPosition, ref velocity, InterpolationTime);
        }
        this.gameObject.transform.position = newCameraPosition;
    }
    private void FixedUpdate()
    {

    }
}

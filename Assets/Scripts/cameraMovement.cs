using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Classes;
using UnityEngine;

public class cameraMovement : MonoBehaviour
{
    public Player Player;
    public bool IsLockedToPlayer = false;
    public bool IsSmoothFollowingPlayer = false;
    public float InterpolationTime = 0.4f;
    public float TriggerDistance = 400f;
    private Vector3 PlayerCurrentPosition;
    private Vector3 CameraCurrentPosition;
    private Vector3 currentDistance;
    private Vector3 newCameraPosition;
    private Vector3 originInterpolationPosition;
    private Vector3 targetInterpolationPosition;
    private bool shouldInterpolate;
    private float xCamInterpolation;
    private float yCamInterpolation;
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
        // this.gameObject.transform.position = Player.transform.position;
    }
    private void FixedUpdate()
    {
        PlayerCurrentPosition = Player.transform.position;
        CameraCurrentPosition = this.gameObject.transform.position;
        currentDistance = CameraCurrentPosition - PlayerCurrentPosition;

        // Camera modes - TODO: change this to a class or enum, to make SWITCH statements
        if (IsLockedToPlayer)
        {
            newCameraPosition.x = PlayerCurrentPosition.x;
            newCameraPosition.y = PlayerCurrentPosition.y;
        }
        else if (IsSmoothFollowingPlayer) 
        {
            /*
             - Chequear distancia entre camara y jugador
             - Si es mayor, hay que interpolar
             - Guardar la posicion de la camara 
             
             
             
             
             
             
             */



            shouldInterpolate = (targetInterpolationPosition - PlayerCurrentPosition).magnitude > TriggerDistance; // <<<< - Creo que acá está el tema, se pisa y se pone true
            if (shouldInterpolate)
            {
                // At least esto funciona xdxd
                Debug.Log("current distance: " + currentDistance.magnitude + " greater than trigger: " + TriggerDistance + " , moving camera to target");

                targetInterpolationPosition = PlayerCurrentPosition;
                originInterpolationPosition = CameraCurrentPosition;
                xCamInterpolation = Mathf.Lerp(originInterpolationPosition.x, targetInterpolationPosition.x, InterpolationTime);
                yCamInterpolation = Mathf.Lerp(originInterpolationPosition.y, targetInterpolationPosition.y, InterpolationTime);
                shouldInterpolate = false;
                newCameraPosition.x = xCamInterpolation;
                newCameraPosition.y = yCamInterpolation;
            } 
       
        }
        this.gameObject.transform.position = newCameraPosition;
    }
}

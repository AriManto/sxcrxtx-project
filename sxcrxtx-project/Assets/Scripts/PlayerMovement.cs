using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Classes;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Player player;
    public float speed;
    public float maxSpeed;
    public int rotationSpeed;
    Vector3 playerPosition;
    Vector3 input;
    float steering;
    Vector3 rotation;
    Quaternion newRotation;
    // Start is called before the first frame update
    void Start()
    {
        
        playerPosition = player.gameObject.transform.position;
        input = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"),0);
        speed = 0.25f;
        rotationSpeed = 1;

    }

    // Update is called once per frame
    void Update()
    {
        input = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"),0);
        steering = Input.GetAxisRaw("Horizontal") * rotationSpeed;
        //Debug.Log("steering:" + steering);
        rotation = new Vector3(0,0,-steering);
        newRotation = player.gameObject.transform.rotation;
        newRotation.eulerAngles += rotation;
        // Debug.Log("speed:" + rotationSpeed + " | steering: " + steering + " | eulerAngles:" + rotation.eulerAngles);
        // playerPosition = playerPosition + (input * speed);
        // Debug.Log(newRotation.eulerAngles.z);
        // float deltaTime = Time.fixedDeltaTime;
        player.gameObject.transform.SetPositionAndRotation(playerPosition, newRotation);
        
        // Debug.Log(input.ToString());
    }
}

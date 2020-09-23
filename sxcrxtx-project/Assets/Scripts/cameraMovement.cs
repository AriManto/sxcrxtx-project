using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Classes;
using UnityEngine;

public class cameraMovement : MonoBehaviour
{
    public Player Player;
    public bool IsTrackingPlayer = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // this.gameObject.transform.position = Player.transform.position;
    }
    private void FixedUpdate()
    {
        if (IsTrackingPlayer) this.gameObject.transform.position = new Vector3(Player.transform.position.x,Player.transform.position.y, -7);
    }
}

using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Classes;
using UnityEngine;
using UnityEngine.UI;

public class SystemsContainer : MonoBehaviour
{
    public Player Player;
    public Button DmgButton;
    // Start is called before the first frame update
    void Start()
    {
        DmgButton.GetComponent<Button>().onClick.AddListener(() => { 
            Player.Health.RemoveHitpoints(1); 
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

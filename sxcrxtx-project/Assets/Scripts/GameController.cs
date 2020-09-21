using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Assets.Scripts.Classes;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.XR.WSA.Input;

public class GameController : MonoBehaviour
{
    public Player Player;
    public Button DmgButton;
    public Button HealButton;
    public Toggle ToggleTestPanel;
    public GameObject TestPanel;
    // Start is called before the first frame update
    void Start()
    {
        DmgButton.GetComponent<Button>().onClick.AddListener(() => { 
            Player.Health.RemoveHitpoints(1); 
        });
        HealButton.GetComponent<Button>().onClick.AddListener(() => {
             Player.Health.AddHitpoints(1);
         });
        ToggleTestPanel.onValueChanged.AddListener(panelEventListener);
    }
    void panelEventListener(bool active)
    {
        TestPanel.gameObject.SetActive(active);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

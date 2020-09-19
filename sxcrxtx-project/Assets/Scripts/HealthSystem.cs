using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Classes;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class HealthSystem : MonoBehaviour
{
    public float _hitpoints;
    public Player healthObject; // Reference to the object with hitpoints
    public Text TextElement; // HUD element

    #region Properties
    public float Hitpoints
    {
        get
        {
            return _hitpoints;
        }
        set
        {
            this._hitpoints = value;
        }
    }
    public bool IsAlive { get
        {
            return this._hitpoints > 0;
        }
    }
    #endregion
    public void AddHitpoints (float value)
    {
        this._hitpoints += value;
    }
    public void RemoveHitpoints (float value)
    {
        this._hitpoints -= value;
    }

    // Start is called before the first frame update
    void Start()
    {
        this._hitpoints = 3;
    }

    // Update is called once per frame
    void Update()
    {
        this.TextElement.text = "HP: " + this._hitpoints.ToString();
    }
}

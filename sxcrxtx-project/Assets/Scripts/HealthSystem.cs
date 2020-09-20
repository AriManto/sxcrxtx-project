﻿using Assets.Scripts.Classes;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    #region Properties
    public float _hitpoints;
    public IEntity healthObject { get;set; } // Reference to the entity with hitpoints
    
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
        // test value
        // this._hitpoints = 3;
    }

    // Update is called once per frame
    void Update()
    {
        // this.TextElement.text = "HP: " + this._hitpoints.ToString();
    }
}

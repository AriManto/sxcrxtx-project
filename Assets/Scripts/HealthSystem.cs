using Assets.Scripts.Classes;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class HealthSystem : MonoBehaviour
{
    #region Properties
    public float _hitpoints;
    //public IEntity healthObject { get;set; } // Reference to the entity with hitpoints - not needed? perhaps for death trigger
    
    public float Hitpoints
    {
        get
        {
            return _hitpoints;
        }
        set
        {
            if (value < 0)
            {
                value = 0;
            }
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
        Hitpoints += value;
    }
    public void RemoveHitpoints (float value)
    {
        Hitpoints -= value;
        if (Hitpoints < 0) Hitpoints = 0; // 0 is the minimum HP value
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

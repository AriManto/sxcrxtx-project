using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Classes;
using UnityEngine;

public class Enemy : MonoBehaviour, IEnemy
{
    public HealthSystem Health { get; set; }
    public float StartingHitpoints { get { return _startingHitpoints; } set { _startingHitpoints = value; } }
    public float _startingHitpoints = 1;
    public float CollisionDamage { get { return _collisionDamage; } set { _collisionDamage = value >= 0 ? value: 1; } } // Default to 1 if set to negative
    public float _collisionDamage = 1;
    public float Size { get { return _size; } set { _size = value > 0 ? value : 1; } } // Default to 1 if set to 0 or negative
    public float _size = 1;

    // Start is called before the first frame update
    public void Start()
    {
        Health = gameObject.AddComponent<HealthSystem>();
        StartingHitpoints = 1f;
        Health.AddHitpoints(StartingHitpoints);
    }

    // Update is called once per frame
    public void Update()
    {
        
    }
}

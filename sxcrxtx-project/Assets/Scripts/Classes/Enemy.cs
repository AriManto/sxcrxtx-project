using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Classes;
using UnityEngine;

public class Enemy : MonoBehaviour, IEntity
{
    public HealthSystem Health { get; set; }
    public float StartingHitpoints { get; set; }
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

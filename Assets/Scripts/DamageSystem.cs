using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Classes;
using UnityEngine;

public class DamageSystem : MonoBehaviour
{
    public Player target; // HealthSystem dependency
    
    public void DoDamage(float dmg = 1)
    {
        target.Health.RemoveHitpoints(dmg);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using UnityEngine;
using System.Collections;

namespace Assets.Scripts.Classes
{
    public interface IEntity
    {

        HealthSystem Health { get; set; }
        float StartingHitpoints { get; set; }
        // Use this for initialization
        void Start();

        // Update is called once per frame
        void Update();

    }
}
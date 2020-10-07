using UnityEngine;
using System.Collections;

namespace Assets.Scripts.Classes
{
    public interface IEntity
    {
        HealthSystem Health { get; set; }
        float StartingHitpoints { get; set; }

        void TakeDamage(float dmg);
    }
}
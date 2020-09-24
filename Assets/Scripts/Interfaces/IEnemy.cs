using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Classes;
using UnityEngine;

public interface IEnemy : IEntity
{
    float CollisionDamage { get; set; }

    float Size { get; set; }
}


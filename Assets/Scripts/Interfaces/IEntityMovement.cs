using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Classes;
using UnityEngine;

public interface IEntityMovement
{
    // GameObject Entity { get; set; }
    float Speed { get; set; }
    void Move();

}

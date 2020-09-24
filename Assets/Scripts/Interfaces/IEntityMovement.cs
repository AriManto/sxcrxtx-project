using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Classes;
using UnityEngine;

public interface IEntityMovement
{
    IEntity Entity { get; set; }
    float Speed { get; set; }
    void Move();

}

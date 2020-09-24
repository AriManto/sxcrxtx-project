using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWeapon
{
    float FireRate { get; set; }
    float DamagePerRound { get; set; }
    float? Ammo { get; set; }
    float? MagSize { get; set; }
    float? ReloadSpeed { get; set; }

    void Shoot(GameObject target);

}

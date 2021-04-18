using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Classes;
using UnityEngine;

public class DisparoScript : MonoBehaviour
{
    public GameObject hitEffect;
    public float damageAmount = 1;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        IEntity entity = collision.collider.gameObject.GetComponent<IEntity>();
        if (!(entity is null))
        {
            entity.TakeDamage(damageAmount);
        }
        Destroy(effect, 2f);
        Destroy(gameObject);
    }
}

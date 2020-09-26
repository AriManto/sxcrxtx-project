using UnityEngine;
using System.Collections;
using Assets.Scripts.Interfaces;

namespace Assets.Scripts.Classes
{
    public class HealthPack : MonoBehaviour, IInteractableObject
    {
        public Collider2D Collider2D { get; set ; }
        public float healingValue = 1f;
        // Use this for initialization
        void Start()
        {
            Collider2D = gameObject.GetComponent<Collider2D>();
            Collider2D.enabled = true;
            Collider2D.isTrigger = true;
            gameObject.GetComponent<ParticleSystem>().Play();
        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnCollisionEnter2D(Collision2D collision)
        {

        }
        private void OnTriggerEnter2D(Collider2D collider)
        {
            if (collider.gameObject.tag.Equals("Player"))
            {
                Debug.Log("Healing " + collider.gameObject.tag + " by " + healingValue);
                Player player = collider.gameObject.GetComponent<Player>();
                player.AddHitpointsToPlayer(healingValue);
            }
        }
    }
}
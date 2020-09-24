using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.UIElements;
using TMPro;

namespace Assets.Scripts.Classes
{
    public class Player : MonoBehaviour, IEntity
    {
        #region Properties and attributes
        public string Name;
        /* --- HP STUFF --- */
        public HealthSystem Health { get; set; }
        public float StartingHitpoints { get { return _StartingHitpoints; } set { _StartingHitpoints = value; } }
        public float _StartingHitpoints = 3;

        public Text HpIndicator; // Reference to the HP indicator for the player

        /* --- MOVEMENT STUFF --- */
        public PlayerMovement PlayerMovement { get; set; }

        /* --- DEBUG TOGGLES  --- */
        public bool _debugHP = false;
        #endregion
        public void Start()
        {
            // Initialize HealthSystem
            Health = gameObject.AddComponent<HealthSystem>();
            Health.AddHitpoints(StartingHitpoints);
            HpIndicator.text = "HP: " + Health.Hitpoints;
        }

        public void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.collider.tag.Equals("Enemy"))
            {
                Enemy enemy = collision.collider.gameObject.GetComponent<Enemy>();
                Health.RemoveHitpoints(enemy.CollisionDamage);
                // TODO: Add invincibility for 1 sec (with fade effect) - invincibility timer, invincible status. setTimeout?
                CheckAliveState();  // This should go into HealthSystem to handle each entity dead state
            }
        }
        public void CheckAliveState()
        {
            HpIndicator.text = "HP: " + Health.Hitpoints;
            if (_debugHP) Debug.Log("HP:" + this.Health.Hitpoints);
            if (!Health.IsAlive)
            {
                // Do stuff when ded
                Debug.Log("U'RE DED M8");
            }
        }
    }
}
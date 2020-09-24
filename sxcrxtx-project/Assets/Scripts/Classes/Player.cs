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
        //public PlayerMovement Movement;
        // public float maxVelocity = 3.5f;
        public float speed = 38000f;
        public float rotationInterpolation = 0.4f;
        private KeyCode brakingKeyCode = KeyCode.Space;
        private float defaultLinearDrag = 0.8f;
        public float brakingLinearDrag = 4f;
        public bool isBraking = false;
        private Rigidbody2D rb;
        [HideInInspector]
        public bool isMoving;
        Vector2 input;
        float facingAngle;


        /* --- DEBUG TOGGLES  --- */
        public bool _debugHP = false;
        public bool _debugVelocity = false;
        #endregion
        public void Start()
        {
            Health = gameObject.AddComponent<HealthSystem>();
            Health.AddHitpoints(StartingHitpoints);
            rb = GetComponent<Rigidbody2D>();

        }

        // Update is called once per frame
        private void FixedUpdate()
        {
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");
            isMoving = (input.x != 0 || input.y != 0) ? true : false; // Ternary operator, it's a fix to stop player from rotating to initial position
            isBraking = Input.GetKey(brakingKeyCode);
            //TODO: move this to an event in healthSystem (like "OnHitpointsChanged")
            HpIndicator.text = "HP: " + Health.Hitpoints;
            if (_debugHP) Debug.Log("HP:" + this.Health.Hitpoints);


            rb.AddForce(input * speed * Time.deltaTime, ForceMode2D.Force);
                                   /* // Cap maximum velocity [not needed]
                                    * if (rb.velocity.sqrMagnitude != maxVelocity * maxVelocity)
                                        rb.velocity = rb.velocity.normalized * maxVelocity;*/
            if (isMoving) GetRotation();
            rb.drag = isBraking ? brakingLinearDrag : defaultLinearDrag; // Speed down while holding SPACE KEY
            if (_debugVelocity) Debug.Log(rb.velocity.magnitude);
        }
        void GetRotation()
        {
            Vector2 lookDir = new Vector2(-input.x, input.y);
            facingAngle = Mathf.Atan2(lookDir.x, lookDir.y) * Mathf.Rad2Deg;
            if (rb.rotation <= -90 && facingAngle >= 90)
            {
                rb.rotation += 360;
                
            } else if (rb.rotation >= 90 && facingAngle <= -90)
            {
                rb.rotation -= 360;
            }
            rb.rotation = Mathf.Lerp(rb.rotation, facingAngle, rotationInterpolation);
        }
        public void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.collider.tag.Equals("Enemy"))
            {
                Enemy enemy = collision.collider.gameObject.GetComponent<Enemy>();
                Health.RemoveHitpoints(enemy.CollisionDamage);
                // TODO: Add invincibility for 1 sec (with fade effect) - invincibility timer, invincible status. setTimeout?
                CheckAliveState();  // This should go into HealthSystem to handle each entity dead state

                //enemy.gameObject.SetActive(false); // Should be a Destroy or Dispose? Do damage
                
            }
        }
        public void CheckAliveState()
        {
            if (!Health.IsAlive)
            {
                // Do stuff when ded
                Debug.Log("U'RE DED M8");
            }
        }
    }
}
using UnityEngine;
using System.Collections;

namespace Assets.Scripts.Classes
{
    [System.Serializable]
    public class Player : MonoBehaviour, IEntity
    {
        public HealthSystem Health { get; set; }

        [SerializeField]
        public float StartingHitpoints { get { return _StartingHitpoints; } set { _StartingHitpoints = value; } }
        public float _StartingHitpoints = 3;

        public string Name;
        //public PlayerMovement Movement;
        public float speed = 0.2f;
        public float maxVelocity = 3.5f;
        public float rotationInterpolation = 0.4f;
        private Rigidbody2D rb;
        public bool isMoving;
        Vector2 input;
        float facingAngle;
        public bool _debugHP = false;
        // Use this for initialization
        public void Start()
        {
            Health = gameObject.AddComponent<HealthSystem>();
            Health.AddHitpoints(StartingHitpoints);
            // Movement
            rb = GetComponent<Rigidbody2D>();

        }

        // Update is called once per frame
        public void Update()
        {
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");
            isMoving = (input.x != 0 || input.y != 0) ? true : false; //Ternary operator
            if (_debugHP)
            {
                Debug.Log("HP:" + this.Health.Hitpoints);
            }
        }
        private void FixedUpdate()
        {
            //rb.velocity = input * speed * Time.deltaTime;
            rb.AddForce(input * speed * Time.deltaTime, ForceMode2D.Force);
            Debug.Log(rb.velocity.magnitude);
           /* if (rb.velocity.sqrMagnitude != maxVelocity * maxVelocity)
                rb.velocity = rb.velocity.normalized * maxVelocity;*/
            if (isMoving) GetRotation();
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
    }
}
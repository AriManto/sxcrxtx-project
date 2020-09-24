using UnityEngine;
using System.Collections;

namespace Assets.Scripts.Classes
{
    public class PlayerMovement : MonoBehaviour,IEntityMovement
    {
        // public GameObject Entity { get ; set ; } // Dependency injection
        public float Speed { get { return _speed; } set { _speed = value; } }

        public Rigidbody2D rb;
        // Keys config
        private KeyCode brakingKeyCode = KeyCode.Space;
        private KeyCode boostingKeyCode = KeyCode.LeftShift;
        private KeyCode brakingJoystickKeyCode = KeyCode.JoystickButton0; // Left trigger
        private KeyCode boostingJoystickKeyCode = KeyCode.JoystickButton1; // Right trigger
        
        // Speed config
        public float _speed = 30000f;
        public float boostSpeed = 75000f;
        public float rotationInterpolation = 0.3f;
        private float boostRotationInterpolation = 0.1f;
        public float brakingLinearDrag = 4f;
        private float defaultLinearDrag = 0.8f;
        
        // Flags
        public bool isBraking = false;
        public bool isBoosting = false;
        public bool isMoving = false;
        Vector2 input;
        float facingAngle;
        public void Move()
        {
            // :)
            throw new System.NotImplementedException();
        }

        private void FixedUpdate()
        {
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");
            // Check the flags - movement state
            isMoving = (input.x != 0 || input.y != 0) ? true : false; // Ternary operator, it's a fix to stop player from rotating to initial position
            isBraking = Input.GetKey(brakingKeyCode) || Input.GetKey(brakingJoystickKeyCode);
            isBoosting = Input.GetKey(boostingKeyCode) || Input.GetKey(boostingJoystickKeyCode);
            if (!isBoosting)
            {
                rb.AddForce(input * _speed * Time.deltaTime, ForceMode2D.Force);
            } else
            {
                rb.AddForce(input * boostSpeed * Time.deltaTime, ForceMode2D.Force);
            }
            if (isMoving) GetRotation();
            rb.drag = isBraking ? brakingLinearDrag : defaultLinearDrag; // Speed down while holding SPACE KEY
        }
        void GetRotation()
        {
            Vector2 lookDir = new Vector2(-input.x, input.y);
            //float interpolationToUse;
            facingAngle = Mathf.Atan2(lookDir.x, lookDir.y) * Mathf.Rad2Deg;
            if (rb.rotation <= -90 && facingAngle >= 90)
            {
                rb.rotation += 360;

            }
            else if (rb.rotation >= 90 && facingAngle <= -90)
            {
                rb.rotation -= 360;
            }
            //interpolationToUse = (!isBoosting) ? rotationInterpolation : boostRotationInterpolation;
            //rb.rotation = Mathf.Lerp(rb.rotation, facingAngle, interpolationToUse);
            rb.rotation = Mathf.Lerp(rb.rotation, facingAngle, rotationInterpolation);
        }


        // Use this for initialization
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
using UnityEngine;
using System.Collections;

namespace Assets.Scripts.Classes
{
    public class PlayerMovement : MonoBehaviour,IEntityMovement
    {
        public IEntity Entity { get ; set ; } // Dependency injection
        public float Speed { get ; set; }

        public void Move()
        {
            throw new System.NotImplementedException();
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
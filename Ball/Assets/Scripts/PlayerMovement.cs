using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WildBall.Inputs
{

    [RequireComponent(typeof(Rigidbody))]

    public class PlayerMovement : MonoBehaviour
    {
        private Rigidbody playerRb;
      
        [SerializeField, Range(0, 10)] private float speed = 2.0f;

        public Vector3 jump;

        private void Awake()
        {
            playerRb = GetComponent<Rigidbody>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("SpeedUp"))
                speed = speed * 3;
        }
        private void OnTriggerExit(Collider other)
        {
            ResetValues();
        }
        public void MoveCharacter(Vector3 movement)
        {
            playerRb.AddForce(movement * speed);
        }

        public void ResetValues()
        {
            speed = 2;
        }

    }

}


using UnityEngine;

namespace WildBall.Inputs
{
   [RequireComponent(typeof(PlayerMovement))]

    public class PlayerInput : MonoBehaviour
    {
        
        private Vector3 movement;
        private PlayerMovement PlayerMovement;

        private void Awake()
        {
            PlayerMovement = GetComponent<PlayerMovement>();
        }


        // Update is called once per frame
        void Update()
        {
            float horizontal = Input.GetAxis(GlobalStringVars.HORIZONTAL_AXIS);
            float vertical = Input.GetAxis(GlobalStringVars.VERTICAL_AXIS);

            movement = new Vector3(horizontal, 0, vertical).normalized;


        }

        private void FixedUpdate()
        {
            PlayerMovement.MoveCharacter(movement);
        }

       
    }

}

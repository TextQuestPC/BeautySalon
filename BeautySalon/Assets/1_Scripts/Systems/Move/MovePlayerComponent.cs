using UnityEngine;

namespace SystemMove
{
    public class MovePlayerComponent : MonoBehaviour
    {
        [SerializeField] private float playerSpeed = 5f;

        protected CharacterController controller;
        protected PlayerActionsExample playerInput;

        private Vector3 playerVelocity;

        private void Awake()
        {
            controller = gameObject.AddComponent<CharacterController>();
            playerInput = new PlayerActionsExample();
        }

        public void Rotate(float value)
        {
            transform.rotation = Quaternion.Euler(0,value,0);
        }

        private void Update()
        {
            Vector2 movement = playerInput.Player.Move.ReadValue<Vector2>();
            Vector3 move = new Vector3(movement.x, 0, movement.y);
            controller.Move(move * Time.deltaTime * playerSpeed);

            if (move != Vector3.zero)
            {
                gameObject.transform.forward = move;
            }

            controller.Move(playerVelocity * Time.deltaTime);
        }

        private void OnEnable()
        {
            playerInput.Enable();
        }

        private void OnDisable()
        {
            playerInput.Disable();
        }
    }
}

using UnityEngine;


    public class Player : MonoBehaviour
    {
        public PlayerInput playerInput;
        public PlayerMovement playerMovement;
        public PlayerAnimation playerAnimation;

        public BasePlayer currentState;
        private LiveState liveState = new LiveState();
        public DeadState deadState = new DeadState();



        private void Start()
        {
            currentState = liveState;
            currentState.EnterState(this);
        }


        private void FixedUpdate()
        {
            currentState?.FixedUpdate(this);
        }

        private void OnTriggerEnter(Collider other)
        {
            IInteractable interactable = other.GetComponent<IInteractable>();
            interactable?.Interact();
        }

        public void ChangeState(BasePlayer newState)
        {
            currentState = newState;
            currentState.EnterState(this);
        }



    }

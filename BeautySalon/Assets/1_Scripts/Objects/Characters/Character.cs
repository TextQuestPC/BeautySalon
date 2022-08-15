using ObjectsOnScene;
using SystemMove;
using UnityEngine;

namespace Characters
{
    public class Character : ObjectScene
    {
        [SerializeField] protected Animator animator;

        protected MoveComponent moveComponent;

        public void ChangeMove(bool move)
        {
            moveComponent.SetCanMove = move;

            if (move)
            {
                animator.SetTrigger("Move");
            }
            else
            {
                animator.SetTrigger("Idle");
            }
        }
    }
}
using ObjectsOnScene;
using SystemMove;
using UnityEngine;

namespace Characters
{
    public class Character : ObjectScene
    {
        [SerializeField] protected Animator animator;

        protected MoveComponent moveComponent;
        protected bool canMove = true;

        public void ChangeMove(bool move)
        {
            if (canMove)
            {
                moveComponent.SetMoveNow = move;

                if (move)
                {
                    animator.SetTrigger(TypeAnimationCharacter.Move.ToString());
                }
                else
                {
                    animator.SetTrigger(TypeAnimationCharacter.Idle.ToString());
                }
            }
        }
    }
}
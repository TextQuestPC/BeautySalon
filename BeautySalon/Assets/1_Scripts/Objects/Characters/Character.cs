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
            Debug.Log("Change move " + move);
            if (canMove)
            {
                if(moveComponent.MoveNow == move)
                {
                    return;
                }

                moveComponent.MoveNow = move;

                if (move)
                {
                    ShowAnimation(TypeAnimationCharacter.Move);
                }
                else
                {
                    ShowAnimation(TypeAnimationCharacter.Idle);
                }
            }
        }

        protected void ShowAnimation(TypeAnimationCharacter typeAnimation)
        {
            animator.SetTrigger(typeAnimation.ToString());
        }
    }
}
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

        private TypeAnimationCharacter prevTypeAnimation = TypeAnimationCharacter.Work;

        public void ChangeMove(bool move)
        {
            if (canMove)
            {
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
            if (prevTypeAnimation == typeAnimation)
            {
                return;
            }

            prevTypeAnimation = typeAnimation;
            animator.SetTrigger(typeAnimation.ToString());
        }
    }
}
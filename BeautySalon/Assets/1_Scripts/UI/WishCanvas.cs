using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class WishCanvas : MonoBehaviour
    {
        [SerializeField] private Image bubbleImage;
        [SerializeField] private Image wishImage;

        public void ShowWish(Sprite wishSprite)
        {
            wishImage.sprite = wishSprite;
            bubbleImage.gameObject.SetActive(true);

            if (Camera.main is null)
            {
                return;
            }
            else
            {
                transform.LookAt(transform.position + Camera.main.transform.forward);
            }
        }

        public void HideWish()
        {
            bubbleImage.gameObject.SetActive(false);
        }
    }
}
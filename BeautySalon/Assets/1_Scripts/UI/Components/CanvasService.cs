using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class CanvasService : MonoBehaviour
    {
        [SerializeField] private Slider slider;

        private float maxValue;

        public float SetMaxValue
        {
            set
            {
                maxValue = value;
                slider.maxValue = maxValue;
            }
        }

        public void ChangeValue(float newValue)
        {
            slider.value = newValue;
        }
    }
}
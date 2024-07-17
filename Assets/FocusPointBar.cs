using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SG
{
    public class FocusPointBar : MonoBehaviour
    {
        public Slider slider;

        public void SetMaxFocusPoints(float maxFocusPoints)
        {
            slider.maxValue = maxFocusPoints;
            slider.value = maxFocusPoints;
        }
        public void SetCurrentFocusPonts (float currentFocusPoints)
        {
            slider.value = currentFocusPoints;
        }
    }


}
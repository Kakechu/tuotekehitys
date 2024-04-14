using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HappinessManager : MonoBehaviour
{
    public Slider slider;
    // Start is called before the first frame update


    public void SetMinHappiness(int happiness)
    {
        slider.minValue = happiness;
        slider.value = happiness;
    }


    public void SetHappiness(int happiness)
    {
        slider.value = happiness;
    }
}


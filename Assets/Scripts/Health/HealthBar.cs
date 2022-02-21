using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
   private Slider slider;

    private void Awake()
    {
        slider = GetComponent<Slider>();
    }

    public void SetUpBar(int max)
    {
        slider.maxValue = (float)max;
        slider.value = (float)max;

        this.gameObject.SetActive(false);
    }

   public void UpdateSlider(float hp)
   {       
       slider.value = (float)hp;
   }
}

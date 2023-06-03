using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthbarFill : MonoBehaviour
{
    [SerializeField]
    [Header("References")]
    private Damageable dmg;
    public Image fillImage;
    private Slider slider;


    // Start is called before the first frame update
    void Awake()
    {
        dmg = transform.parent.parent.GetComponent<Damageable>();
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (dmg != null)
        {
            float fillValue = dmg.Health / dmg.maxHealth;
            slider.value = fillValue;
            if (fillValue <= 0)
            {
                slider.value = 0;
            }
        }
    }

    public void UpdateSlider(int amount)
    {
        if (slider != null)
        {
            slider.value += amount;
        }
    }
}

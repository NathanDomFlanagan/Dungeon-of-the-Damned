using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthbarFill : MonoBehaviour
{
    [SerializeField]
    [Header("References")]
    public Damageable dmg;
    public Image fillImage;
    private Slider slider;


    // Start is called before the first frame update
    void Awake()
    {
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        float fillValue = dmg.Health / dmg.maxHealth;
        slider.value = fillValue;
        if(fillValue <=0)
        {
            slider.value = 0;
        }
    }
}

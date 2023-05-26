using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthBar : MonoBehaviour
{
    public Transform healthBar;
    private Damageable dmg;
    private float xPos;
    private float xScal;

    // Start is called before the first frame update
    void Awake()
    {
        dmg = GetComponent<Damageable>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

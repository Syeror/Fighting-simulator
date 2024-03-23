using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class enemyHealth : MonoBehaviour
{
    private int Score = 0;
    public float value;
    public PlayerProgress playerProgress;
    public TextMeshProUGUI CountDestroyed;
    
    public void Start()
    {
        
    }
    private void Update()
    {
        
    }

    public void DealDamage(float damage)
    {


        value -= damage;
        playerProgress.AddExpirence(damage);

        if (value <= 0)
        {
            Destroy(gameObject);
            Score++;
            UpdateKillCountText();


        }
    }
    private void UpdateKillCountText()
    {
        if (CountDestroyed != null)
        {
            CountDestroyed.text =  Score.ToString();
        }
    }
}

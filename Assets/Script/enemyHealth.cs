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
    public int totalEnemies;
    public int enemiesCount;
    public static List<enemyHealth> enemies = new List<enemyHealth>();
    public void Start()
    {

        totalEnemies = enemies.Count;
        OnEnable();
       enemiesCount = enemies.Count;

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
            GameManager.Instance.OnEnemyKilled();
           Score++;
            UpdateKillCountText();
            OnDisable();
            EnemyKilled();


        }
    }
    private void UpdateKillCountText()
    {
        if (CountDestroyed != null)
        {
            CountDestroyed.text =  Score.ToString();

        }
    }
    public void EnemyKilled()
    {
        totalEnemies--;

        if (totalEnemies <= 0)
        {
            // Вызов функции победы

        }
    }
    private void OnEnable()
    {
        enemies.Add(this);
    }
    private void OnDisable()
    {
        enemies.Remove(this);
    }
}

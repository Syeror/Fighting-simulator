using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float value;
    public RectTransform ValueRectTransform;
    public float _maxValue;
    public GameObject GameplayUI;
    public GameObject GameOverScreen;
    private void Start()
    {
        _maxValue = value;
        DrawHealthBar();
    }
    public void DealDamage(float damage)
    {

        value -= damage;
        if (value <= 0)
        {
            PlayerIsDead();
        }
        DrawHealthBar();

    }
        public void AddHealth(float amount)
        {
            value += amount;
        value = Mathf.Clamp(value,0 , _maxValue);
            DrawHealthBar();
        }
    private void DrawHealthBar()
    {
        ValueRectTransform.anchorMax = new Vector2(value / _maxValue, 1);

    }
    private void PlayerIsDead()
    {
          GameplayUI.SetActive(false);
            GameOverScreen.SetActive(true);
            GetComponent<PlayerController>().enabled = false;
            GetComponent<fireballCaster>().enabled = false;
            GetComponent<CameraRotation>().enabled = false;


    }
}
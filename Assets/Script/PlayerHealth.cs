using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float value;
    public RectTransform ValueRectTransform;
    public float _maxValue;
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
            Destroy(gameObject);
        }
        DrawHealthBar();

    }
    private void DrawHealthBar()
    {
        ValueRectTransform.anchorMax = new Vector2(value / _maxValue, 1);

    }
}
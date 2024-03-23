using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Timers;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class fireballCaster : MonoBehaviour
{
    public float Damage = 10;
    public fireball FireballPrefab;
    public Transform FireballSourseControll;
    public float Cooldown = 5f;
     float cooldownTimer = 0f;
    public Image SpellIcon;

    // Start is called before the first frame update
    void Start()
    {
        Movement();
        Instantiate(FireballPrefab);
        
    }

    // Update is called once per frame
    void Update()
    {
        cooldownTimer +=  Time.deltaTime;
        UpdateUltimateIcon();
        Movement();
    }
    void Movement()
    {
        if (Input.GetMouseButtonDown(0) && cooldownTimer >= Cooldown  )
        {

            var Fireball = Instantiate(FireballPrefab, FireballSourseControll.position, FireballSourseControll.rotation);
            Fireball.Damage = Damage;
            cooldownTimer = 0;
        }
        
    }
    void UpdateUltimateIcon()
    {
        //находим текущий процент времени перезарядки (значение от 0 до 1)
        float fillAmount = 1 - cooldownTimer / Cooldown;
        //Параметр SpellIcon.fillAmount отвечает за заполнение иконки способности
        SpellIcon.fillAmount = fillAmount;
    }
}

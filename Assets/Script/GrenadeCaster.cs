using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GrenadeCaster : MonoBehaviour
{
    public float Damage = 50;
    public Rigidbody GrenadePrefab;
    public Transform GrenadeSourseTransform;
    public float Force = 10f;
    public float Cooldown = 10f;
    float cooldownTimer = 0f;
    public Image SpellIcon;
    // Start is called before the first frame update
    void Start()
    {
        Movement();
        UpdateUltimateIcon();
    }

    // Update is called once per frame
    private void Update()
    {
        cooldownTimer += Time.deltaTime;
        Movement();
    }
    void Movement()
    {
        if(Input.GetMouseButtonDown(1) && cooldownTimer >= Cooldown)
        {
          var grenade =  Instantiate(GrenadePrefab);        
            grenade.transform.position = GrenadeSourseTransform.position;
            grenade.GetComponent<Rigidbody>().AddForce(GrenadeSourseTransform.forward*Force);
            grenade.GetComponent<Grenade>().damage = Damage;
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

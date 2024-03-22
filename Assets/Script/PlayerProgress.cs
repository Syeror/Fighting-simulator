using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class PlayerProgress : MonoBehaviour
{
    public List<PlayerProgressLevel> Levels;
    public RectTransform ExpirenceValueRectTransform;
    private int _levelValue = 1;
    private float _progressCurrentValue = 0;
    private float _progressTargetValue = 100;
    public TextMeshProUGUI LevelValueTMP;

    // Start is called before the first frame update
    void Start()
    {
        SetLevel(_levelValue);
        DrawUi();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void AddExpirence(float value)
    {
        _progressCurrentValue += value;
   
        if (_progressCurrentValue >= _progressTargetValue)
        {
            SetLevel(_levelValue + 1);
            _progressCurrentValue = 0;
        }
        DrawUi();
    }
    private void SetLevel(int Value)
    {
        var CurrentLevel = Levels[_levelValue - 1];
            _levelValue += Value;
        _progressTargetValue = CurrentLevel.ExperinceForTheNextLevel;

        GetComponent<fireballCaster>().Damage = CurrentLevel.FireBallDamage;
        GetComponent<GrenadeCaster>().Damage = CurrentLevel.grenadeDamage;

        var grenadeCaster = GetComponent<GrenadeCaster>();
        grenadeCaster.Damage = CurrentLevel.grenadeDamage;

        if (CurrentLevel.grenadeDamage < 0)
        {
            grenadeCaster.enabled = false;
        }
        else
        {
            grenadeCaster.enabled = true;
        }


    }
    private void CurrentStatusGrenade()
    {
        
    }
    private void DrawUi()
    {
        ExpirenceValueRectTransform.anchorMax = new Vector2(_progressCurrentValue / _progressTargetValue, 1);
        LevelValueTMP.text = _levelValue.ToString();
    }
    


}

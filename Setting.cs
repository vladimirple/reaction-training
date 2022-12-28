using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Setting : MonoBehaviour
{
    public Slider _firstslider, _secondslider, _thirdslider, _fourslider, _fiveslider;
    public Text _firstText, _secondText, _thirdText, _fourText, _fiveText;
    float firstPress, appearanceTime, reloadTime, maxCount, lifeCount;
    [SerializeField] bool z;

    // Start is called before the first frame update
    void Start()
    {

        z = PlayerPrefs.GetInt("isOne") == 1 ? true : false;

        if (!z)
        {
            firstPress = 300;
            appearanceTime = 10;
            reloadTime = 5;
            maxCount = 7;
            lifeCount = 3;
            z = true;
            PlayerPrefs.SetInt("ISFirst", z ? 1 : 0);
        }
        GetAllSliderValue();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GetAllSliderValue()
    {
        OnFirstSliderValueChanged(firstPress);
        OnSecondSliderValueChanged(appearanceTime);
        OnThirdSliderValueChanged(reloadTime);
        OnFourSliderValueChanged(maxCount);
        OnFiveSliderValueChanged(lifeCount);
    }

    public void OnFirstSliderValueChanged(float newFirstValue)
    {
        newFirstValue = _firstslider.value;
        firstPress = newFirstValue;
        _firstText.text = ($"Время первого нажатия (мс):{firstPress}");
        PlayerPrefs.SetFloat("firstPress", firstPress);
    }

    public void OnSecondSliderValueChanged(float newSecondValue)
    {
        newSecondValue = _secondslider.value;
        appearanceTime = newSecondValue;
        _secondText.text = ($"Время появления мишени (мс):{appearanceTime}");
        PlayerPrefs.SetFloat("appearanceTime", appearanceTime);
    }

    public void OnThirdSliderValueChanged(float newThirdValue)
    {
        newThirdValue = _thirdslider.value;
        reloadTime = newThirdValue;
        _thirdText.text = ($"Время обновления мишени (с):{reloadTime}");
        PlayerPrefs.SetFloat("reloadTime", reloadTime);
    }

    public void OnFourSliderValueChanged(float newFourValue)
    {
        newFourValue = _fourslider.value;
        maxCount = newFourValue;
        _fourText.text = ($"Максимальное количество мишеней:{maxCount}");
        PlayerPrefs.SetFloat("maxCount", maxCount);
    }

    public void OnFiveSliderValueChanged(float newFiveValue)
    {
        newFiveValue = _fiveslider.value;
        lifeCount = newFiveValue;
        _fiveText.text = ($"Количество жизней:{lifeCount}");
        PlayerPrefs.SetFloat("lifeCount", lifeCount);
    }

}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerExp : MonoBehaviour
{
    public int currentLevel = 0;
    public int currentExperience = 0;
    public int experienceToNextLevel = 100;
    public Slider experienceSlider;
    public ShowLevelUp showLevelUp;
    // Start is called before the first frame update
    void Start()
    {
        UpdateExperienceBar();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void UpdateExperienceBar()
    {
        experienceSlider.maxValue = experienceToNextLevel;
        experienceSlider.value = currentExperience;
    }

    public void AddExperience(int amount)
    {
        currentExperience += amount;
        if (currentExperience >= experienceToNextLevel)
        {
            LevelUp();
            Debug.Log(currentLevel);
            showLevelUp.ShowUpgrade();
        }
        UpdateExperienceBar();
    }


    void LevelUp()
    {
        currentExperience -= experienceToNextLevel;
        currentLevel++;
        experienceToNextLevel = CalculateNextLevelExperience();
    }

    int CalculateNextLevelExperience()
    {
        return experienceToNextLevel + 15;
    }

}


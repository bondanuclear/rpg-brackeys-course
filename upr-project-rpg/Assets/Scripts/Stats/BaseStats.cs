using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseStats : MonoBehaviour
{
    [Range(1,80)]
    [SerializeField] int startingLevel = 1;
    [SerializeField] CharacterClass characterClass;
    [SerializeField] Progression progression;
    Experience experience;
    int currentLevel = 0;
    public int CurrentLevel {get {return currentLevel;}}
    public event Action HasLeveledUp;
    private void Start() {
        currentLevel = CalculateLevel();
        experience = GetComponent<Experience>();
        if(experience != null)
        {
            experience.OnLevelUp += UpdateLevel;
        }
    }

    private void UpdateLevel()
    {
        int newLevel = CalculateLevel();
        if(newLevel > currentLevel)
        {
            currentLevel = newLevel;
            Debug.Log($"Level up! Your current level is {currentLevel}");
            HasLeveledUp?.Invoke();
        }
    }

    public float GetStat(StatEnum stat)
    {
        return progression.GetStat(characterClass, stat, CalculateLevel());
    }
    
    public int CalculateLevel()
    {
        if(experience == null)
        {
            return startingLevel;
        }
        float curExp = experience.GetExperiencePoints();
        int maxLength = progression.GetLength(characterClass, StatEnum.ExperienceToLevelUp);
        for(int i = 1; i <= maxLength; i++)
        {
            float xpToLvlUp = progression.GetStat(characterClass, StatEnum.ExperienceToLevelUp, i);
            if(curExp < xpToLvlUp)
            {
                return i;
            }
        }
        return maxLength+1;
    }
}

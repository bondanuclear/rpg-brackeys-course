using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseStats : MonoBehaviour
{
    [Range(1,80)]
    [SerializeField] int startingLevel = 1;
    [SerializeField] CharacterClass characterClass;
    [SerializeField] Progression progression;
    public float GetStat(StatEnum stat)
    {
        return progression.GetStat(characterClass, stat, startingLevel);
    }
}

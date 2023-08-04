using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Experience : MonoBehaviour
{
    [SerializeField] float currentExperience  = 0;

    public event Action OnLevelUp;
    public float GetExperiencePoints()
    {
        return currentExperience;
    }
    public void GainExperience(float reward)
    {
        currentExperience += reward;
        OnLevelUp?.Invoke();
    }

}

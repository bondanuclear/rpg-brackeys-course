using UnityEngine;
using System.Collections.Generic;
[CreateAssetMenu(fileName = "New Progression", menuName = "Stats/Progression")]
public class Progression : ScriptableObject {
    
   [SerializeField] ProgressionCharacterClass[] progressionCharacterClass;
   Dictionary<CharacterClass, Dictionary<StatEnum, float[]>> lookUpTable = null;
    [System.Serializable]
    class ProgressionCharacterClass {
        public CharacterClass characterClass;
        public ProgressionStat[] progressionStats;
    }
    [System.Serializable]
    class ProgressionStat
    {
        public StatEnum stat;
        public float[] levels;
    }
    private void BuildLookUpTable()
    {
        lookUpTable = new Dictionary<CharacterClass, Dictionary<StatEnum, float[]>>();
        foreach(var item in progressionCharacterClass)
        {
            var lookUpHelper = new Dictionary<StatEnum, float[]>();
            foreach(var progressionStat in item.progressionStats)
            {
                lookUpHelper[progressionStat.stat] = progressionStat.levels;
            }
            lookUpTable[item.characterClass] = lookUpHelper;
        }
    }
    public int GetLength(CharacterClass characterClass, StatEnum statEnum)
    {
        if(lookUpTable == null) BuildLookUpTable();
        return lookUpTable[characterClass][statEnum].Length;
    }
    public float GetStat(CharacterClass characterClass, StatEnum stat, int level)
    {
        if (lookUpTable == null) {BuildLookUpTable();}
        if(level > lookUpTable[characterClass][stat].Length) return 0;
        return lookUpTable[characterClass][stat][level-1];
    }
}
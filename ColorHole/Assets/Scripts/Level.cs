using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Default/Level", fileName = "Level", order = 1)]
public class Level : ScriptableObject
{
    [Header("Level Variables")] 
    public int FirstStageValue;
    public int SecondStageValue;
    
}
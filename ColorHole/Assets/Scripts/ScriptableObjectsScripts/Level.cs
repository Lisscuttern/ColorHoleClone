using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Default/Level", fileName = "Level", order = 1)]
public class Level : ScriptableObject
{
    [Header("Level Variables")] 
    public int FirstStageValue;
    public int SecondStageValue;

    [Header("Level Movement Limit")]
    public float FirstStageXLimit;
    public float FirstStageZLimit;
    
    public float SecondStageMinZLimit;
    public float SecondStageMaxZLimit;
    
    [Header("Level Game Object")]
    public GameObject Prefab;


    
}
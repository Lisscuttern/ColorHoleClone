using UnityEngine;

[CreateAssetMenu(menuName = "Default/GameSettings", fileName = "GameSettings", order = 0)]
public class GameSettings : ScriptableObject
{
    public float Distance;
    public float FallForce;
}

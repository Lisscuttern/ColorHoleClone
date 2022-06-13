using UnityEngine;

[CreateAssetMenu(menuName = "Default/GameSettings", fileName = "GameSettings", order = 0)]
public class GameSettings : ScriptableObject
{
    public float Distance;
    public float FallForce;

    [Header("Gate")]
    public float GateEndPosY;

    public float GateMoveDuration;

    [Header("Camera")]
    public float CameraEndValueZ;
    
    [Header("Level")]
    public Level[] Levels;
    
    
}

using UnityEngine;

[CreateAssetMenu(fileName = "Configuration")]
public class ConfigurationSO : ScriptableObject
{
    public float PlayerJumpForce;
    public float PlayerSpeed;
    public float CameraFollowSmoothness;
    public float SpeedBuffDuration;
    public float JumpBuffDuration;
}
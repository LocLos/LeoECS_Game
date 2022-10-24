using UnityEngine;

public class EnemyPointConfig : MonoBehaviour
{
    public EnemyType Type;

    [Range(1, 100)]
    public int Hp;

    [Range(1, 30)]
    public int Damage;

    [Range(.5f, 1)]
    public int EffectiveDistance;

    [Range(1, 30)]
    public int MoveSpeed;
}

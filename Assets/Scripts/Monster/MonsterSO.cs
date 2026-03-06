using UnityEngine;

/// <summary>
/// 기본 스탯만 들고 있을 ScriptableObject
/// </summary>
[CreateAssetMenu(fileName = "MonsterSO", menuName = "Scriptable Objects/MonsterSO")]
public class MonsterSO : ScriptableObject
{
    /// <summary>
    /// 몬스터의 기본 체력
    /// </summary>
    public float baseHp = 10;
    /// <summary>
    /// 몬스터의 기본 데미지
    /// </summary>
    public float baseDamage = 1;
    /// <summary>
    /// 몬스터의 기본 이동 속도
    /// </summary>
    public float baseMoveSpeed = 2;
    /// <summary>
    /// 몬스터의 기본 경험치
    /// </summary>
    public float baseXP = 1;
}

using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// 플레이어의 스탯 타입
/// </summary>
public enum StatType
{
    MoveSpeed,
    PlayerDamage,
    ExpMagnetRadius,
}

[CreateAssetMenu(fileName = "PlayerStatSO", menuName = "Scriptable Objects/PlayerStatSO")]
public class PlayerStatSO : ScriptableObject
{
    /// <summary>
    /// 플레이어의 이동속도
    /// </summary>
    public List<float> moveSpeed;
    /// <summary>
    /// 플레이어의 자체 데미지
    /// </summary>
    public List<float> playerDamage;
    /// <summary>
    /// 플레이어의 경험치 획득 범위
    /// </summary>
    public List<float> expMagnetRadius;
}

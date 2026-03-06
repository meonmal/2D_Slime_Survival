using UnityEngine;

public struct MonsterStatRuntime
{
    /// <summary>
    /// 런타임용 몬스터 HP
    /// </summary>
    public float hp;
    /// <summary>
    /// 런타임용 몬스터 Damage
    /// </summary>
    public float damage;
    /// <summary>
    /// 런타임용 몬스터 MoveSpeed
    /// </summary>
    public float moveSpeed;
    /// <summary>
    /// 런타임용 몬스터 XP
    /// </summary>
    public float xp;

    /// <summary>
    /// ScriptableObject의 기본 몬스터 데이터를 기반으로
    /// 런타임 몬스터 스탯을 초기화한다.
    /// </summary>
    /// <param name="so">몬스터 스탯의 원본 데이터</param>
    /// <param name="hpMul">몬스터의 런타임용 HP</param>
    /// <param name="dmgMul">몬스터의 런타임용 Damage</param>
    /// <param name="spdMul">몬스터의 런타임용 MoveSpeed</param>
    /// <param name="xpMul">몬스터의 런타임용 XP</param>
    public MonsterStatRuntime(MonsterSO so, float hpMul, float dmgMul, float spdMul, float xpMul)
    {
        this.hp = so.baseHp * hpMul;
        this.damage = so.baseDamage * dmgMul;
        this.moveSpeed = so.baseMoveSpeed * spdMul;
        this.xp = so.baseXP * xpMul;
    }
}

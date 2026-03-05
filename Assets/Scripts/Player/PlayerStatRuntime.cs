using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatRuntime
{
    /*
    Dictionary. 
    키와 값을 쌍으로 저장하는 자료구조다.
    쉽게 말해서 이 키를 넣으면 이 값을 바로 찾는다. 이런 구조다.
    아래의 코드로 예시를 들자면 
    키가 StatType.MoveSpeed이라면 그에 대한 값은 data.moveSpeed를 바로 찾는다는 의미다.
    외부에서는 StatRuntime stat = stats[StatType.MoveSpeed]; 이렇게 찾아야 한다.
     */

    /// <summary>
    /// StatType을 키로 해서 각 스탯의 런타임 데이터를 관리하는 Dictionary
    /// 단순히 값을 찾는게 아니라
    /// StatType -> StatRuntime 이 구조로 스탯 런타임 상태를 관리하는거다.
    /// </summary>
    private Dictionary<StatType, StatRuntime> stats;

    /// <summary>
    /// PlayerStatSO에 저장된 스탯 데이터를 기반으로
    /// 런타임 스탯 Dictionary를 초기화하는 생성자
    /// </summary>
    /// <param name="data">플레이어 스탯이 저장된 ScriptableObject 데이터</param>
    public PlayerStatRuntime(PlayerStatSO data)
    {
        stats = new Dictionary<StatType, StatRuntime>
        {
            {StatType.MoveSpeed, new StatRuntime(data.moveSpeed) },
            {StatType.PlayerDamage, new StatRuntime(data.playerDamage) },
            {StatType.ExpMagnetRadius, new StatRuntime(data.expMagnetRadius) },
        };
    }

    /// <summary>
    /// 외부에서 값을 가져갈 때 쓸 함수
    /// </summary>
    /// <param name="type">쓸 스탯의 키</param>
    /// <returns>현재 레벨에 해당하는 스탯의 값</returns>
    public float GetStat(StatType type) => stats[type].Values;

    /// <summary>
    /// 지정한 스탯의 레벨을 1 증가시킨다.
    /// </summary>
    /// <param name="type">레벨업 할 스탯의 타입</param>
    public void LevelUp(StatType type) => stats[type].LevelUp();

    /// <summary>
    /// 지정한 스탯이 최대 레벨인지 확인한다.
    /// </summary>
    /// <param name="type">확인할 스탯의 타입</param>
    /// <returns>최대 레벨이면 true</returns>
    public bool IsMax(StatType type) => stats[type].IsMax;
}

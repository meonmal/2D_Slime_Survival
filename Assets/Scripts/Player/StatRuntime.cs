using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class StatRuntime
{
    /// <summary>
    /// 스탯의 현재 레벨
    /// </summary>
    private int level;
    /// <summary>
    /// 스탯의 값
    /// IReadOnlyList : 읽기 전용 컬렉션. 말 그대로 특정 컬렉션을 읽기 전용으로 만든다.
    /// </summary>
    private IReadOnlyList<float> values;

    /*
    생성자. 
    클래스가 생성될 때(new 할 때) 자동으로 실행되는 함수다.
    이름이 클래스의 이름과 같고 반환 타입이 없다.
    또한 생성자는 여러개 만들 수 있다.
     */

    /// <summary>
    /// 스탯 객체를 처음 만들 때 초기 상태를 설정하는 함수.
    /// ex. new StatRuntime(data.moveSpeed) -> values = moveSpeed 리스트
    /// </summary>
    /// <param name="values">스탯의 값</param>
    public StatRuntime(IReadOnlyList<float> values)
    {
        this.values = values;
        level = 0;
    }

    /// <summary>
    /// 스탯의 값에 대한 프로퍼티. 레벨이 0 아래로 가거나 values,Count 이상이 되지 못하도록 한다.
    /// </summary>
    public float Values => values[Mathf.Clamp(level, 0, values.Count - 1)];
    /// <summary>
    /// 최대 레벨에 대한 프로퍼티
    /// 레벨이 values.Count -1과 같거나 크면 최대 레벨이다.
    /// </summary>
    public bool IsMax => level >= values.Count - 1;

    /// <summary>
    /// 레벨업을 하는 함수.
    /// </summary>
    public void LevelUp()
    {
        // 레벨 + 1을 하되 0아래로는 안 되게, values.Count와 같아지진 못하게 2차로 막는다.
        level = Mathf.Clamp(level + 1, 0, values.Count - 1);
    }
}

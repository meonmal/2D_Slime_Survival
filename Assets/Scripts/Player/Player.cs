using UnityEngine;

public class Player : MonoBehaviour
{
    /// <summary>
    /// 스탯의 원본 데이터
    /// </summary>
    [SerializeField]
    private PlayerStatSO data;

    /// <summary>
    /// 스탯의 값을 가져오기 위한 변수
    /// </summary>
    private PlayerStatRuntime runtime;


    private void Awake()
    {
        // 스탯 가져오기
        runtime = new PlayerStatRuntime(data);
    }

    /// <summary>
    /// 사용할 스탯의 값을 가져온다.
    /// </summary>
    /// <param name="type">가져올 값의 타입</param>
    /// <returns></returns>
    public float GetStat(StatType type)
    {
        return runtime.GetStat(type);
    }

    /// <summary>
    /// 스탯을 레벨업하는 함수
    /// </summary>
    /// <param name="type">레벨업 할 스탯의 타입</param>
    public void LevelUp(StatType type)
    {
        runtime.LevelUp(type);
    }
}

using UnityEngine;
using UnityEngine.Pool;

public class Monster : MonoBehaviour
{
    /// <summary>
    /// 몬스터 오브젝트 풀링을 위한 변수
    /// </summary>
    private IObjectPool<Monster> pool;
    /// <summary>
    /// 몬스터의 원본 데이턴
    /// </summary>
    [SerializeField]
    private MonsterSO so;

    private MonsterMovement monsterMovement;

    private float hp;
    private float damage;
    private float moveSpeed;
    private float xp;

    public float HP => hp;
    public float Damage => damage;
    public float MoveSpeed => moveSpeed;
    public float XP => xp;

    public void SetPool(IObjectPool<Monster> pool)
    {
        this.pool = pool;
    }

    private void Awake()
    {
        monsterMovement = GetComponent<MonsterMovement>();   
    }

    public void Init(MonsterSO so, in MonsterStatRuntime stats)
    {
        this.so = so;

        hp = stats.hp;
        damage = stats.damage;
        moveSpeed = stats.moveSpeed;
        xp = stats.xp;

        gameObject.SetActive(true);
    }

    public void SetTarget(Rigidbody2D targetRigidbody2D)
    {
        monsterMovement.SetTarget(targetRigidbody2D);
    }

    public void Despawn()
    {
        gameObject.SetActive(false);
        pool.Release(this);
    }
}

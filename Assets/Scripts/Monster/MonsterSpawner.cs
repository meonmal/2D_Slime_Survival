using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

public class MonsterSpawner : MonoBehaviour
{
    [Header("스폰 범위")]
    [SerializeField]
    private float minSpawnPos;
    [SerializeField]
    private float maxSpawnPos;

    [Header("스폰 설정")]
    [SerializeField]
    private float spawnTime;
    [SerializeField]
    private int spawnCount;
    [SerializeField]
    private int maxAliveMonsterCount;

    [Header("참조")]
    [SerializeField]
    private Monster[] monsterPrefabs;
    [SerializeField]
    private Rigidbody2D target;
    [SerializeField]
    private MonsterSO so;

    [Header("시간 증가 설정")]
    [SerializeField]
    private float increaseInterval;
    [SerializeField]
    private int increaseAmount;

    private IObjectPool<Monster> pool;
    private MonsterStatRuntime statRuntime;

    private int aliveMonsterCount;

    private void Awake()
    {
        pool = new ObjectPool<Monster>(
            CreateMonster,
            OnGet,
            OnRelease,
            OnDestroyMonster);
    }

    private void Start()
    {
        StartCoroutine(Spawn());
        StartCoroutine(IncreaseSpawnCount());
    }

    private IEnumerator Spawn()
    {
        while (true)
        {
            int canSpawnCount = maxAliveMonsterCount - aliveMonsterCount;

            if(canSpawnCount > 0)
            {
                int currentSpawnCount = Mathf.Min(spawnCount, canSpawnCount);

                for (int i = 0; i < currentSpawnCount; i++)
                {
                    Monster monster = pool.Get();

                    float hpMul = 1.1f;
                    float dmgMul = 1.05f;
                    float spdMul = 1.01f;
                    float xpMul = 1.05f;

                    statRuntime = new MonsterStatRuntime(so, hpMul, dmgMul, spdMul, xpMul);

                    monster.transform.position = SpawnMonsterPosition();
                    monster.SetTarget(target);
                    monster.Init(so, statRuntime);
                }
            }

            yield return new WaitForSeconds(spawnTime);
        }
    }

    private IEnumerator IncreaseSpawnCount()
    {
        while (true)
        {
            yield return new WaitForSeconds(increaseInterval);
            spawnCount += increaseAmount;
            maxAliveMonsterCount += increaseAmount;
        }
    }

    private Vector2 SpawnMonsterPosition()
    {
        Vector2 randomDirection = Random.insideUnitCircle.normalized;
        float randomDistance = Random.Range(minSpawnPos, maxSpawnPos);

        Vector2 playerPosition = target.position;
        Vector2 spawnPosition = playerPosition + randomDirection * randomDistance;

        return spawnPosition;
    }

    private Monster CreateMonster()
    {
        int index = Random.Range(0, monsterPrefabs.Length);
        Monster clone = Instantiate(monsterPrefabs[index]);

        clone.SetPool(pool);
        clone.transform.parent = this.transform;

        return clone;
    }

    private void OnGet(Monster monster)
    {
        aliveMonsterCount++;
        monster.gameObject.SetActive(true);
    }

    private void OnRelease(Monster monster)
    {
        aliveMonsterCount--;
        monster.gameObject.SetActive(false);
    }

    private void OnDestroyMonster(Monster monster)
    {
        Destroy(monster.gameObject);
    }
}

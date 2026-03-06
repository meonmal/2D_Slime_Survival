using UnityEngine;

public class MonsterMovement : MonoBehaviour
{
    [SerializeField]
    private float maxDistance;
    [SerializeField]
    private float minReSpawnDistance;
    [SerializeField]
    private float maxReSpawnDistance;

    private Rigidbody2D target;

    private Rigidbody2D rigid;
    private Monster monster;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        monster = GetComponent<Monster>();
    }

    public void SetTarget(Rigidbody2D rigidbody2D)
    {
        target = rigidbody2D;
    }

    private void Update()
    {
        RePosition();
    }

    private void FixedUpdate()
    {
        Movement();
    }

    private void Movement()
    {
        Vector2 directionToTarget = (target.position - rigid.position).normalized;

        Vector2 movementDelta = directionToTarget * monster.MoveSpeed * Time.fixedDeltaTime;

        rigid.MovePosition(rigid.position + movementDelta);
    }

    private void RePosition()
    {
        Vector2 offset = target.position - rigid.position;

        /// Distance가 아닌 sqrMagnitude로 쓰는 이유
        /// Distnace는 내부적으로 제곱근까지 계산해서 성능적으로 조금은 좋지 않음
        /// 복잡한 계산을 할 때에는 Distance가 더 낫겠지만 
        /// 지금은 단순 거리를 계산하는 것이기에 sqrMagnitude가 더 나음
        /// magnitude도 루트 연산이 들어가서 상대적으로 좀 더 비싼 연산이다.
        if (offset.sqrMagnitude > maxDistance * maxDistance)
        {
            Vector2 randomDirection = Random.insideUnitCircle.normalized;
            float randomDistance = Random.Range(minReSpawnDistance, maxReSpawnDistance);

            Vector2 newPosition = target.position + randomDirection * randomDistance;
            rigid.position = newPosition;


        }
    }
}

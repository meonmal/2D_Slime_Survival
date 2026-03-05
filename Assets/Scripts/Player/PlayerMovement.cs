using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    /// <summary>
    /// 플레이어의 이동속도
    /// </summary>
    private float moveSpeed;

    /// <summary>
    /// MoveSpeed의 값을 가져오기 위한 컴포넌트
    /// </summary>
    private Player player;
    /// <summary>
    /// 플레이어의 리지드바디2D
    /// </summary>
    private Rigidbody2D rigid;

    private void Awake()
    {
        // 컴포넌트 가져오기
        player = GetComponent<Player>();
        rigid = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        /// 왜 이 작업을 Awake가 아닌 Start에서 하느냐?
        /// Awake에서 실행한 결과 GetStat이 null이 터짐
        /// Player에서 런타임을 가져오는 작업도 Awake에서 하기 때문
        /// 때문에 Awake보다 한 템포 늦게 실행되는 Start에서 실행
        moveSpeed = player.GetStat(StatType.MoveSpeed);
    }

    private void FixedUpdate()
    {
        Movement();
    }

    /// <summary>
    /// Rigidbody2D를 이용해서 플레이어를 이동시키는 함수
    /// </summary>
    private void Movement()
    {
        // 입력값 받아오기
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        // 받아온 입력값을 정규화해서 넣어주기
        Vector2 moveDir = new Vector2(horizontal, vertical).normalized;

        // 위에서 받은 값과 Rigidbody2D를 이용해 실제로 움직이게 만든다.
        rigid.linearVelocity = moveDir * moveSpeed;
    }
}

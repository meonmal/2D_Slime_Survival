using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField]
    private Transform target;

    private void LateUpdate()
    {
        Follow();
    }

    private void Follow()
    {
        transform.position = new Vector3(target.position.x, target.position.y, -10);
    }
}

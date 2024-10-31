using Unity.VisualScripting;
using UnityEngine;

public class FollowTargetX : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Vector3 offset;

    private Vector3 targetPosX;

    private void Update()
    {
        targetPosX = new(target.position.x, this.transform.position.y, 0);
        targetPosX += offset;
        this.transform.position = targetPosX;
    }
}

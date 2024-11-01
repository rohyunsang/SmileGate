using UnityEngine;

public class HallManager : MonoBehaviour
{
    [SerializeField] Transform respawnPoint;
    [SerializeField] Transform target;
    [SerializeField] Transform railRespawnPoint;
    [SerializeField] Transform rail;
    [SerializeField] RailController railController;

    private void Start()
    {
        target = GameObject.FindWithTag("Player").GetComponent<Transform>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            target.position = respawnPoint.position;
            MainManager.instance.playerController.stat.healthCount--;
        }

        if(this.gameObject.tag == "RailHole")
        {
            rail.transform.position = railRespawnPoint.position;
            railController.ChangeState(railController._idleState);
        }
    }
}

using UnityEngine;

public class HallManager : MonoBehaviour
{
    [SerializeField] Transform respawnPoint;
    [SerializeField] Transform target;

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
    }
}

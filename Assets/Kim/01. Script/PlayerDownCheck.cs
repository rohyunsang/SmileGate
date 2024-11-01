using UnityEngine;

public class PlayerDownCheck : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Hole"))
            MainManager.instance.playerController.stat.downState = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Hole"))
            MainManager.instance.playerController.stat.downState = false;
    }
}

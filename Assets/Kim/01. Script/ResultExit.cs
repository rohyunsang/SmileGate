using UnityEngine;

public class ResultExit : MonoBehaviour
{
    private void Start()
    {
        Invoke(nameof(EndScene), 5);
    }

    void EndScene()
    {
        Application.Quit();
    }
}

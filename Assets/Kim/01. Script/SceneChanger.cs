using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void OnClickStartBtn()
    {
        SceneManager.LoadScene("Opening");
    }
}

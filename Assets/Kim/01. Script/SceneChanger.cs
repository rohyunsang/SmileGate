using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    private void Start()
    {
        AudioManager.Instance.PlayBgm(AudioManager.BGM.BGM_Title);
    }
    public void OnClickStartBtn()
    {
        SceneManager.LoadScene("Opening");
    }
}

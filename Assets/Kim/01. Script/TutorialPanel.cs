using UnityEngine;

public class TutorialPanel : MonoBehaviour
{
    public GameObject tutorialPanel;

    private void Start()
    {
        if (tutorialPanel.activeSelf)
        { tutorialPanel.SetActive(false); }
    }
    public void CheckPanelActivation()
    {
        if (tutorialPanel.activeSelf)
        {
            tutorialPanel.SetActive(false);
            Time.timeScale = 1;
        }
    }
}

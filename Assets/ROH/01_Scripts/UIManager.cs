using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{
    #region Singleton Pattern
    public static UIManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(this.gameObject);
    }
    #endregion


    /// <summary>
    /// Init All Button Listener
    /// </summary>
    void Start()
    {
        // Start Screen
        _startButton.onClick.AddListener(OnClickStartButton);

        // Main Screen
        _topBarToggleButton.onClick.AddListener(OnClickTopBarToggleButton);
        _yesButton.onClick.AddListener(OnClickYesButton);
    }


    #region StartScreen
    [SerializeField] private GameObject _startScreen;
    [SerializeField] private Button _startButton;

    private void OnClickStartButton()
    {
        _startScreen.SetActive(false);
    }



    #endregion

    #region MainScreen

    [SerializeField] private Button _topBarToggleButton;
    [SerializeField] private GameObject _topBar;
    [SerializeField] private Button _yesButton;

    private void OnClickTopBarToggleButton()
    {
        // _topBar의 활성화 상태를 반대로 설정
        _topBar.SetActive(!_topBar.activeSelf);

    }

    private void OnClickYesButton()
    {
        GameManager.Instance.OnApplicationQuit();
    }



    #endregion


}

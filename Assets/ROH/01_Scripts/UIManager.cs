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
        _startButton.onClick.AddListener(OnClickStartButton);


        _topBarToggleButton.onClick.AddListener(OnClickTopBarToggleButton);
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

    private void OnClickTopBarToggleButton()
    {
        // _topBar�� Ȱ��ȭ ���¸� �ݴ�� ����
        _topBar.SetActive(!_topBar.activeSelf);

    }



    #endregion


}

using Cysharp.Threading.Tasks;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static object _lock = new object();
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            lock (_lock)
            {
                if (_instance == null)
                {
                    _instance
                        = FindObjectOfType<GameManager>();
                    if (_instance == null)
                    {
                        var singletonObject = new GameObject();
                        _instance = singletonObject.AddComponent<GameManager>();
                        singletonObject.name = nameof(GameManager) + "(singleton)";
                    }
                }

                return _instance;
            }
        }
    }

    [SerializeField]
    private Title _titleScene;
    [SerializeField]
    private GameObject _gameScene;
    [SerializeField]
    private Result _resultScene;

    [SerializeField]
    private PlayerCtrl _playerCtrl;

    [SerializeField]
    private GameStartCountDown _gameStartCountDown;

    private bool _isGame = false;
    public bool IsGame => _isGame;

    public int Score = 0;

    private void Start()
    {
        _playerCtrl.SetAnimation("Run");
    }

    public async void ChangeScene(SceneType type)
    {
        switch (type)
        {
            case SceneType.Title: 
                _titleScene.gameObject.SetActive(true);
                _gameScene.SetActive(_isGame);
                _playerCtrl.ActivateInput(false);
                break;
            case SceneType.Game:
                _titleScene.gameObject.SetActive(false);
                _gameStartCountDown.gameObject.SetActive(true);
                await _gameStartCountDown.CountDownAsync();
                _titleScene.StopBackGroundAnimation();
                _isGame = true;
                _gameScene.SetActive(_isGame);
                _playerCtrl.ActivateInput(true);
                break;
            case SceneType.Result:
                _isGame = false;
                _resultScene.gameObject.SetActive(true);
                _gameScene.SetActive(_isGame);
                _playerCtrl.ActivateInput(false);
                _resultScene.SetScore(Score);
                break;
        }
    }
}

public enum SceneType
{
    Title,
    Game,
    Result
}
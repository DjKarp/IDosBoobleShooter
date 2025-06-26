using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameLauncherButton : MonoBehaviour
{
    [SerializeField] private GameDefinition _gameToLaunch;
    private Button _button;
    [SerializeField] private TextMeshProUGUI _textMesh;
    [SerializeField] private Image _image;

    private void Awake()
    {
        _button = GetComponent<Button>();
        if (_button != null)
            _button.onClick.AddListener(OnClick);

        if (_textMesh != null)
            _textMesh.text = "Play On " + _gameToLaunch.GameName.ToString();

        if (_image != null)
            _image.sprite = _gameToLaunch.Icon;
    }

    public void OnClick()
    {
        if (_gameToLaunch != null)
        {
            // Сохраняем выбранную игру в глобальную переменную перед загрузкой сцены
            LoadingSceneManager.GameToLoad = _gameToLaunch;
            UnityEngine.SceneManagement.SceneManager.LoadScene(SCENES.LOADING_SCENE);
        }
        else
        {
            Debug.LogWarning("GameDefinition не назначен.");
        }
    }
}

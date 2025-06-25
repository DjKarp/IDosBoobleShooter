using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using TMPro;

public class LoadingSceneManager : MonoBehaviour
{
    public static GameDefinition GameToLoad;

    [SerializeField] private GameDefinition _gameToLoad;
    private TextMeshProUGUI _loadingText;
    private float _fakeLoadDelay = 1f;

    private void Awake()
    {
        _loadingText = gameObject.GetComponentInChildren<TextMeshProUGUI>();
    }

    private void Start()
    {
        if (GameToLoad == null)
        {
            Debug.LogError("Нет игры для загрузки.");
            GameToLoad = _gameToLoad;
        }

        StartCoroutine(LoadGameAsync());
    }

    private IEnumerator LoadGameAsync()
    {
        _loadingText.text = $"Loading {GameToLoad.GameName}...";

        yield return new WaitForSeconds(_fakeLoadDelay); // визуальная пауза

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(GameToLoad.SceneName);

        while (!asyncLoad.isDone)
        {
            _loadingText.text = $"Loading... {Mathf.RoundToInt(asyncLoad.progress * 100)}%";
            yield return null;
        }
    }
}

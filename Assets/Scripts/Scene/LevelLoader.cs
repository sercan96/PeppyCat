using System.Collections;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    public Slider progressBar;
    public static LevelLoader Instance;
    [SerializeField] private GameObject loaderCanvas;
    private float target;
    private AsyncOperation sceneLoadingOperation;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        LoadScene("Game");
    }

    public void LoadScene(string sceneName)
    {
        target = 0;
        progressBar.value = 0;

        StartCoroutine(LoadSceneAsync(sceneName));
    }

    private IEnumerator LoadSceneAsync(string sceneName)
    {
        loaderCanvas.SetActive(true);

        sceneLoadingOperation = SceneManager.LoadSceneAsync(sceneName);
        sceneLoadingOperation.allowSceneActivation = false;

        while (sceneLoadingOperation.progress < 0.9f)
        {
            progressBar.value = sceneLoadingOperation.progress;
            yield return null;
        }

        yield return new WaitForSeconds(1f);

        sceneLoadingOperation.allowSceneActivation = true;
        loaderCanvas.SetActive(false);
    }

    private void Update()
    {
        if (sceneLoadingOperation != null)
        {
            target = sceneLoadingOperation.progress;
            progressBar.value = Mathf.MoveTowards(progressBar.value, target, 3 * Time.deltaTime);
        }
    }
}

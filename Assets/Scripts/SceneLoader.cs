using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public string targetSceneName; // Açılacak sahnenin adı

    public void LoadTargetScene()
    {
        SceneManager.LoadScene(targetSceneName);
    }
}

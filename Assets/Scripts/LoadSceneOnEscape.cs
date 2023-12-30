using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneOnEscape : MonoBehaviour
{
    public string targetSceneName; // A�?lacak sahnenin ad?

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            LoadTargetScene();
        }
    }

    void LoadTargetScene()
    {
        SceneManager.LoadScene(targetSceneName);
    }
}

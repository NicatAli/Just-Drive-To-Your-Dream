using UnityEngine;

public class QuitApplication : MonoBehaviour
{
    public void Quit()
    {
        // Uygulamayı kapat
        Application.Quit();

        // Not: Uygulama yalnızca standalone platformlarda çalıştığında kapatılabilir.
        // WebGL ve diğer platformlarda bu kod genellikle işe yaramaz.
    }
}

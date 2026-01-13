using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public AudioSource uiAudio;
    public AudioClip clickSound;

    public float sceneDelay = 0.2f; // SESÝ DUYABÝLECEK KADAR KISA

    public void PlayGame()
    {
        uiAudio.PlayOneShot(clickSound);
        Invoke(nameof(LoadGameScene), sceneDelay);
    }

    void LoadGameScene()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void QuitGame()
    {
        uiAudio.PlayOneShot(clickSound);
        Invoke(nameof(Quit), sceneDelay);
    }

    void Quit()
    {
        Application.Quit();
    }
}

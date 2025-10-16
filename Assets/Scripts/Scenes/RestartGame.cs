using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    public void RestartCurrentScene()
    {
        // Xóa dữ liệu save tránh bị load máu cũ
        PlayerPrefs.DeleteKey("PlayerHealth");
        PlayerPrefs.DeleteKey("PlayerX");
        PlayerPrefs.DeleteKey("PlayerY");
        PlayerPrefs.DeleteKey("SavedScene");
        PlayerPrefs.Save(); // Lưu lại thay đổi

        // Load lại scene
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
}

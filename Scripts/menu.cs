using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void OnPlayButton()
    {
        SceneManager.LoadScene(1);
    }
    
    public void OnCreditsButton()
    {
        SceneManager.LoadScene(5);
    }
    
    public void OnControlsButton()
    {
        SceneManager.LoadScene(6);
    }
    
    public void OnBackButton()
    {
        SceneManager.LoadScene(0);
    }
    
    public void OnQuitButton()
    {
        Application.Quit();
    }
}
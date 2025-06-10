using UnityEngine;
using UnityEngine.SceneManagement; 
public class MainMenuScript : MonoBehaviour
{
    public string firstLevel;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartGame()
    {
        SceneManager.LoadSceneAsync(0);
    }
    
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quitting");
    }
}

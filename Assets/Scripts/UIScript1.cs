using UnityEngine;
using UnityEngine.SceneManagement;

public class UIScript1 : MonoBehaviour
{
    public void OnStartClick(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
    }

    public void OnQuitClick(){
        Application.Quit();
    }
}

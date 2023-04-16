using UnityEngine;
using UnityEngine.SceneManagement;


public class UIController : MonoBehaviour
{
    public delegate void ChangeColor();
    public static event ChangeColor _changeColor;

    public void ColorChange()
    {
        _changeColor();
    }
    
    public void Exit()
    {
        Application.Quit();
    }
    
    public void Restart()
    {
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }    
}

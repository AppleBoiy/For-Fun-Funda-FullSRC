using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneScript : MonoBehaviour
{
    public void SelectScene()
    {
        switch(gameObject.name)
        {
            case "start":
                SceneManager.LoadScene("Game");
                break;
            case "Main":
                SceneManager.LoadScene("Main Menu");
                break;
            case "NEXT BTN":
                SceneManager.LoadScene("Level2");
                break;
            case "tempScene":
                SceneManager.LoadScene("LiquidScene");
                break;
            case "StartLab":
                SceneManager.LoadScene("Room1");
                break;
            case "room2":
                SceneManager.LoadScene("Room2");
                break;
            case "room3":
                SceneManager.LoadScene("Room3");
                break;
            case "room4":
                SceneManager.LoadScene("Room4");
                break;
            case "room4.2":
                SceneManager.LoadScene("R4 part 2");
                break;
            
            default:
                SceneManager.LoadScene("Main Menu");
                break;
        }
        
    }
}

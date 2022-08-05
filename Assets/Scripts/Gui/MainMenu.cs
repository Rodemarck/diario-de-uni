using UnityEngine;
using UnityEngine.SceneManagement;

namespace Gui
{
    [DisallowMultipleComponent]
    public class MainMenu : MonoBehaviour
    {
        
        public void NewGame(){
            Debug.Log("New");
        }
        public void LoadGame(){
            Debug.Log("Load");
        }
        public void Option(){
            Debug.Log("Option menu");
            SceneManager.LoadScene("OptionMenu");
        }
        public void Quit(){
            Debug.Log("Quit");
            Application.Quit();
        }
    }
}
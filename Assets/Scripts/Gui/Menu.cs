using UnityEngine;
using UnityEngine.SceneManagement;

namespace Gui
{
    public class Menu : MonoBehaviour
    {
        
        public void NovoJogo(){}
        public void CarregarJogo(){}
        public void Opcoes(){
            SceneManager.LoadScene("Menu Opcoes");
        }
        public void Sair(){
            Application.Quit();
        }
    }
}
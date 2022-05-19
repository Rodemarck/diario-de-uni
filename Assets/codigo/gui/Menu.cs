using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Menu : MonoBehaviour
{
    public void NovoJogo(){}
    public void CarregarJogo(){}
    public void Opcoes(){
        SceneManager.LoadScene("Menu Opcoes");
    }
    public void MenuPrincipal(){
        SceneManager.LoadScene("Menu principal");
    }
    public void Sair(){
        Application.Quit();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
  [SerializeField] private int indice;
  [SerializeField] private GameObject Painel_Menu;
  [SerializeField] private GameObject Painel_opcoes;
    public void Comecar()
    {
        SceneManager.LoadScene(indice);
    }

    public void Abrir_opcoes()
    {
        Painel_Menu.SetActive(false);
        Painel_opcoes.SetActive(true);
    }
    public void Fechar_opcoes()
    {
        Painel_Menu.SetActive(true);
        Painel_opcoes.SetActive(false);
    }
    public void Sair()
    {
        Debug.Log("Sair do Jogo");
        Application.Quit();
    }
}
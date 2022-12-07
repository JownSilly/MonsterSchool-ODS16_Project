using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuManager : MonoBehaviour
{
  [SerializeField] private int indice;
  [SerializeField] private GameObject Painel_Menu;
  [SerializeField] private GameObject Painel_opcoes;
  [SerializeField] private LevelChanger levelChanger;

    public void Comecar()
    {
        levelChanger.FadeToLevel(1);
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
        Application.Quit();
    }
}

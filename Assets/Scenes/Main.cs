using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Main : MonoBehaviour
{

    public void iniciar()
    {
        //Application.LoadLevel("SampleScene");
        SceneManager.LoadScene("Escenario 1");
    }

    public void pasarNivel2()
    {
        //Application.LoadLevel("SampleScene");
        SceneManager.LoadScene("Escenario 2");
    }

    public void salir()
    {
        Application.Quit();
    }

}

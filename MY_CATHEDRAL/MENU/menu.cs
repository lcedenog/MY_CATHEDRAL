using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    public void GoToMainMenu()
    {
        SceneManager.LoadScene("main_menu");
    }

    public void GoToBienvenidos()
    {
        SceneManager.LoadScene("Bienvenidos");
    }

   

    public void GoToARCamera()
    {
        SceneManager.LoadScene("altares");
    }

    public void GoToMaria()
    {
        SceneManager.LoadScene("maria");
    }

    public void GoToJesus()
    {
        SceneManager.LoadScene("jesus");
    }

    public void GoToNarcisa()
    {
        SceneManager.LoadScene("narcisa");
    }

    public void GoToDonBosco()
    {
       SceneManager.LoadScene("donbosco");
    }

    public void ExitApplication()
    {
        Application.Quit();
    }

}

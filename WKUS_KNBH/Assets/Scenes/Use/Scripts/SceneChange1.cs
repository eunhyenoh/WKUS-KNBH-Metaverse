using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange1 : MonoBehaviour
{
  public void Prime()
    {
        SceneManager.LoadScene("IntroScene");
    }
    public void Flower()
    {
        SceneManager.LoadScene("FlowerCreate");
    }

    public void ChoiceScene()
    {
        SceneManager.LoadScene("ChoiceScene");
    }
}

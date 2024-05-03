using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameScript : MonoBehaviour
{
    public void StartGame()
    {
        int firstLevel = 1;
        SceneManager.LoadScene(firstLevel);
    }
}

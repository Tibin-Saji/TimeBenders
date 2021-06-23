using UnityEngine.SceneManagement;
using UnityEngine;

public class BackButtons : MonoBehaviour
{
    public void GoBack()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}

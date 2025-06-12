using UnityEngine;
using UnityEngine.SceneManagement;

public class StartHome : MonoBehaviour
{
    public void LoadLevel(int index)
    {
        SceneManager.LoadScene(index);
    }

}

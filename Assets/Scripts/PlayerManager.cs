using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerManager : MonoBehaviour
{
    public static bool isGameOver;
    public GameObject gameOverScreen;

    public static Vector2 lastCheckPointPos = new Vector2(-6, 1);

    public static int noOfCherry = 0;

    public TextMeshProUGUI diamondText;

    private void Start()
    {
        Application.targetFrameRate = 60;
    }
    private void Awake()
    {
      
        isGameOver = false;
        GameObject.FindGameObjectWithTag("Player").transform.position = lastCheckPointPos;
    }

    // Update is called once per frame
    void Update()
    {
        diamondText.text = noOfCherry.ToString();
        if (isGameOver)
        {
            gameOverScreen.SetActive(true);
        }
    }
    public void replayLevel()
    {
       
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    public int lives = 3;
    public int score = 0;

    [Header("End Anim")]
    public GameObject Light;
    public Animator Hatch;


    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject gameManager = new GameObject();
                instance = gameManager.AddComponent<GameManager>();
                gameManager.name = "Game Manager Singleton";
            }
            return instance;
        }
    }


    private void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        Debug.Log("arribadelobeserver");
        TicketReset.OnInteract += HandleTicket;
    }


    void HandleTicket(bool isTicketCorrect, bool isApprovedStamp, bool hasBeenChecked)
    {
        Debug.Log(isTicketCorrect + " " + isApprovedStamp + " " + hasBeenChecked);
        if(!hasBeenChecked)
        {
            return;
        }
        if (isTicketCorrect && isApprovedStamp)
        {
            Debug.Log("GOOD :)");
            GoodCheck();

        } else if (!isTicketCorrect && !isApprovedStamp)
        {
            Debug.Log("GOOD 2 :)");
            GoodCheck();
        } else {
            Debug.Log("BAD :(");
            BadCheck();

        }
    }

    public void GoodCheck()
    {
        score++;
    }

    public void BadCheck()
    {
        lives--;
        if (lives <= 0)
        {
            //SceneManager.LoadScene("BLACK");
            EndAnimSequence.gameOverSeq = true;
        }
    }

}

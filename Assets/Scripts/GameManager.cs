using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    public int lives = 3;
    public int score = 0;


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


        raycastStamp.OnInteract += HandleTicket;
    }


    void HandleTicket(bool isTicketCorrect, bool isApprovedStamp, bool hasBeenChecked)
    {
        if(hasBeenChecked)
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
        if (lives == 0)
        {
            Debug.Log("Game Over");
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

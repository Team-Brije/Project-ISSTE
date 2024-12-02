using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueToggle : MonoBehaviour
{
    int daynum;
    public TextMeshPro text;
    // Start is called before the first frame update
    void Start()
    {
        daynum = TimeManager.Day;

        SetDayDialogue();
    }
    
    void SetDayDialogue()
    {
        switch (daynum)
        {
            case 0:
                text.text = "Hello! Welcome to your first day on your job as the guard for the best Intergalactic Resort ever! I.S.S.S.T.E. Your job here is to check everyone’s tickets to see if they are correct or not, and allow or deny entrance accordingly. \r\nIn front of you there are two stamps. The green one accepts the ticket, and the red one denies it. Be careful, your first stamp on the ticket is the only one that matters! No takebacks!";
                break;
            case 1:
                text.text = "Wow, you… actually managed to survive your first day here.Honestly I was fully expecting to have to replace you 30 minutes in your first shift. Anyhow, since you seem to have good enough knowledge of the job, you’ll also be checking for reservations today. Make sure that not only the dates are correct, but there’s also availability in the hotels. Well, you know the rest, goodbye and good luck!";
                break;
            case 2:
                text.text = "Absolutely impressive, employee number 144857423! Three days in a row, that is a whole new record! You know, you MIGHT just be the first person ever here to get their paycheck! Well, anyhow, you’ll also be checking IDs from now on, for now you just have to check if they haven’t expired yet, but if you make it through tomorrow, you might get a surprise!";
                break;
            case 3:
                text.text = "Congratulations, employee who’s number I already forgot, I did promise you a surprise! The surprise is more work, hooray for you! You have a blacklist now, make sure any people noted on it do not pass, unless you wanna make the higher ups very angry…";
                break;
            default: break;
        }
    }

}

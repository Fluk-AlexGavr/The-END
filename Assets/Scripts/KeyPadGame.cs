using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPadGame : MonoBehaviour
{
    [SerializeField] private List<GameObject> rightAnswer;
    [SerializeField] public List<GameObject> currentAnswer;
    [SerializeField] public int keysLeft;
    [SerializeField] AudioSource audio;
    [SerializeField] AudioSource win;
    [SerializeField] AudioSource loose;
    [SerializeField] GameObject Player;
    [SerializeField] MouseChooseTerminal terminal;
    public bool isWin = false;
    private int buffer;
    public TerminalProvider terminalProvider;
    public void TurnMovement()
    {
        Player.GetComponent<FirstPersonMovement>().enabled = true;
        Player.GetComponent<PlayerFootstepSounds>().enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        terminal.isOpen = false;
    }
    public void clicked(GameObject obj)
    {
        if (keysLeft != 0)
        {
            keysLeft--;
            audio.Play();
            currentAnswer.Add(obj);
        }
    }
    private bool compareLists()
    {
        for(int i = 0; i < rightAnswer.Count; i++)
        {
            if (rightAnswer[i] != currentAnswer[i])
            {
                return false;
            }
        }
        return true;
    }
    private void Start()
    {
        buffer = keysLeft;
    }
    private void Update()
    {
        if (keysLeft== 0) { 
            if (compareLists())
            {
                gameObject.GetComponent<Animator>().SetTrigger("True");
                win.Play();
                isWin = true;
                terminalProvider.isWin = true;
}
            else
            {
                gameObject.GetComponent<Animator>().SetTrigger("Wrong");
                loose.Play();
            }
            keysLeft = buffer;
        }
        if (gameObject.GetComponent<Animator>().GetBool("Exit")){
            keysLeft = buffer;
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlumberManager : MonoBehaviour
{
    [SerializeField] public bool isWin=false;
    [SerializeField] Animator animator;
    [SerializeField] public GameObject Player;
    [SerializeField] public MouseChooseTerminal terminal;
    public TerminalProvider terminalProvider;
    private void Update()
    {
        if (isWin)
        {
            animator.SetTrigger("True");
            terminalProvider.isWin=true;
            isWin = false;

        }
    }
    public void TurnMovement()
    {
        Player.GetComponent<FirstPersonMovement>().enabled = true;
        Player.GetComponent<PlayerFootstepSounds>().enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        terminal.isOpen = false;
    }
}

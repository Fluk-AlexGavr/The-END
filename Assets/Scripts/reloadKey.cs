using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reloadKey : MonoBehaviour
{
    [SerializeField] KeyPadGame game;
    public void clearList()
    {
        game.currentAnswer.Clear();
    }
}

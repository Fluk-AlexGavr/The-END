using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigDoorsCrush : MonoBehaviour
{
    [SerializeField] TerminalProvider terminalProvider;
    [SerializeField] ParticleSystem particleSystem;
    bool crushed;
    [SerializeField] float effectDelay;
    bool flag;

    private void Update()
    {
        if(!crushed)
        {
            crushed = terminalProvider.isWin;
        }
        else if(!flag)
        {
            gameObject.GetComponent<Collider>().enabled = false;
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            Invoke("Particle", effectDelay);
            flag = true;
        }
    }
    private void Particle()
    {
        particleSystem.Play();
    }
}

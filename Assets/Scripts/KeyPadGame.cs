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
    private int buffer;
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
            }
            else
            {
                gameObject.GetComponent<Animator>().SetTrigger("Wrong");
                loose.Play();
            }
            keysLeft = buffer;
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseChooseBrokeItem : MonoBehaviour
{
    Transform Player;
    [SerializeField] float distanceGrab; 
    [SerializeField] Color ImageColorActive;
    [SerializeField] Color ImageColorNotActive;
    Image image;

    [SerializeField] ParticleSystem brokeEffect;
    [SerializeField] float effectDelay;
    [SerializeField] float destroyDelay;

    List<GameObject> distuctiveObjs = new List<GameObject>();
    int countConnects;
    [SerializeField] bool brokeNow;
    GameObject StickWallController;


    private void Start()
    {
        Player = GameObject.FindWithTag("Player").transform;
        StickWallController = GameObject.FindWithTag("StickWallController");
        image = StickWallController.GetComponent<StickWallControllerScript>().Cursor;
        image.color = ImageColorNotActive;
        

        countConnects = StickWallController.GetComponent<StickWallControllerScript>().connestions;
        distuctiveObjs = StickWallController.GetComponent<StickWallControllerScript>().distructiveObjects;
        
    }

    private void Update()
    {
        if(countConnects <=0 && !brokeNow)
        {
            Broke();
        }
    }
    private void OnMouseOver()
    {
        if ((Player.position - transform.position).magnitude < distanceGrab)
        {
            image.color = ImageColorActive;
        }
        else
        {
            image.color = ImageColorNotActive;
        }
    }
    private void OnMouseExit()
    {
        image.color = ImageColorNotActive;
    }

    private void OnMouseDown()
    {
        if ((Player.position - transform.position).magnitude < distanceGrab)
        {
            image.color = ImageColorNotActive;
            Broke();
        }
    }

    private void Broke()
    {
        foreach (GameObject distuctiveObj in distuctiveObjs)
        {
            if (distuctiveObj.activeInHierarchy)
            {
                gameObject.GetComponent<Rigidbody>().isKinematic = false;
                Invoke("GetParticlies", effectDelay);
                Invoke("Destroyy", destroyDelay);
                brokeNow = true;
            }
        }
    }

    private void GetParticlies()
    {
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        gameObject.GetComponent<Rigidbody>().isKinematic = true;
        gameObject.GetComponent<Collider>().enabled = false;
        brokeEffect.Play();
    }

    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.tag != "Player")
        {
            countConnects--;
        }
    }

    private void Destroyy()
    {
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        image.color = ImageColorNotActive;
    }
}

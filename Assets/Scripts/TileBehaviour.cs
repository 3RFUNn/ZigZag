using System.Collections;
using UnityEngine;

public class TileBehaviour : MonoBehaviour
{
    private float delay = 0.7f;
   
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() 
    {
        
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            TileManager.Instance.TileSpawner();
            StartCoroutine(TileFall());
        }
    }

    IEnumerator TileFall()
    {
        yield return new WaitForSeconds(delay);
        GetComponent<Rigidbody>().isKinematic = false;
        yield return new WaitForSeconds(2);
        switch (gameObject.tag)
        {
            case "Left" :
                TileManager.Instance.Lefttile.Push(gameObject);
                gameObject.GetComponent<Rigidbody>().isKinematic = true;
                gameObject.SetActive(false);
                gameObject.transform.GetChild(1).gameObject.SetActive(false);
                break;
            case "Right":
                TileManager.Instance.Righttile.Push(gameObject);
                gameObject.GetComponent<Rigidbody>().isKinematic = true;
                gameObject.SetActive(false);
                gameObject.transform.GetChild(1).gameObject.SetActive(false);
                break;
        }
    }
}

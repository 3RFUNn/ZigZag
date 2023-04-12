using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TileManager : MonoBehaviour
{
    [SerializeField] private GameObject currentTile;
    [SerializeField] private GameObject[] tiles;
    private static TileManager _instance;
    private Stack<GameObject> lefttile = new Stack<GameObject>();
    private Stack<GameObject> righttile = new Stack<GameObject>();

    public Stack<GameObject> Lefttile
    {
        get => lefttile;
        set => lefttile = value;
    }

    public Stack<GameObject> Righttile
    {
        get => righttile;
        set => righttile = value;
    }

    public static TileManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<TileManager>();
            }

            return _instance;
        }
    }

    void Start()
    {
        TileCreate(30);
        for (int i = 0; i < 30; i++)
        {
            TileSpawner();
        }
    }


    void Update()
    {
    }

    public void TileCreate(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            lefttile.Push(Instantiate(tiles[0]));
            righttile.Push(Instantiate(tiles[1]));
            lefttile.Peek().SetActive(false);
            righttile.Peek().SetActive(false);
        }
    }

    public void TileSpawner()
    {
        if (righttile.Count == 0 || lefttile.Count == 0)
        {
            TileCreate(20);
        }

        int randnum = Random.Range(0, 2);
        int randgem = Random.Range(0, 10);
        if (randnum == 0)
        {
            GameObject temp = lefttile.Pop();
            temp.SetActive(true);
            temp.transform.position = currentTile.transform.GetChild(0).transform.GetChild(randnum).position;
            currentTile = temp;
        }
        else
        {
            GameObject temp = righttile.Pop();
            temp.SetActive(true);
            temp.transform.position = currentTile.transform.GetChild(0).transform.GetChild(randnum).position;
            currentTile = temp;
        }

        if (randgem == 0)
        {
            currentTile.transform.GetChild(1).gameObject.SetActive(true);
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
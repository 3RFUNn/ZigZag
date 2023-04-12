

using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;


public class PlayeBehaviour : MonoBehaviour
{
    [SerializeField] private float speed;
    private Vector3 _dir;
    private Rigidbody _rigidbody;
    [SerializeField] private GameObject ps;
    private bool game;
    [SerializeField] private GameObject restart;
    [SerializeField] private Text score;
    private int _score = 0;
    void Start()
    {
        _dir = Vector3.zero;
        game = true;
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space)) && game)
        {
            _score++;
            score.text = _score.ToString();
            if (_dir == Vector3.forward)
            {
                _dir = Vector3.left;
            }
            else
            {
                _dir = Vector3.forward;
            }
        }


        var movementSpeed = speed * Time.deltaTime;
        transform.Translate(_dir * movementSpeed);
       
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Gem"))
        {
            _score += 2;
            score.text = _score.ToString();
            collider.gameObject.SetActive(false);
            Instantiate(ps, transform.position, Quaternion.Euler(-90, 0, 0));

        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.CompareTag("Left") || collider.CompareTag("Right") || collider.CompareTag("Start"))
        {
            RaycastHit raycastHit;
            Ray ray = new Ray(transform.position, -Vector3.up);
            
            if (!Physics.Raycast(ray, out raycastHit) )
            {
                transform.GetChild(0).transform.parent = null;
                game = false;
                restart.SetActive(true);
            }
        }
    }
}
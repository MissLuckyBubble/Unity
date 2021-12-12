using UnityEngine;
using UnityEngine.SceneManagement;

public class Bird : MonoBehaviour
{
    //private variable accessed only in this class
    private Vector3 _initialPosition;
    private bool _birtWasLaunched;
    private float _timeSittingAround;

    [SerializeField] private float _launchPower = 500;


    private void Awake()
    {
        _initialPosition = transform.position;
    }

    private void Update()
    {
        //Lines for direction
        GetComponent<LineRenderer>().SetPosition(0, transform.position);
        GetComponent<LineRenderer>().SetPosition(1, _initialPosition);

        //Timer after launch
        if (_birtWasLaunched && 
            GetComponent<Rigidbody2D>().velocity.magnitude <= 0.1)
        {
            _timeSittingAround += Time.deltaTime;
        }

        //check Edges
        if (transform.position.y > 20 || 
            transform.position.y < -20||
            transform.position.x > 20 ||
            transform.position.x <-20 ||
            _timeSittingAround > 3)
        {
            string currentSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentSceneName);
        }

    }

    private void OnMouseDown()
    {
        GetComponent<SpriteRenderer>().color = Color.red;

        //Lines for direction - show
        GetComponent<LineRenderer>().enabled = true;
    }

    private void OnMouseUp()
    {
        GetComponent<SpriteRenderer>().color = Color.white;

        Vector2 directionToInitialPosition = _initialPosition - transform.position;

        GetComponent<Rigidbody2D>().AddForce(directionToInitialPosition * _launchPower);
        GetComponent<Rigidbody2D>().gravityScale = 1;
        _birtWasLaunched = true;

        //Lines for direction - hide when relase
        GetComponent<LineRenderer>().enabled = false;
    }

    private void OnMouseDrag()
    {
        Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(newPosition.x, newPosition.y);
    }
}

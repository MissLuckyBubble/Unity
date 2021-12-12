using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject _cloudParticlePrefab;

    //When Touch something
    private void OnCollisionEnter2D(Collision2D collision)
    {
        bool didHitBird = collision.collider.GetComponent<Bird>() != null;

        if (didHitBird)
        {
            //spawn particle sistem at transform.position (position of the object)
            //before desroy the object
            Instantiate(_cloudParticlePrefab,transform.position, Quaternion.identity);
            Destroy(gameObject);
            return;
        }

        bool didHitEnemy  = collision.collider.GetComponent<Enemy>() != null;
        if (didHitEnemy)
        {
            return;
        }

        //when is hit from the top
        if(collision.contacts[0].normal.y < -0.5)
        {
            Instantiate(_cloudParticlePrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
            return;
        }
    }
}

using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    public float speed = 20f;
    public Transform focalPoint;
    public bool hasPowerUp;
    private float powerUpStrength = 40f;
    public GameObject powerupIndicator;
    public GameObject projectilePrefab;



    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
       

    }




    // Update is called once per frame
    void Update()
    {

        powerupIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);

        float verticalInput = Input.GetAxis("Vertical");

        float horizontalInput = Input.GetAxis("Horizontal");

        Vector2 moveDirection = new Vector2(horizontalInput, verticalInput).normalized;

        playerRb.AddForce(((focalPoint.forward * moveDirection.y) + (focalPoint.right * moveDirection.x)) * speed);

        focalPoint.position = transform.position;

        if (transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUP"))
        {
            hasPowerUp = true;

            powerupIndicator.gameObject.SetActive(true);

            Destroy(other.gameObject);

            StartCoroutine(PowerupCountdownRoutine());
        }
    }
    private IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(7);

        hasPowerUp = false;

        powerupIndicator.gameObject.SetActive(false);

    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy")&& hasPowerUp)
        {
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position);

            Debug.Log("Player collided with" + collision.gameObject.name + "with powerup set to"+ hasPowerUp);
                enemyRigidbody.AddForce(awayFromPlayer * powerUpStrength, ForceMode.Impulse);
        }
    }
}

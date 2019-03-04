using UnityEngine;
using System.Collections;

public class EnemyMovement:MonoBehaviour,IHitTaker {
    public float knockBackForce = 50f;
    public float staggerTime = 0f;
    Transform player;
    PlayerHealth playerHealth;
    EnemyHealth enemyHealth;
    UnityEngine.AI.NavMeshAgent nav;
    private bool knockBack = false;
    private float knockBackCounter = 0f;
    private float knockBackTime = 1f;
    private Vector3 direction;
    private Rigidbody rb;
    private float staggerTimeout = 0f;

    void Awake() {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerHealth = player.GetComponent<PlayerHealth>();
        enemyHealth = GetComponent<EnemyHealth>();
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
        rb = GetComponent<Rigidbody>();
    }

    void Update() {
        if (enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0) {
            if (staggerTimeout > 0) {
                //rb.AddForce(Vector3.forward, ForceMode.Impulse);
                //Vector3 targetPosition = (transform.position - direction).normalized * knockBackForce;
                //Debug.Log("Current Position: " + transform.position + "  Target Position: " + targetPosition + "  Direction: " + direction);
                //Vector3 lerp = Vector3.Lerp(transform.position, targetPosition, 5f * Time.deltaTime);
                //rb.MovePosition(targetPosition);
                //transform.position = targetPosition;
                //rb.AddForce(targetPosition);
                //knockBack = false;
                //nav.SetDestination(direction);
                //rb.AddForce(new Vector3(5000f, 0f, 5000f), ForceMode.Impulse);

                staggerTimeout -= Time.deltaTime;
            } else {
                nav.enabled = true;
                nav.SetDestination(player.position);
            }
        } else {
            nav.enabled = false;
        }
    }

    public void TakeHit(int damage, Vector3 hitPoint, Vector3 velocity, float mass) {
        Debug.Log("WE MOVED!");
        nav.enabled = false;
        staggerTimeout = staggerTime;
        rb.AddForce(velocity * mass, ForceMode.Impulse);
    }

    public void KnockBack(Vector3 dir) {
        nav.enabled = false;
        staggerTime = 2f;
        rb.AddForce(new Vector3(15f, 0f, 15f), ForceMode.Impulse);
        //knockBackCounter = knockBackTime;
        //direction = new Vector3(1f, 0f, 1f) * knockBackForce;
        //direction = dir.normalized;
        //knockBack = true;
    }
    
    /*private void FixedUpdate() {
        if (knockBack)
        {
            nav.velocity = direction * 8;
        }
    }

    IEnumerator KnockBack() {
        float origSpeed = nav.speed;
        float origAngularSpeed = nav.angularSpeed;
        float origAcc = nav.acceleration;

        knockBack = true;
        nav.speed = 10;
        nav.angularSpeed = 0;
        nav.acceleration = 20;

        yield return new WaitForSeconds(0.2f);

        knockBack = false;
        nav.speed = origSpeed;
        nav.angularSpeed = origAngularSpeed;
        nav.acceleration = origAcc;
    }

    private void OnTriggerEnter(Collider other) {
        if(other.name.Equals(""))
        direction = other.transform.forward;
        StartCoroutine(KnockBack());
    }*/
}

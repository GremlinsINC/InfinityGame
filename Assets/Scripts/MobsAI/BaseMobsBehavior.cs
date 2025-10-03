using UnityEngine;

public class BaseMobsBehavior : MonoBehaviour
{

  [Header("Movement Settings")]
  public float speed = 2f;
  public float waitTime = 2f;
  public Transform[] patrolPoints;

  private int currentPatrolIndex = 0;
  private float waitCounter = 0;
  private bool isWaiting = false;

  private Rigidbody2D rb;
  private SpriteRenderer spriteRenderer;


  void Start()
  {
    rb = GetComponent<Rigidbody2D>();
    spriteRenderer = GetComponent<SpriteRenderer>();

    if (patrolPoints.Length > 0) {
      transform.position = patrolPoints[0].position;
    }
  }

  void Update()
  {
    if(isWaiting) {

      Wait(); 
      currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Length;

      return; 
    }

    MoveToPoint(patrolPoints[currentPatrolIndex]);
    FlipSprite(rb.linearVelocity);
  }

  void MoveToPoint(Transform targetPoint){

    Vector2 direction = (targetPoint.position - transform.position).normalized;
    Vector2 velocity = direction * speed;

    rb.linearVelocity = velocity;
  }

  void FlipSprite(Vector2 velocity){

    if (velocity.x > 0.01f){
      spriteRenderer.flipX = false;
    } else if (velocity.x < 0.01f){
      spriteRenderer.flipX = true;
    }
  }

  void Wait(){
    waitCounter -= Time.deltaTime;
    if(waitCounter <= 0){
      isWaiting = false;
    }
  }
  
}

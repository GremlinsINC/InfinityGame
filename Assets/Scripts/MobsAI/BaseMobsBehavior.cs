using UnityEngine;

public class BaseMobsBehavior : MonoBehaviour
{

  [Header("Movement Settings")]
  [SerializeField] protected float speed = 2f;
  [SerializeField] protected float waitTime = 2f;
  [SerializeField] protected Transform[] patrolPoints;

  protected int currentPatrolIndex = 0;
  protected float waitCounter = 0;
  protected bool isWaiting = false;

  protected Rigidbody2D rb;
  protected SpriteRenderer spriteRenderer;


  protected void Start()
  {
    rb = GetComponent<Rigidbody2D>();
    spriteRenderer = GetComponent<SpriteRenderer>();

    if (patrolPoints.Length > 0) {
      transform.position = patrolPoints[0].position;
    }
  }

  protected virtual void Update()
  {
    if(isWaiting) {

      Wait(); 
      currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Length;

      return; 
    }

    MoveToPoint(patrolPoints[currentPatrolIndex]);
    FlipSprite(rb.linearVelocity);
  }

  protected void MoveToPoint(Transform targetPoint){

    Vector2 direction = (targetPoint.position - transform.position).normalized;
    Vector2 velocity = direction * speed;

    rb.linearVelocity = velocity;
  }

  protected void FlipSprite(Vector2 velocity){

    if (velocity.x > 0.01f){
      spriteRenderer.flipX = false;
    } else if (velocity.x < 0.01f){
      spriteRenderer.flipX = true;
    }
  }

  protected void Wait(){
    waitCounter -= Time.deltaTime;
    if(waitCounter <= 0){
      isWaiting = false;
    }
  }
  
}

using UnityEngine;

public class MultipleRayDetection: MonoBehaviour
{

  [Header("Ray Detection Settings")]
  [SerializeField] protected int rayCount = 5;
  [SerializeField] protected float fieldOfView = 90f;
  [SerializeField] protected float rayDistantion = 8f;
  [SerializeField] protected LayerMask detectionLayer;

  void CastFanRays(Vector2 eyeDirection){
    float angleStep = fieldOfView / ( rayCount - 1 );
    float startAngle = fieldOfView / 2;

    for (int i = 0; i < rayCount; i++){
      float angle = startAngle + (angleStep * i);
      Vector2 direction = Quaternion.Euler(0, 0, angle) * eyeDirection;

      RaycastHit2D hit = Physics2D.Raycast(
        transform.position,
        direction,
        rayDistantion,
        detectionLayer
      );

      if(hit.collider != null){
        ProcessDetectedObject(hit.collider.gameObject);
      }
    }
  }

  void ProcessDetectedObject(GameObject obj){
    Debug.Log("Обнаружен объект на координатах: " + obj.transform.position);
  }
}

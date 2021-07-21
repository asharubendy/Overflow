
using UnityEngine;

public class camFollow : MonoBehaviour
{
   public Transform target;

   public float speed = 0.125f;

    public Vector3 offset; 
    
   void LateUpdate() {
       Vector3 pos1 = target.position + offset;
       Vector3 smpos1 = Vector3.Lerp (transform.position, pos1, speed * Time.deltaTime);
       transform.position = smpos1; 
   }
}

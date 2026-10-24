using UnityEngine;

namespace _Script
{
    public class FollowPlayer : MonoBehaviour
    {
        public Transform player;
        public float speed = 15f;
        public float disLimit = 0.5f;
        
        void Update()
        {
            this.Follow();
        }

        private void Follow()
        {
            Vector3 distance = player.position - transform.position;
            if (distance.magnitude >= disLimit)
            {
             
                Vector3 targetPoint = player.position - distance.normalized * disLimit;
            
                gameObject.transform.position
                    = Vector3.MoveTowards(
                    gameObject.transform.position, 
                    targetPoint, 
                    speed * Time.deltaTime);
            }
        }
    }
    
}

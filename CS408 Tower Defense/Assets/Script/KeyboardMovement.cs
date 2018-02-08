using UnityEngine;

public class KeyboardMovement : MonoBehaviour
{
    public float mSpeed = 10;
    void Update()
    {

        var x = Input.GetAxis("Horizontal") * Time.deltaTime * mSpeed;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * mSpeed;
        
        Vector3 position = this.transform.position;
        position.x += x;
        position.z += z;
        this.transform.position = position;
    }


    float force = 3;

    void OnCollisionEnter(Collision c)
    {
        //var hit = collision.gameObject;
        // var health = hit.GetComponent<playerStatus>();
        //if (health != null) health.TakeDamage(10);

        if (c.gameObject.tag == "Enemy")
        {
            // Calculate Angle Between the collision point and the player
            Vector3 dir = c.contacts[0].point - transform.position;
            // We then get the opposite (-Vector3) and normalize it
            dir = -dir.normalized;
            // And finally we add force in the direction of dir and multiply it by force. 
            // This will push back the player
            GetComponent<Rigidbody>().AddForce(dir * force);
        }

        //Destroy(gameObject);

    }

}
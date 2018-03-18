using UnityEngine;

public class KeyboardMovement : MonoBehaviour
{
    public float mSpeed = 6;
    
    void Update()
    {
        bool doing = this.GetComponent<CreateTower>().doing;
        if (!doing) {
            
            if (Mathf.Abs(Input.GetAxis("Horizontal")) > 0 || Mathf.Abs(Input.GetAxis("Vertical")) > 0)
            {
                if (!this.GetComponentInChildren<Animation>().IsPlaying("Lumbering"))
                {
                    this.GetComponentInChildren<Animation>().Play("Walk");
                    var x = Input.GetAxis("Horizontal") * Time.deltaTime * mSpeed;
                    var z = Input.GetAxis("Vertical") * Time.deltaTime * mSpeed;

                    Vector3 position = this.transform.position;
                    position.x += x;
                    position.z += z;
                    this.transform.position = position;
                }
            } else {
                if (!this.GetComponentInChildren<Animation>().IsPlaying("Lumbering"))
                {
                    this.GetComponentInChildren<Animation>().Play("Idle");

                }
            }

           
        }
    }

}
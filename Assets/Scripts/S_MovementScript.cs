using UnityEngine;

public class S_MovementScript : MonoBehaviour
{
    public CharacterController cc;
    public Transform cam;
    public float speed = 6f;
    float SmoothTurnVelocity;
    public float SmoothTurnTime = 0.1f;
    public bool Dialogue = false;

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude>=0.1f){
            float targetAngle = Mathf.Atan2(direction.x, direction.z)*Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref SmoothTurnVelocity, SmoothTurnTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 MoveDir = Quaternion.Euler(0f, targetAngle, 0f)* Vector3.forward;
            cc.Move(MoveDir*speed*Time.deltaTime);
        }

        if(Dialogue&&Input.GetKeyDown("F")){
            //Do Dialogue Stuff here
        }
    }
}

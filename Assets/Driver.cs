using UnityEngine;

public class Driver : MonoBehaviour{
    [SerializeField] private float steerSpeed = 300f;
    [SerializeField] private float moveSpeed = 20f;
    [SerializeField] private float slowSpeed = 15f;
    [SerializeField] private float boostSpeed = 30f;

    private void Update(){
        var steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        var moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, moveAmount, 0);
    }

    private void OnCollisionEnter2D(Collision2D other){
        moveSpeed = slowSpeed;
    }

    private void OnTriggerEnter2D(Collider2D other){
        if (other.CompareTag("Boost")){
            moveSpeed = boostSpeed;
        }
    }
}
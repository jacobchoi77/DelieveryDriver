using UnityEngine;

public class Delivery : MonoBehaviour{
    [SerializeField] private Color32 hasPackageColor = new(1, 1, 1, 1);
    [SerializeField] private Color32 noPackageColor = new(1, 1, 1, 1);

    [SerializeField] private float destroyDelay = 0.5f;
    private bool hasPackage;

    private SpriteRenderer spriteRenderer;

    private void Start(){
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D other){
        Debug.Log("Ouch!");
    }

    private void OnTriggerEnter2D(Collider2D other){
        if (other.CompareTag("Package") && !hasPackage){
            Debug.Log("Package picked up");
            hasPackage = true;
            spriteRenderer.color = hasPackageColor;
            Destroy(other.gameObject, destroyDelay);
        }
        else if (other.CompareTag("Customer") && hasPackage){
            Debug.Log("Package Delivered");
            hasPackage = false;
            spriteRenderer.color = noPackageColor;
        }
    }
}
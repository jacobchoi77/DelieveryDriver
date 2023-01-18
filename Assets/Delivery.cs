using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour{
    [SerializeField] private Color32 hasPackageColor = new Color32(1, 1, 1, 1);
    [SerializeField] private Color32 noPackageColor = new Color32(1, 1, 1, 1);

    [SerializeField] private float destroyDelay = 0.5f;
    private bool _hasPackage;

    private SpriteRenderer _spriteRenderer;

    private void Start(){
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D other){
        Debug.Log("Ouch!");
    }

    private void OnTriggerEnter2D(Collider2D other){
        if (other.CompareTag("Package") && !_hasPackage){
            Debug.Log("Package picked up");
            _hasPackage = true;
            _spriteRenderer.color = hasPackageColor;
            Destroy(other.gameObject, destroyDelay);
        }

        if (other.CompareTag("Customer") && _hasPackage){
            Debug.Log("Package Delivered");
            _hasPackage = false;
            _spriteRenderer.color = noPackageColor;
        }
    }
}
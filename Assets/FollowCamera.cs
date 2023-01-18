using UnityEngine;

public class FollowCamera : MonoBehaviour{
    [SerializeField] private GameObject thingToFollow;
    // this things position (camera) should be the same as the car's position

    private void LateUpdate(){
        transform.position = thingToFollow.transform.position + new Vector3(0, 0, -10);
    }
}
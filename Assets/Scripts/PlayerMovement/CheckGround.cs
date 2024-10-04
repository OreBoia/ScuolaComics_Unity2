using UnityEngine;

public class CheckGround : MonoBehaviour
{
    private RaycastHit[] hits = new RaycastHit[1];
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private float maxDistance;

    public bool isGrounded;

    void Update()
    {
        var hit = 
            Physics.RaycastNonAlloc(transform.position, Vector3.down, hits, maxDistance, layerMask);  

        if(hit > 0)
            isGrounded = true;
        else
            isGrounded = false;
    }
}

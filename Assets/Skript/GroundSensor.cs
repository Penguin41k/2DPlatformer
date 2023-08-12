using UnityEngine;

public class GroundSensor : MonoBehaviour
{
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private Vector2 _boxSize;
    
    public bool IsGrounded { get; private set; }

    private void FixedUpdate()
    {
        Collider2D hitColliders = Physics2D.OverlapBox(transform.position, _boxSize, 0,  _layerMask);
        IsGrounded = hitColliders != null;
    }
}
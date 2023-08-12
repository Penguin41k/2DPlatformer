using UnityEngine;

public class GroundSensor : MonoBehaviour
{
    public bool IsGrounded { get; private set; }
        
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private Vector2 _boxSize;
    private float _angle=0;

    private void FixedUpdate()
    {
        Collider2D hitColliders = Physics2D.OverlapBox(transform.position, _boxSize, _angle,  _layerMask);
        IsGrounded = hitColliders != null;
    }
}
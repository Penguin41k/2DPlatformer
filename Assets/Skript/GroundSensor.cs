using UnityEngine;

public class GroundSensor : MonoBehaviour
{
    public bool IsGrounded { get; private set; }
    
    [SerializeField] private LayerMask _layerMask;
    [SerializeField]private Vector2 _boxSize;

    private void FixedUpdate()
    {
        Collider[] hitColliders = Physics.OverlapBox(gameObject.transform.position, _boxSize, Quaternion.identity, _layerMask);

        if (hitColliders.Length != 0 ) 
        {
            IsGrounded=true;
            Debug.Log("На земле");
        }
        else 
        { 
            IsGrounded=false;
            Debug.Log("В воздухе");
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, _boxSize);

    }
}
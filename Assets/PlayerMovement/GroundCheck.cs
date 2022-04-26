using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    // Start is called before the first frame update
    Transform _transform;
    BoxCollider2D _boxCollider;
    public float extraHeightTest;
    public LayerMask GroundLayers;
    private void Awake()
    {
        _transform = GetComponent<Transform>();
        _boxCollider = GetComponent<BoxCollider2D>();
    }

    public bool IsGrounded()
    {
        RaycastHit2D raycasthit = Physics2D.BoxCast(_boxCollider.bounds.center, _boxCollider.bounds.size, 0f, Vector2.down, extraHeightTest, GroundLayers);
        if (raycasthit.collider != null)
        {
            Debug.Log("we are grounded");
            return true;
        }
        else
        {
            Debug.Log("we are not grounded");
            return false;

        }
    }
}

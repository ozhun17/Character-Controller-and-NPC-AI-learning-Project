using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputGet : MonoBehaviour
{
    // Start is called before the first frame update
    public bool GetJumpInput()
    {
        return Input.GetButtonDown("Jump");
    }
    public float GetMoveInput()
    {
        return Input.GetAxisRaw("Horizontal");
    }
}

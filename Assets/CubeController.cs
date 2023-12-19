using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    private float rollSpeed = 9;
    private bool isMoving;

    private void Start()
    {
        print("Left: " + Vector3.left);
        print("Right: " + Vector3.right);
        print("Forward: " + Vector3.forward);
        print("Back: "+Vector3.back);
        print("Down: "+Vector3.down);
    }
    private void Update()
    {
        if (isMoving) return;

        if (Input.GetKey(KeyCode.A)) Assemble(Vector3.left);
        if (Input.GetKey(KeyCode.D)) Assemble(Vector3.right);
        if (Input.GetKey(KeyCode.W)) Assemble(Vector3.forward);
        if (Input.GetKey(KeyCode.S)) Assemble(Vector3.back);
    }

    void Assemble(Vector3 dir)
    {
        var anchor = transform.position + (Vector3.down + dir) * 0.5f;
        var axis = Vector3.Cross(Vector3.up, dir);

        StartCoroutine(Roll(anchor, axis));
    }


    IEnumerator Roll(Vector3 anchor,Vector3 axis)
    {
        isMoving = true;

        for (int i = 0; i < (90/rollSpeed); i++)
        {
            transform.RotateAround(anchor, axis, rollSpeed);
            yield return new WaitForSeconds(0.01f);
        }

        isMoving = false;
    }
}

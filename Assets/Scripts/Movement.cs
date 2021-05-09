using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private bool isMoving;
    private bool isRotating;
    private Vector3 originPos, targetPos;
    private float timetoMove = 0.2f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W) && !isMoving)
            StartCoroutine(MovePlayer(Vector3.up));

        if (Input.GetKey(KeyCode.A) && !isMoving)
            StartCoroutine(MovePlayer(Vector3.left));

        if (Input.GetKey(KeyCode.S) && !isMoving)
            StartCoroutine(MovePlayer(Vector3.down));

        if (Input.GetKey(KeyCode.D) && !isMoving)
            StartCoroutine(MovePlayer(Vector3.right));
        
        if (Input.GetKey(KeyCode.Q) && !isMoving && !isRotating)
            StartCoroutine(RotatePlayer(0));

        if (Input.GetKey(KeyCode.E) && !isMoving && !isRotating)
            StartCoroutine(RotatePlayer(1));
    }

    private IEnumerator MovePlayer(Vector3 direction)
    {
        isMoving = true;
        float elapsedTime=0;
        originPos = transform.position;
        targetPos = originPos + direction*10;

        while(elapsedTime < timetoMove)
        {
            transform.position = Vector3.Lerp(originPos, targetPos, (elapsedTime / timetoMove));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPos;

        isMoving = false;
    }

    private IEnumerator RotatePlayer(int d)
    {
        isRotating = true;

        if (d == 0){
            transform.Rotate(0f, 0f, 90f);
        } else {
            transform.Rotate(0f, 0f, -90f);
        }

        yield return new WaitForSeconds(0.25f);

        isRotating = false;
    }
}

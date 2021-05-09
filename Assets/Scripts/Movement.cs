using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private bool isMoving;
    private bool isRotating;
    private Vector3 originPos, targetPos;
    private float timetoMove = 0f;
    private bool inPlay = true;

    
    void Update()
    {
        if (inPlay) {
            //Detecting Key Input
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
    }

    public void changeInPlay(bool change){
        inPlay = change;
    }

    //Coroutine to move the tile
    private IEnumerator MovePlayer(Vector3 direction)
    {
        isMoving = true;
        float elapsedTime=0;
        originPos = transform.position;
        targetPos = originPos + direction; //Change the num at the end to change how many pixels it is moving

        //Moving for the elapsed time
        while(elapsedTime < timetoMove)
        {
            transform.position = Vector3.Lerp(originPos, targetPos, (elapsedTime / timetoMove));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        //Moving the rest of the way to insure it reached destination
        transform.position = targetPos;

        isMoving = false;
    }

    //Coroutine to rotate the tile
    private IEnumerator RotatePlayer(int d)
    {
        isRotating = true;

        //Rotating
        if (d == 0){
            transform.Rotate(0f, 0f, 90f);
        } else {
            transform.Rotate(0f, 0f, -90f);
        }

        //Waiting to prevent uncontrollable speeds
        yield return new WaitForSeconds(0.25f);

        isRotating = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CubeMovement : MonoBehaviour
{
    [SerializeField] float moveTime = 0.5f;
    [SerializeField] float jumpPower = 1f;
    [SerializeField] float reloadLevelDelay = 1f;

    bool allowInput;

    public void Die()
    {
        Destroy(gameObject);
        //spawn particle
        //play sound

        ScenesLoader.Instance.RestartLevel(reloadLevelDelay);
    }

    

    // Start is called before the first frame update
    void Start()
    {
        allowInput = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!allowInput)
        {
            //Exit
            return;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Vector3 newPosition = transform.position + Vector3.forward; // new Vector (0, 0, 1)
            MoveTo(newPosition);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Vector3 newPosition = transform.position + Vector3.back;
            MoveTo(newPosition);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Vector3 newPosition = transform.position + Vector3.right;
            MoveTo(newPosition);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Vector3 newPosition = transform.position + Vector3.left;
            MoveTo(newPosition);
        }
    }

    void MoveTo(Vector3 newPosition)
    {

        //Debug.DrawRay(newPosition, Vector3.down, Color.green, 2f);
        if (Physics.Raycast(newPosition, Vector3.down, 1f))
        {
            allowInput = false;
            transform.DOJump(newPosition, jumpPower, 1, moveTime).OnComplete(ResetInput);
        }

    }

    void ResetInput()
    {
        allowInput = true;
    }
}

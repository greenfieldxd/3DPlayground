using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CubeMovement : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] float moveTime = 0.5f;
    [SerializeField] float jumpPower = 1f;
    [SerializeField] float reloadLevelDelay = 1f;

    [SerializeField] GameObject particleFXDeath;

    bool allowInput;

    public void Die()
    {
        Destroy(gameObject);
        Instantiate(particleFXDeath, transform.position, Quaternion.identity);
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
            MoveTo(newPosition, Vector3.forward);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Vector3 newPosition = transform.position + Vector3.back;
            MoveTo(newPosition, Vector3.back);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Vector3 newPosition = transform.position + Vector3.right;
            MoveTo(newPosition, Vector3.right);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Vector3 newPosition = transform.position + Vector3.left;
            MoveTo(newPosition, Vector3.left);
        }
    }

    void MoveTo(Vector3 newPosition, Vector3 direction)
    {

        Debug.DrawRay(newPosition, Vector3.down, Color.green, 2f);
        if (Physics.Raycast(newPosition, Vector3.down, 1f) && !Physics.Raycast(transform.position, direction, 1f))
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

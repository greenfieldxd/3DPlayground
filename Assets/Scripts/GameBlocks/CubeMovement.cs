using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CubeMovement : MonoBehaviour
{
    #region Singleton
    public static CubeMovement Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }

    }
    #endregion

    [Header("Settings")]
    [SerializeField] float moveTime = 0.5f;
    [SerializeField] float jumpPower = 1f;
    [SerializeField] float reloadLevelDelay = 1f;

    [Header("FX")]
    [SerializeField] GameObject particleFXDeath;

    [Header("Sounds")]
    [SerializeField] AudioClip deathSound;

    bool allowInput;

    public void Die()
    {
        Destroy(gameObject);
        Instantiate(particleFXDeath, transform.position, Quaternion.identity);
        AudioManager.Instance.PlaySound(deathSound);

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
            MoveForward();
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            MoveBack();
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            MoveRight();
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            MoveLeft();
        }
    }

    public void MoveLeft()
    {
        if (!allowInput)  { return; }

        Vector3 newPosition = transform.position + Vector3.left;
        MoveTo(newPosition, Vector3.left);
    }

    public void MoveRight()
    {
        if (!allowInput) { return; }

        Vector3 newPosition = transform.position + Vector3.right;
        MoveTo(newPosition, Vector3.right);
    }

    public void MoveBack()
    {
        if (!allowInput) { return; }

        Vector3 newPosition = transform.position + Vector3.back;
        MoveTo(newPosition, Vector3.back);
    }

    public void MoveForward()
    {
        if (!allowInput) { return; }

        Vector3 newPosition = transform.position + Vector3.forward; // new Vector (0, 0, 1)
        MoveTo(newPosition, Vector3.forward);
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

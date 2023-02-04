using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class CharacterMovement : MonoBehaviour
{
    CharacterController controller;
    public GameObject seed;
    public Transform player;

    public int speed = 100;

    [SerializeField] private Vector2 characterMovementArea;

    private Vector3 characterMovementAreaStart;

    private PlayerStateController _playerStateController;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        characterMovementAreaStart = transform.position;
        _playerStateController = GetComponent<PlayerStateController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(_playerStateController.playerState != PlayerStates.ArenaSurvival)
        {
            return;
        }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move =  transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);
        
        // clamp character movement to area
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, characterMovementAreaStart.x - characterMovementArea.x,
                characterMovementAreaStart.x + characterMovementArea.x),
            transform.position.y,
            Mathf.Clamp(transform.position.z, characterMovementAreaStart.z - characterMovementArea.y,
                characterMovementAreaStart.z + characterMovementArea.y));

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(characterMovementAreaStart ,
            new Vector3(characterMovementArea.x * 2, 1, characterMovementArea.y * 2));
    }
}

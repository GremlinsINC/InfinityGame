using UnityEngine;
using Unity.Cinemachine;

public class LeftRoomToSave : MonoBehaviour
{
    public CinemachineCamera LeftRoomCamera;
    public CinemachineCamera SaveRoomCamera;

    public void SwitchRooms()
    {
        LeftRoomCamera.Priority = -1;
        LeftRoomCamera.Priority = 1;
    }
}

using UnityEngine;

public class TouchControlManager : MonoBehaviour
{

    private void Awake()
    {
        gameObject.SetActive(DeviceType.Handheld == SystemInfo.deviceType);
    }
}

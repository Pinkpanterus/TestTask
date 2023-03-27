using UnityEngine;

public sealed class FPSTarget : MonoBehaviour
{
    public int _targetFPS = 60;
      
    void Awake()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = _targetFPS;
    }
      
    void Update()
    {
        if (Application.targetFrameRate != _targetFPS)
        {
            Application.targetFrameRate = _targetFPS;
        }
    }
}

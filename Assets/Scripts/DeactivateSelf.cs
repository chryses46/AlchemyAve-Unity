using UnityEngine;

public class DeactivateSelf : MonoBehaviour
{
    public void Deactivate()
    {
        this.gameObject.SetActive(false);
    }
}

using UnityEngine;
using UnityEngine.UI;

public class Tooltip : MonoBehaviour
{
    [SerializeField]
    Text text;

    private void Update()
    {
        transform.position = Input.mousePosition + new Vector3(20, -20, 0);
    }

    void FillDesc(string desc)
    {
        text.text = desc;
    }
}

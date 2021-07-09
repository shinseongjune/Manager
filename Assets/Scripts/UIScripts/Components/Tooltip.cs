using UnityEngine;
using UnityEngine.UI;

public class Tooltip : MonoBehaviour
{
    public Text text;

    private void Update()
    {
        transform.position = Input.mousePosition + new Vector3(20, -20, 0);
    }

    public void FillDesc(string desc)
    {
        text.text = desc;
    }
}

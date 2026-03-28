using UnityEngine;
using TMPro;

public class CanvasScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI healthText;
    public GameObject player;
    public int maxHeight = 0;
    
    void Start()
    {
    }

    public void Update()
    {
        if (player.transform.position.y > maxHeight)
            maxHeight = (int) player.transform.position.y;
        healthText.text = $"{maxHeight} m";
    }
}

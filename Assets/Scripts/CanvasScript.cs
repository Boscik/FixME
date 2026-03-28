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
        float player_height = player.transform.position.y - 1.5f;
        if (player_height > maxHeight)
            maxHeight = (int) player_height;
        healthText.text = $"{maxHeight} m";
    }
}

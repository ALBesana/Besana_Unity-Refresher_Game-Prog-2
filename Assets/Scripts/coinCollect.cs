using UnityEngine;
using TMPro;

public class coinCollect : MonoBehaviour
{
    private int coin = 0;


    public TextMeshProUGUI coinText;


    private void OnTriggerEnter(Collider other)
    {
        
        if(other.transform.tag == "Coin")
        {
            coin++;
            coinText.text = "Coin Collected: " + coin.ToString();
            Debug.Log(coin);
            Destroy(other.gameObject);
        }

    }
}

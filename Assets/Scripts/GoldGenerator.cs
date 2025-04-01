using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;

public class GoldGenerator : MonoBehaviour
{
    [SerializeField] private GoldGenerator goldGenerator;
    [SerializeField] private TextMeshProUGUI goldText;
    public int currentGold = 0;
    private int goldFromClick = 10;

    // audio:
    public AudioSource clickSound;

    //images:
    public GameObject Sunglasses;
    public GameObject Hat;
    public GameObject Lipstick;
    public GameObject Shoes;
    public GameObject Gloves;
    public GameObject Jewelry;
    public GameObject Skateboard;

    // buttons:
    public GameObject SunglassButton;
    public GameObject HatButton;
    public GameObject LipstickButton;
    public GameObject ShoesButton;
    public GameObject GlovesButton;
    public GameObject JewelryButton;
    public GameObject SkateboardButton;

    //TMP objects:
    public GameObject EndText;
    public GameObject TextBehindCookie;

    public void CookieClick()
    {
        currentGold += goldFromClick;
        goldText.text = currentGold.ToString();
        clickSound.Play();
    }

    public void MoreGoldPerClick(int cost)
    {
        if(currentGold >= cost)
        {
            goldFromClick += 10;
            currentGold -= cost;
            goldText.text = currentGold.ToString();
        }
    }

    private IEnumerator AutoClicker()
    {
        while(true)
        {
            yield return new WaitForSeconds(1f);
            currentGold += goldFromClick;
            goldText.text = currentGold.ToString();
        }
    }

    public void BuyAutoClicker(int cost)
    {
  
        if(currentGold >= cost)
        {
            currentGold -= cost;
            StartCoroutine(AutoClicker());
            goldText.text = currentGold.ToString();
        }
    }
    // Buying items:
    public void BuySunglasses(int cost)
    {
        if(currentGold >= cost)
        {
            currentGold -= cost;
            goldText.text = currentGold.ToString();
            Sunglasses.SetActive(true);
            Destroy(SunglassButton);
            HatButton.SetActive(true);
        }
    }

    public void BuyHat(int cost)
    {
        if(currentGold >= cost)
        {
            currentGold -= cost;
            goldText.text = currentGold.ToString();
            Hat.SetActive(true);
            Destroy(HatButton);
            LipstickButton.SetActive(true);

        }
    }

    public void BuyLipstick(int cost)
    {
        if(currentGold >= cost)
        {
            currentGold -= cost;
            goldText.text = currentGold.ToString();
            Lipstick.SetActive(true);
            Destroy(LipstickButton);
            ShoesButton.SetActive(true);
        }
    }

    public void BuyShoes(int cost)
    {
        if(currentGold >= cost)
        {
            currentGold -= cost;
            goldText.text = currentGold.ToString();
            Shoes.SetActive(true);
            Destroy(ShoesButton);
            GlovesButton.SetActive(true);
        }
    }
    public void BuyGloves(int cost)
    {
        if(currentGold >= cost)
        {
            currentGold -= cost;
            goldText.text = currentGold.ToString();
            Gloves.SetActive(true);
            Destroy(GlovesButton);
            JewelryButton.SetActive(true);
        }
    }
    public void BuyJewelry(int cost)
    {
        if(currentGold >= cost)
        {
            currentGold -= cost;
            goldText.text = currentGold.ToString();
            Jewelry.SetActive(true);
            Destroy(JewelryButton);
            SkateboardButton.SetActive(true);
        }
    }
    public void BuySkateboard(int cost)
    {
        if(currentGold >= cost)
        {
            currentGold -= cost;
            goldText.text = currentGold.ToString();
            Skateboard.SetActive(true);
            Destroy(SkateboardButton);
            EndText.SetActive(true);

            // Cookie start moving:
            GameObject CookieManager = GameObject.Find("CookieManager");
            if (CookieManager != null)
            {
                CookieMovement script = CookieManager.GetComponent<CookieMovement>();
                if (script != null)
                {
                    script.enabled = true;
                }
            }     

            // Play new music:
            GameObject AudioManager = GameObject.Find("AudioManager");
            if (AudioManager != null)
            {
                AudioSource audio = AudioManager.GetComponent<AudioSource>();
                if (audio != null)
                {
                    audio.enabled = true;
                }
            }
            // Change Music:
            GameObject MainCamera = GameObject.Find("Main Camera");
            if (MainCamera != null)
            {
                AudioSource audio = MainCamera.GetComponent<AudioSource>();
                if (audio != null)
                {
                    audio.enabled = false;
                }
            }

            // Delay text when gained Skateboard:
            StartCoroutine(EnableObjectAfterDelay(6f));
    
            IEnumerator EnableObjectAfterDelay(float delay)
            {
                yield return new WaitForSeconds(delay);
                TextBehindCookie.SetActive(true);
            }

            // Stars begin to rotate:
            GameObject RotatingStars = GameObject.Find("RotatingStars");
            if (RotatingStars != null)
            {
                RotationStar[] scripts = RotatingStars.GetComponentsInChildren<RotationStar>(true);

                foreach (RotationStar script in scripts)
                {
                    script.enabled = true;
                }
            }
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void EndGame()
    {
        Application.Quit();
        Debug.Log("Game Closed");
    }
}


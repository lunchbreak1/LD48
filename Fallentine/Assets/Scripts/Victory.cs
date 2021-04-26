using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class Victory : MonoBehaviour
{
    // Start is called before the first frame update
    Player player;

    public int hearts, goons;

    public Text heartsReport, goonReport;
    
    void Start()
    {
        //player = FindObjectOfType<Player>();
        heartsReport.text = HeartsReport(hearts);
        goonReport.text = GoonsReport(goons);
    }

    string HeartsReport(int hearts) // Show the ending based on hearts collected
    {
        if (hearts > 60)
        {
            return "Nurturing and growing their strong bond for thousands of years, Ray and Sven have achieved the impossible: a relationship so perfect that they have combined into a single godlike being. Now a flawless entity possessing infinite wisdom and power, they rule over the multiverse, sheparding countless worlds to their destinies. Is it possible for a love to go TOO deep???";
        }
        if (hearts > 50)
        {
            return "Ray and Sven were fated to be together from the very beginning. Their love burnt brighter than the center of the galaxy and more vast than the deepest reaches of the cosmos. Even now they dance amongst the infinite lights of our night sky.";
        }
        if (hearts > 40)
        {
            return "Ray and Sven have forged a bond that neither heaven nor hell could separate. They lived out their decades of deep, devoted partnership in a happy home full of laughter and love.";
        }
        if (hearts > 30)
        {
            return "Through each other, Ray and Sven found what they were each lacking. The more time and conversation they spent with each other, the deeper they fell in love. Their marriage was remembered as a happy event that touched all of their loved ones";
        }
        if (hearts > 20)
        {
            return "No matter what the future may hold, Ray and Sven decided that they would see it out together. They were more than just friends who met up for coffee, they were partners who had each other's backs no matter how deep the danger.";
        }
        if (hearts > 10)
        {
            return "Ray and Sven had always been fascinated by each other and began seeing each other for coffee on the weekends. It didn't take long before their cozy coffee spot and deep, meaningful conversations became something to look forward to every week";
        }

        return "Though their paths would take them in different directions, Ray and Sven decided to stay friends for life. This was enough for them, neither one wanting to complicate their friendship by taking things any deeper.";
    }

    string GoonsReport(int goons) //Show the goon report
    {
        if(goons > 50)
        {
            return "What a terrible night to be a goon...";
        }
        if (goons > 40)
        {
            return "The oppression of the goons continues. When will it end?";
        }
        if (goons > 30)
        {
            return "This week's headlines: Massive outbreaks of goons falling out of the sky delay traffic...";
        }
        if (goons > 20)
        {
            return "You made quite a few goons unhappy. Not saying they didn't deserve it";
        }
        if (goons > 0)
        {
            return "Goons: mildly irritated.";
        }

        return "No goons were harmed in this playthrough of Fallentine!";
    }
}

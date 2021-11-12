using UnityEngine;
using UnityEngine.Advertisements;

public class UnityAdsTools : MonoBehaviour, IAdsShower, IUnityAdsListener
{
    private const string _gameId = "4447435";
    private const string _bannerPlacementId = "Banner_Android";
    private const string _rewardPlacementId = "Rewarded_Android";

    private void Start()
    {
        Advertisement.Initialize(_gameId, true);
    }
    
    public void ShowBanner()
    {
        Advertisement.Show(_bannerPlacementId);
    }

    public void ShowRewardVideo()
    {
        Advertisement.Show(_rewardPlacementId);
    }

    public void OnUnityAdsReady(string placementId)
    {
       
    }

    public void OnUnityAdsDidError(string message)
    {
       
    }

    public void OnUnityAdsDidStart(string placementId)
    {
       
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        if (showResult == ShowResult.Skipped)
        {
            Debug.Log("Skipped");
        }
    }
}

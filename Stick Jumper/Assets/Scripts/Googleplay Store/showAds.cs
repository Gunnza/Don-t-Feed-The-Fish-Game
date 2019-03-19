using UnityEngine;
using UnityEngine.Advertisements;

/*
public class showAds : MonoBehaviour {
	
 
static float restartCount = 0;
	
public static void ShowAd()
  {
	restartCount += 1;
		
if (restartCount >= Random.Range(15,30))
	{
   	 if (Advertisement.IsReady())
   	 {
      Advertisement.Show();
   	 }
	restartCount = 0;
	}
}

 
/*		
public void ShowRewardedAd()
 {
   	 if (Advertisement.IsReady("rewardedVideoZone"))
    	 {
    	 	 var options = new ShowOptions { resultCallback = HandleShowResult };
     		 Advertisement.Show("rewardedVideoZone", options);
   		 }
	}
}

  private void HandleShowResult(ShowResult result)
  {
    switch (result)
    {
      case ShowResult.Finished:
        Debug.Log("The ad was successfully shown.");
        //
        // YOUR CODE TO REWARD THE GAMER
        // Give coins etc.
        break;
      case ShowResult.Skipped:
        Debug.Log("The ad was skipped before reaching the end.");
        break;
      case ShowResult.Failed:
        Debug.LogError("The ad failed to be shown.");
        break;
		
    }
    
    
}

*/





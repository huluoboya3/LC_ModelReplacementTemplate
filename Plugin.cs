using BepInEx;
using UnityEngine;
using System.Reflection;
using ModelReplacement;

//You need to change the name of the solution and the naming of the space.
namespace ModelReplacementTemplate
//namespace xxxModelReplacement
{

    [BepInPlugin("modguid", "modname", "1.0.0")]
    [BepInDependency("meow.ModelReplacementAPI", BepInDependency.DependencyFlags.HardDependency)]
    public class Plugin : BaseUnityPlugin
    {
        private void Awake()
        {
            Assets.PopulateAssets();

            //Register the specified name of the clothes to the specified class
            ModelReplacementAPI.RegisterSuitModelReplacement("Register Suit Name 1", typeof(BodyReplacement1));
            ModelReplacementAPI.RegisterSuitModelReplacement("Register Suit Name 2", typeof(BodyReplacement2));
        }
    }


    public class BodyReplacement1 : BodyReplacementBase
    {
        protected override GameObject LoadAssetsAndReturnModel()
        {
            return Assets.MainAssetBundle.LoadAsset<GameObject>("Model1");//The name you set in Unity
        }
    }

    public class BodyReplacement2 : BodyReplacementBase
    {
        protected override GameObject LoadAssetsAndReturnModel()
        {
            return Assets.MainAssetBundle.LoadAsset<GameObject>("Model2");
        }
    }

    /*
    //If you need to add more, just copy them, for example:
      
    ModelReplacementAPI.RegisterSuitModelReplacement("RegisterSuitName3", typeof(BodyReplacement3));
    ModelReplacementAPI.RegisterSuitModelReplacement("RegisterSuitName4", typeof(BodyReplacement4));

    public class BodyReplacement3 : BodyReplacementBase
    {
        protected override GameObject LoadAssetsAndReturnModel()
        {
            return Assets.MainAssetBundle.LoadAsset<GameObject>("Model3");
        }
    }
    public class BodyReplacement4 : BodyReplacementBase
    {
        protected override GameObject LoadAssetsAndReturnModel()
        {
            return Assets.MainAssetBundle.LoadAsset<GameObject>("Model4");
        }
    }
    */

    public static class Assets
    {

        //Copy the bundle to the project and select Embedded Resource
        //Below are the names of the bundles (lowercase)
        public static string mainAssetBundleName = "you bundle name";//This

        public static AssetBundle MainAssetBundle = null;

        private static string GetAssemblyName() => Assembly.GetExecutingAssembly().GetName().Name;
        public static void PopulateAssets()
        {
            if (MainAssetBundle == null)
            {
                using var assetStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(GetAssemblyName() + "." + mainAssetBundleName);
                MainAssetBundle = AssetBundle.LoadFromStream(assetStream);

            }
        }
    }

}
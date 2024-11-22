
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using System;

namespace HCC.Addressables
{
    public static class AssetLoader
    {
        #region Fields
        
        private static Action<object> _callbackOnComplete;
        
        #endregion

        #region Properties

        #endregion

        #region Functions
        
        #endregion

        #region Methods
        
        public static void LoadAddressable<TAddresableRef, TAddresableType>(TAddresableRef referenceAddressable, Action<TAddresableType> completeCallback) where TAddresableRef : AssetReferenceT<TAddresableType> where TAddresableType : UnityEngine.Object
        {
            var asset =  UnityEngine.AddressableAssets.Addressables.LoadAssetAsync<TAddresableType>(referenceAddressable);
            
            asset.Completed += (assetRef) => { completeCallback?.Invoke(assetRef.Result); };
        }


        public static void LoadAddresablePrefab(AssetReferenceGameObject assetReferenceGameObject, Action<object> onCompleteCallback) 
        {
            AsyncOperationHandle handler = assetReferenceGameObject.InstantiateAsync();

            _callbackOnComplete = onCompleteCallback;

            handler.Completed += (asyncHandler) => { OnCompleteOperationPrefab(asyncHandler, assetReferenceGameObject, onCompleteCallback); };
        
        
        }

        private static void OnCompleteOperationPrefab(AsyncOperationHandle operationHandler, AssetReferenceGameObject assetReferenceGameObject, Action<object> onCompleteCallback ) 
        { 
            if(operationHandler.Status == AsyncOperationStatus.Succeeded) 
            { 
                onCompleteCallback?.Invoke(operationHandler.Result);
                
            }
        }
        
        #endregion
    }
}
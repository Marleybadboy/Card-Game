using System.Collections.Generic;
using UnityEngine;

namespace HCC.Structs
{
    
        public readonly ref struct ShuffleDeck<TScriptableParam> where TScriptableParam : ScriptableObject
        {
            private readonly int _length;
            private readonly TScriptableParam[] _paramsRef;
            private readonly List<TScriptableParam> _results;
        
            public List<TScriptableParam> Result => _results;

            public ShuffleDeck(int length, TScriptableParam[] paramsRef)
            {
                _length = length;
                _paramsRef = paramsRef;
                _results = new List<TScriptableParam>();

                _results = GenerateScriptableTypes();

            }

            public void Execute() => ShuffleScriptableParam(_results);
   

            private void ShuffleScriptableParam(List<TScriptableParam> scriptableParams)
            {
                System.Random random = new System.Random();
            
                int n = scriptableParams.Count;

                while (n > 1)
                {
                    n--;
                    int k = random.Next(n + 1);
                    (scriptableParams[k], scriptableParams[n]) = (scriptableParams[n], scriptableParams[k]);
                }
            
            }
        
        
            private List<TScriptableParam> GenerateScriptableTypes()
            {
                List<TScriptableParam> cardTypes = new List<TScriptableParam>();
            
                int pairs = _length / 2;
            
                int cardTypeIndex = 0;
            
                for (int i = 0; i < pairs; i++)
                {
                    TScriptableParam scriptableParam = _paramsRef[cardTypeIndex];
                
                    cardTypes.AddRange(new TScriptableParam[] {scriptableParam, scriptableParam});
                
                    cardTypeIndex++;
                
                    if(cardTypeIndex >= _paramsRef.Length) cardTypeIndex = 0;
                
                }
                return cardTypes;
            }

        

        }
    
}
using TwentyFortyEight.Common;
using UnityEngine;

namespace TwentyFortyEight.PlayField.Logic
{
    public class BoardComponent : MonoBehaviour
    {
        [SerializeField] private int _amountOfRows;
        [SerializeField] private int _amountOfColumns;
        
        
        public IIndexable<IContainer<IContainer<int>>> Board { get; private set; }


        private void Awake()
        {
            Board = new Board(_amountOfRows, _amountOfColumns);
        }
    }
}
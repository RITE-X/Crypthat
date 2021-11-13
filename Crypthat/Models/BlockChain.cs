using System;
using System.Collections.Generic;
using System.Text;

namespace Crypthat.Models
{
    internal class BlockChain
    {
        private readonly List<Block> _blocks;

        public Block this[int index]
        {
            get => _blocks[index];
            set => _blocks[index] = value;
        }

        public Block this[Index index]
        {
            get => _blocks[index];
            set => _blocks[index] = value;
        }

        public BlockChain(string data)
        {
            _blocks = new List<Block> { new Block(data) };
        }

        public void Add(string data)
        {
            var bytes = Encoding.Latin1.GetBytes(data);
            _blocks.Add(new Block(_blocks[^1].Hash, data));
        }

        public void Insert(int index, string data)
        {
            _blocks[index].ReComputeHash(_blocks[index - 1].Hash, data);
            for (var i = index + 1; i < _blocks.Count; i++)
            {
                _blocks[i].ReComputeHash(_blocks[i - 1].Hash);
            }
        }

        public override string ToString()
        {
            StringBuilder blocksData = new StringBuilder(100);
            blocksData.Append($"Genesis Block: {_blocks[0]}");
            for (var i = 1; i < _blocks.Count; i++)
            {
                 
                blocksData.Append($"Блок {i}: {_blocks[i]}");
            }
            return blocksData.ToString();
        }

    }
}

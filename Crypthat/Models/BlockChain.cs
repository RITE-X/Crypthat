using System;
using System.Collections.Generic;
using System.Text;

namespace Crypthat.Models
{
    internal class BlockChain
    {
        private List<Block> blocks;

        public Block this[int index]
        {
            get => blocks[index];
            set => blocks[index] = value;
        }

        public Block this[Index index]
        {
            get => blocks[index];
            set => blocks[index] = value;
        }

        public BlockChain(string data)
        {
            blocks = new List<Block> { new Block(data) };
        }

        public void Add(string data)
        {
            var bytes = Encoding.Latin1.GetBytes(data);
            blocks.Add(new Block(blocks[^1].Hash, data));
        }

        public void Insert(int index, string data)
        {
            blocks[index].ReComputeHash(blocks[index - 1].Hash, data);
            for (var i = index + 1; i < blocks.Count; i++)
            {
                blocks[i].ReComputeHash(blocks[i - 1].Hash);
            }
        }

        public override string ToString()
        {
            StringBuilder blocksData = new StringBuilder(100);
            blocksData.Append($"Genesis Block: {blocks[0]}");
            for (int i = 1; i < blocks.Count; i++)
            {
                 
                blocksData.Append($"Блок {i}: {blocks[i]}");
            }
            return blocksData.ToString();
        }

    }
}

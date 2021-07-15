using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockChain
{
    class Chain
    {
        public Block[] Blocks
        {
            get 
            { 
                return blocks.ToArray();
            }
            
        }
        private List<Block> blocks;

        public Chain()
        {
            blocks = new List<Block>();
            var genesisBlock = new Block(); 
        }

        
    }
}

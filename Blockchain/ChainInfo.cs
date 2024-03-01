using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static web3s3m.Blockchain.ChainProvider;

namespace web3s3m.Blockchain
{
    public class ChainInfo
    {
        private static object JsonRpcsLocker = new object();
        public ChainName Name { get; set; }
        public TokenName Native { get; set; }
        public int Id { get; set; }
        public List<string> Rpcs { get; set; }
        public string Explorer { get; set; }
        public Dictionary<TokenName, string> TokenContracts { get; set; } = null;
        public void DeleteFirstRpc()
        {
            lock (JsonRpcsLocker)
                Rpcs.RemoveAt(0);
        }
    }
}

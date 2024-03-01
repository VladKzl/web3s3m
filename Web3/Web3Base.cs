using Nethereum.Web3;
using Nethereum.Web3.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using web3s3m.Blockchain;

namespace web3s3m
{
    public class Web3Base
    {
        public Web3Instance Web3Instance { get; set; }
        public ChainInfo ChainInfo => Web3Instance.ChainInfo;
        public Account Account => Web3Instance.Account;
        public Web3 Web3 => Web3Instance.Web3;
        public string Key => Web3Instance.Key;
        public Web3Base(Web3Instance web3Instance)
        {
            Web3Instance = web3Instance;
        }
        public void ChaingeWeb3Rpc()
        {
            ChainInfo.DeleteFirstRpc();
            if (!ChainInfo.Rpcs.Any())
            {
                throw new Exception(
                    $"Не ответил ни один Rpc в {ChainInfo.Name} сети.\r\n" +
                    $"Что то не то с интернетом или прокси..");
            }
            Web3Instance.Web3 = new Web3(Web3Instance.Account, Web3Instance.ChainInfo.Rpcs.First());
        }
    }
}

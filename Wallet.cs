using Nethereum.Contracts;
using Nethereum.Contracts.Standards.ERC20.TokenList;
using Nethereum.Hex.HexTypes;
using Nethereum.Signer;
using Nethereum.Web3;
using Nethereum.Web3.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using web3s3m.Blockchain;
using System.Numerics;
using Nethereum.Contracts.Extensions;
using Nethereum.ABI.Util;
using Nethereum.RPC.Eth.DTOs;
using System.Security.Claims;
using static System.Net.Mime.MediaTypeNames;
using web3s3m.Servises;

namespace web3s3m
{
    public class Wallet : WalletService
    {
        public Wallet(Web3Instance web3Base) : base(web3Base)
        { }
        public decimal GetNativeBalance()
        {
            HexBigInteger balanceWei = null;
            Task<HexBigInteger> task = Web3.Eth.GetBalance.SendRequestAsync(Account.Address);
            while (!task.CheckTask(ref balanceWei))
                ChaingeWeb3Rpc();
            return Web3.Convert.FromWei(BigInteger.Parse(balanceWei.Value.ToString()), 18); // decimals
        }
        public int GetAnyTokenBalance(TokenName token)
        {
            Validation();

            string tokenAdress = ChainInfo.TokenContracts.Single(x => x.Key == token).Value;

            Contract contract = Web3.Eth.GetContract(ChainProvider.UniversalERC20BEP20ABI, tokenAdress);
            Function function = null;
            try
            {
                 function = contract.GetFunction("balanceOf");
            }
            catch
            {
                function = contract.GetFunction("_balanceOf");
            }
            var callInput = function.CreateCallInput(Account.Address);

            HexBigInteger balanceWei = null;
            while (!function.CallAsync<HexBigInteger>(callInput).CheckTask(ref balanceWei))
                ChaingeWeb3Rpc();
            return 0;

            void Validation()
            {
                if (!GetAvailableTokenBalancesForQuery().Any(x => x == token))
                {
                    throw new Exception(
                        $"Запрос балланса {token} в сети {ChainInfo.Name}, невозможен. Токен не добавлен.\r\n" +
                        $"Кто нибудь, разбудите разработчика..");
                }
            }
        }
        public List<TokenName> GetAvailableTokenBalancesForQuery()
        {
            return ChainInfo.TokenContracts.Select(x => x.Key).ToList();
        }
    }
}

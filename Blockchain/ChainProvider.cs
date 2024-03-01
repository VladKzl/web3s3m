using Nethereum.Signer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace web3s3m.Blockchain
{
    public enum TokenName
    {
        USDT,USDC,DAI,BUSD,
        ETH,
        BNB,
        MATIC,
        WETH,
        WBNB,

        IZI,
    }
    public enum ChainType
    {
        Mainnet, SepoliaTestnet, GoerlyTestnet
    }
    public enum ChainName
    {
        Ethereum, EthereumSepolia, EthereumGoerly,
        Scroll, ScrollSepolia,
        Optimism,
        Arbitrum,
        zkSynk, zkSynkSepolia, zkSynkGoerly,
        Starknet,
        Zora,
        Base,
        Linea, LineaGoerly,
        Plygon,
        BNB, BNBTestnet,
        Mantle,
        MantaPacific,
        Zeta,
        ZkFair,
        Kroma,
        Meter,
        Ontology,
        Ultron,

        BeraTestnet,
    }
    public static class ChainProvider
    {
        private static List<ChainInfo> Chains = new List<ChainInfo>
        {
            new ChainInfo
            {
                Name = ChainName.Ethereum,
                Native = TokenName.ETH,
                Id = 1,
                Explorer = "https://etherscan.io",
                Rpcs = new List<string>() {
                    "https://eth.llamarpc.com",
                    "https://rpc.mevblocker.io",
                    "https://rpc.builder0x69.io",
                    "https://eth-pokt.nodies.app"
                },
                TokenContracts = new Dictionary<TokenName, string>() {
                    { TokenName.USDT, "0xdAC17F958D2ee523a2206206994597C13D831ec7" },//
                    { TokenName.DAI, "0x6B175474E89094C44Da98b954EedeAC495271d0F" },//
                    { TokenName.BUSD, "0x4Fabb145d64652a948d72533023f6E7A623C7C53" },//
                    { TokenName.WETH, "0xC02aaA39b223FE8D0A0e5C4F27eAD9083C756Cc2" }//
                }
            },
            new ChainInfo
            {
                Name = ChainName.BNB,
                Native = TokenName.BNB,
                Id = 56,
                Explorer = "https://bscscan.com",
                Rpcs = new List<string>() {
                    "https://binance.llamarpc.com",
                    "https://bsc-dataseed1.ninicoin.io",
                    "https://bsc-dataseed3.defibit.io",
                    "https://bsc-dataseed.bnbchain.org"
                },
                TokenContracts = new Dictionary<TokenName, string>() {
                    { TokenName.USDT, "0x55d398326f99059fF775485246999027B3197955"},//
                    { TokenName.USDC, "0x8AC76a51cc950d9822D68b83fE1Ad97B32Cd580d"},//
                    { TokenName.BUSD, "0xe9e7CEA3DedcA5984780Bafc599bD69ADd087D56"},//
                    { TokenName.WBNB, "0xbb4CdB9CBd36B01bD1cBaEBF2De08d9173bc095c"},//
                }
            },
            new ChainInfo
            {
                Name = ChainName.Scroll,
                Native = TokenName.ETH,
                Id = 534352,
                Explorer = "https://scrollscan.com/",
                Rpcs = new List<string>() {
                    "https://rpc.scroll.io/",
                    "https://scroll.drpc.org",
                    "https://1rpc.io/scroll",
                    "https://scroll-mainnet.public.blastapi.io"
                },
                TokenContracts = new Dictionary<TokenName, string>() {
                    { TokenName.USDT, "0xf55BEC9cafDbE8730f096Aa55dad6D22d44099Df"},//
                    { TokenName.USDC, "0x06eFdBFf2a14a7c8E15944D1F4A48F9F95F663A4"},//
                    { TokenName.DAI, "0xcA77eB3fEFe3725Dc33bccB54eDEFc3D9f764f97"},//
                    { TokenName.WETH, "0x5300000000000000000000000000000000000004"},//
                }
            }
        };
        private static List<ChainInfo> SepoliaChains = new List<ChainInfo>
        {
            new ChainInfo
            {
                Name = ChainName.EthereumSepolia,
                Native = TokenName.ETH,
                Id = 11155111,
                Explorer = "https://sepolia.etherscan.io",
                Rpcs = new List<string>() {
                    "https://rpc2.sepolia.org",
                    "https://1rpc.io/sepolia",
                    "https://rpc.sepolia.org",
                    "https://rpc-sepolia.rockx.com"
                },
                TokenContracts = new Dictionary<TokenName, string>() {
                    { TokenName.USDT, "0xdAC17F958D2ee523a2206206994597C13D831ec7"},
                    { TokenName.USDC, "0xA0b86991c6218b36c1d19D4a2e9Eb0cE3606eB48"},
                    { TokenName.DAI, "0x6B175474E89094C44Da98b954EedeAC495271d0F"},
                    { TokenName.BUSD, "0x7B4B0B9b024109D182dCF3831222fbdA81369423"},
                    { TokenName.WETH, "0xC02aaA39b223FE8D0A0e5C4F27eAD9083C756Cc2"},
                }
            },
            new ChainInfo
            {
                Name = ChainName.ScrollSepolia,
                Native = TokenName.ETH,
                Id = 534351,
                Explorer = "https://sepolia.scrollscan.com",
                Rpcs = new List<string>() {
                    "https://sepolia-rpc.scroll.io",
                    "https://scroll-testnet-public.unifra.io",
                    "https://sepolia-rpc.scroll.io",
                    "https://scroll-sepolia.blockpi.network/v1/rpc/pu"
                },
                TokenContracts = new Dictionary<TokenName, string>() {
                    { TokenName.USDT, "0x551197e6350936976DfFB66B2c3bb15DDB723250"},//
                    { TokenName.WETH, "0xfa6a407c4C49Ea1D46569c1A4Bcf71C3437bE54c"},//
                }
            }
        };
        private static List<ChainInfo> GoerlyChains = new List<ChainInfo>
        { };
        private static List<ChainInfo> TestnetChains = new List<ChainInfo>()
        {
            new ChainInfo
            {
                Name = ChainName.BNBTestnet,
                Native = TokenName.BNB,
                Id = 97 ,
                Explorer = "https://bscscan.com",
                Rpcs = new List<string>() {
                    "https://endpoints.omniatech.io/v1/bsc/testnet/public",
                    "https://bsc-testnet-rpc.publicnode.com",
                    "https://bsc-testnet.blockpi.network/v1/rpc/public",
                    "https://bsc-testnet.public.blastapi.io"
                },
                TokenContracts = new Dictionary<TokenName, string>() {
                    { TokenName.USDT, "0x6AECfe44225A50895e9EC7ca46377B9397D1Bb5b"},//
                    { TokenName.USDC, "0x876508837C162aCedcc5dd7721015E83cbb4e339"},//
                    { TokenName.BUSD, "0xe9e7CEA3DedcA5984780Bafc599bD69ADd087D56"},//
                    { TokenName.WBNB, "0xae13d989daC2f0dEbFf460aC112a837C89BAa7cd" },//
                    { TokenName.IZI, "0x551197e6350936976DfFB66B2c3bb15DDB723250"},//
                }
            },
        };
        public static string UniversalERC20BEP20ABI = @"[
          {""constant"":true,""inputs"":[],""name"":""_name"",""outputs"":[{""name"":"""",""type"":""string""}],""payable"":false,""stateMutability"":""view"",""type"":""function""},
          {""constant"":true,""inputs"":[],""name"":""_symbol"",""outputs"":[{""name"":"""",""type"":""string""}],""payable"":false,""stateMutability"":""view"",""type"":""function""},
          {""constant"":true,""inputs"":[],""name"":""_decimals"",""outputs"":[{""name"":"""",""type"":""uint8""}],""payable"":false,""stateMutability"":""view"",""type"":""function""},
          {""constant"":true,""inputs"":[{""name"":""_owner"",""type"":""address""}],""name"":""_balanceOf"",""outputs"":[{""name"":""balance"",""type"":""uint256""}],""payable"":false,""stateMutability"":""view"",""type"":""function""},
          {""constant"":false,""inputs"":[{""name"":""_to"",""type"":""address""},{""name"":""_value"",""type"":""uint256""}],""name"":""_transfer"",""outputs"":[{""name"":"""",""type"":""bool""}],""payable"":false,""stateMutability"":""nonpayable"",""type"":""function""},
          {""constant"":false,""inputs"":[{""name"":""_spender"",""type"":""address""},{""name"":""_value"",""type"":""uint256""}],""name"":""_approve"",""outputs"":[{""name"":"""",""type"":""bool""}],""payable"":false,""stateMutability"":""nonpayable"",""type"":""function""},
          {""constant"":true,""inputs"":[{""name"":""_owner"",""type"":""address""},{""name"":""_spender"",""type"":""address""}],""name"":""_allowance"",""outputs"":[{""name"":""remaining"",""type"":""uint256""}],""payable"":false,""stateMutability"":""view"",""type"":""function""},
          {""constant"":false,""inputs"":[{""name"":""_from"",""type"":""address""},{""name"":""_to"",""type"":""address""},{""name"":""_value"",""type"":""uint256""}],""name"":""_transferFrom"",""outputs"":[{""name"":"""",""type"":""bool""}],""payable"":false,""stateMutability"":""nonpayable"",""type"":""function""},
          {""constant"":true,""inputs"":[],""name"":""name"",""outputs"":[{""name"":"""",""type"":""string""}],""payable"":false,""stateMutability"":""view"",""type"":""function""},
          {""constant"":true,""inputs"":[],""name"":""symbol"",""outputs"":[{""name"":"""",""type"":""string""}],""payable"":false,""stateMutability"":""view"",""type"":""function""},
          {""constant"":true,""inputs"":[],""name"":""decimals"",""outputs"":[{""name"":"""",""type"":""uint8""}],""payable"":false,""stateMutability"":""view"",""type"":""function""},
          {""constant"":true,""inputs"":[{""name"":""_owner"",""type"":""address""}],""name"":""balanceOf"",""outputs"":[{""name"":""balance"",""type"":""uint256""}],""payable"":false,""stateMutability"":""view"",""type"":""function""},
          {""constant"":false,""inputs"":[{""name"":""_to"",""type"":""address""},{""name"":""_value"",""type"":""uint256""}],""name"":""transfer"",""outputs"":[{""name"":"""",""type"":""bool""}],""payable"":false,""stateMutability"":""nonpayable"",""type"":""function""},
          {""constant"":false,""inputs"":[{""name"":""_spender"",""type"":""address""},{""name"":""_value"",""type"":""uint256""}],""name"":""approve"",""outputs"":[{""name"":"""",""type"":""bool""}],""payable"":false,""stateMutability"":""nonpayable"",""type"":""function""},
          {""constant"":true,""inputs"":[{""name"":""_owner"",""type"":""address""},{""name"":""_spender"",""type"":""address""}],""name"":""allowance"",""outputs"":[{""name"":""remaining"",""type"":""uint256""}],""payable"":false,""stateMutability"":""view"",""type"":""function""},
          {""constant"":false,""inputs"":[{""name"":""_from"",""type"":""address""},{""name"":""_to"",""type"":""address""},{""name"":""_value"",""type"":""uint256""}],""name"":""transferFrom"",""outputs"":[{""name"":"""",""type"":""bool""}],""payable"":false,""stateMutability"":""nonpayable"",""type"":""function""}
        ]";
        public static string ERC721NFTABI = @"[
            {""constant"": true, ""inputs"": [{""name"": ""_tokenId"", ""type"": ""uint256""}], ""name"": ""ownerOf"", ""outputs"": [{""name"": ""owner"", ""type"": ""address""}], ""payable"": false, ""type"": ""function""},
            {""constant"": true, ""inputs"": [], ""name"": ""name"", ""outputs"": [{""name"": """", ""type"": ""string""}], ""payable"": false, ""type"": ""function""},
            {""constant"": true, ""inputs"": [{""name"": ""_owner"", ""type"": ""address""}], ""name"": ""balanceOf"", ""outputs"": [{""name"": ""balance"", ""type"": ""uint256""}], ""payable"": false, ""type"": ""function""},
            {""constant"": true, ""inputs"": [], ""name"": ""symbol"", ""outputs"": [{""name"": """", ""type"": ""string""}], ""payable"": false, ""type"": ""function""},
            {""constant"": true, ""inputs"": [{""name"": ""_tokenId"", ""type"": ""uint256""}], ""name"": ""getApproved"", ""outputs"": [{""name"": ""operator"", ""type"": ""address""}], ""payable"": false, ""type"": ""function""},
            {""constant"": true, ""inputs"": [], ""name"": ""baseURI"", ""outputs"": [{""name"": """", ""type"": ""string""}], ""payable"": false, ""type"": ""function""},
            {""constant"": true, ""inputs"": [], ""name"": ""totalSupply"", ""outputs"": [{""name"": ""total"", ""type"": ""uint256""}], ""payable"": false, ""type"": ""function""},
            {""constant"": true, ""inputs"": [{""name"": ""_tokenId"", ""type"": ""uint256""}], ""name"": ""tokenURI"", ""outputs"": [{""name"": ""uri"", ""type"": ""string""}], ""payable"": false, ""type"": ""function""},
            {""constant"": true, ""inputs"": [], ""name"": ""supportsInterface"", ""outputs"": [{""name"": """", ""type"": ""bool""}], ""payable"": false, ""type"": ""function""},
            {""payable"": false, ""type"": ""fallback""},
            {""anonymous"": false, ""inputs"": [{""indexed"": true, ""name"": ""from"", ""type"": ""address""}, {""indexed"": true, ""name"": ""to"", ""type"": ""address""}, {""indexed"": true, ""name"": ""tokenId"", ""type"": ""uint256""}], ""name"": ""Transfer"", ""type"": ""event""},
            {""anonymous"": false, ""inputs"": [{""indexed"": true, ""name"": ""owner"", ""type"": ""address""}, {""indexed"": true, ""name"": ""approved"", ""type"": ""address""}, {""indexed"": true, ""name"": ""tokenId"", ""type"": ""uint256""}], ""name"": ""Approval"", ""type"": ""event""},
            {""anonymous"": false, ""inputs"": [{""indexed"": true, ""name"": ""owner"", ""type"": ""address""}, {""indexed"": true, ""name"": ""operator"", ""type"": ""address""}, {""indexed"": false, ""name"": ""approved"", ""type"": ""bool""}], ""name"": ""ApprovalForAll"", ""type"": ""event""},
            {""constant"": false, ""inputs"": [{""name"": ""_to"", ""type"": ""address""}, {""name"": ""_tokenId"", ""type"": ""uint256""}], ""name"": ""transferFrom"", ""outputs"": [], ""payable"": false, ""type"": ""function""},
            {""constant"": false, ""inputs"": [{""name"": ""_to"", ""type"": ""address""}, {""name"": ""_tokenId"", ""type"": ""uint256""}], ""name"": ""safeTransferFrom"", ""outputs"": [], ""payable"": false, ""type"": ""function""},
            {""constant"": false, ""inputs"": [{""name"": ""_to"", ""type"": ""address""}, {""name"": ""_tokenId"", ""type"": ""uint256""}, {""name"": ""_data"", ""type"": ""bytes""}], ""name"": ""safeTransferFrom"", ""outputs"": [], ""payable"": false, ""type"": ""function""},
            {""constant"": false, ""inputs"": [{""name"": ""_spender"", ""type"": ""address""}, {""name"": ""_tokenId"", ""type"": ""uint256""}], ""name"": ""approve"", ""outputs"": [], ""payable"": false, ""type"": ""function""},
            {""constant"": false, ""inputs"": [{""name"": ""_operator"", ""type"": ""address""}, {""name"": ""_approved"", ""type"": ""bool""}], ""name"": ""setApprovalForAll"", ""outputs"": [], ""payable"": false, ""type"": ""function""},
            {""constant"": false, ""inputs"": [{""name"": ""_from"", ""type"": ""address""}, {""name"": ""_to"", ""type"": ""address""}, {""name"": ""_tokenId"", ""type"": ""uint256""}], ""name"": ""transferFrom"", ""outputs"": [], ""payable"": false, ""type"": ""function""},
            {""constant"": false, ""inputs"": [{""name"": ""_from"", ""type"": ""address""}, {""name"": ""_to"", ""type"": ""address""}, {""name"": ""_tokenId"", ""type"": ""uint256""}, {""name"": ""_data"", ""type"": ""bytes""}], ""name"": ""safeTransferFrom"", ""outputs"": [], ""payable"": false, ""type"": ""function""},
            {""constant"": false, ""inputs"": [{""name"": ""_name"", ""type"": ""string""}], ""name"": ""setName"", ""outputs"": [], ""payable"": false, ""type"": ""function""},
            {""constant"": false, ""inputs"": [{""name"": ""_symbol"", ""type"": ""string""}], ""name"": ""setSymbol"", ""outputs"": [], ""payable"": false, ""type"": ""function""}
        ]";
        public static ChainInfo GetChainInfo(ChainName chainName)
        {
            return Get();

            ChainInfo Get()
            {
                if (Chains.Any(x => x.Name == chainName))
                    return Chains.Single(x => x.Name == chainName);
                if (SepoliaChains.Any(x => x.Name == chainName))
                    return SepoliaChains.Single(x => x.Name == chainName);
                if (GoerlyChains.Any(x => x.Name == chainName))
                    return GoerlyChains.Single(x => x.Name == chainName);
                if (TestnetChains.Any(x => x.Name == chainName))
                    return TestnetChains.Single(x => x.Name == chainName);

                throw new Exception(
                    $"Cеть {chainName} отсутвует в списке сетей.\r\n" +
                    $"Кто нибудь, разбудите разработчика..");
            }
        }
    }
}

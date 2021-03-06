using System;
using NBitcoin;
using Nethereum.Hex.HexConvertors.Extensions;

namespace HDWallet.Core
{
    public abstract class HdWalletBase
    {
        public string BIP39Seed { get; private set; }

        public HdWalletBase(string seed)
        {
            if(string.IsNullOrEmpty(seed)) throw new NullReferenceException(nameof(seed));

            BIP39Seed = seed;
        }

        public HdWalletBase(string words, string seedPassword)
        {
            if(string.IsNullOrEmpty(words)) throw new NullReferenceException(nameof(words));

            var mneumonic = new Mnemonic(words);
            BIP39Seed = mneumonic.DeriveSeed(seedPassword).ToHex();
        }
    }
}
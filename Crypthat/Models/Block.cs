using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Crypthat.Models
{
    internal class Block
    {
        internal byte[] Hash { get; private set; }

        internal string Data { get; private set; }

        internal Block(string data)
        {
            Data = data;
            ComputeHash();
        }

        internal Block(byte[] hash, string data)
        {
            Data = data;
            ReComputeHash(hash);
        }

        private void ComputeHash()
        {
            Hash = SHA256.Create().ComputeHash(Encoding.Latin1.GetBytes(Data));
        }

        public void ReComputeHash(byte[] _previousHash)
        {
            Hash = SHA256.Create().ComputeHash(_previousHash.Concat(Encoding.Latin1.GetBytes(Data)).ToArray());
        }

        public void ReComputeHash(byte[] _previousHash, string data)
        {
            Data = data;
            Hash = SHA256.Create().ComputeHash(_previousHash.Concat(Encoding.Latin1.GetBytes(Data)).ToArray());
        }

        public override string ToString()
        {
            return $"{Data} -> {Convert.ToBase64String(Hash)}\n";
        }
    }
}


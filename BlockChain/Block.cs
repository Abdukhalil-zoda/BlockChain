using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BlockChain
{
    /// <summary>
    /// Malumotlar Blocki
    /// </summary>
    class Block
    {
        /// <summary>
        /// Identifikator
        /// </summary>
        public UInt64 ID { get; private set; }
        /// <summary>
        /// Malumotlar
        /// </summary>
        public string Data { get; private set; }
        /// <summary>
        /// Yaratilgan sana
        /// </summary>
        public DateTime Created { get; private set; }
        /// <summary>
        /// block heshi
        /// </summary>
        public string Hash { get; private set; }
        /// <summary>
        /// oldingi block heshi
        /// </summary>
        public string PreviousHash { get; private set; }
        /// <summary>
        /// foydalanuvchi nome
        /// </summary>
        public string User { get; set; }
        /// <summary>
        /// Genezis bolck konstruktori
        /// </summary>
        public Block()
        {
            ID = 1;
            Data = "Hello world";
            Created = DateTime.UtcNow;
            PreviousHash = "111";
            User = "Admin";

            var blockData = GetData();
            Hash = GetHash(blockData);
        }

        public Block(string data, string user, Block block)
        {
            if (string.IsNullOrWhiteSpace(data))
            {
                throw new ArgumentException("data can't be null", nameof(data));
            }

            if (string.IsNullOrWhiteSpace(user))
            {
                throw new ArgumentException("user can't be null", nameof(user));
            }

            if (block == null)
            {
                throw new ArgumentException("block can't be null", nameof(block));
            }

            Data = data;
            User = user;
            PreviousHash = block.Hash;
            Created = DateTime.UtcNow;
            ID = block.ID + 1;

            var blockData = GetData();
            Hash = GetHash(blockData);
        }

        string GetData()
        {
            string res = "";

            res += ID.ToString();
            res += Data;
            res += Created.ToString("dd.MM.yyyy HH:mm:ss.fff");
            res += PreviousHash;
            res += User;

            return res;
        }

        string GetHash(string data)
        {
            var mes = Encoding.ASCII.GetBytes(data);
            var Hasher = new SHA256Managed();
            string hex = "";

            var hash = Hasher.ComputeHash(mes);

            foreach (var item in hash)
            {
                hex += string.Format($"{item:x2}");
            }
            return hex;
        }
    }
}

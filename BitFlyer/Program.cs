﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace BitFlyer
{
   public class Program
    {
        public static void Main(string[] args)
        {
            var res =BitFlyerTestCore();
            //Console.WriteLine("Total Size : {0} bytes", res.Size );
            Console.WriteLine("Total Fee : {0} BTC", res.Fee );
        }

        private static Transaction BitFlyerTestCore()
        {
            List<Transaction> ListTrans = new List<Transaction>() {
                new Transaction { Size = 57247,  Fee = 0.0887 },
                new Transaction { Size = 98732,  Fee = 0.1856 },
                new Transaction { Size = 134928, Fee = 0.2307 },
                new Transaction { Size = 77275,  Fee = 0.1522 },
                new Transaction { Size = 29240,  Fee = 0.0532 },
                new Transaction { Size = 15440,  Fee = 0.0250 },
                new Transaction { Size = 70820,  Fee = 0.1409 },
                new Transaction { Size = 139603, Fee = 0.2541 },
                new Transaction { Size = 63718,  Fee = 0.1147 },
                new Transaction { Size = 143807, Fee = 0.2660 },
                new Transaction { Size = 190457, Fee = 0.2933 },
                new Transaction { Size = 40572,  Fee = 0.0686 }
            };
            double TotalFee = 12.5;
            double TotalSize = 0;
            double Limit = 500000;
            while ( ListTrans.Where(k=> k.Size <= (Limit - TotalSize)).Sum(k => k.Size) > 0)
            {
                Transaction obj = ListTrans.Where(k => k.Size <= (Limit - TotalSize)).Distinct().OrderByDescending(x => x.Size).FirstOrDefault();
                if (TotalSize + obj.Size <= Limit)
                {
                    TotalFee += obj.Fee;
                    TotalSize += obj.Size;
                    ListTrans.Remove(obj);
                }
            }
            var res = new Transaction() { Fee = TotalFee, Size = TotalSize };
            return  res;
        }

        class Transaction
        {
            public double Size { get; set; }
            public double Fee { get; set; }
        }

    }
}

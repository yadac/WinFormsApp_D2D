﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SOLIDInterfaces;

namespace SOLIDConcreates
{
    public class StreamTradeDataProvider : ITradeDataProvider
    {
        private readonly Stream stream;
        public StreamTradeDataProvider(Stream stream)
        {
            this.stream = stream;
        }

        public IEnumerable<string> GetTradeData()
        {
            var tradeData = new List<string>();
            using (var reader = new StreamReader(stream))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                    tradeData.Add(line);
            }
            return tradeData;
        }
    }
}

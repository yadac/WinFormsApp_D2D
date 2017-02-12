using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;


namespace LogTest
{
    class Program
    {
        static void Main(string[] args)
        {
            ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            logger.Debug("開発中のデバッグ／トレースに使用する");
            logger.Info("情報（操作履歴等）");
            logger.Warn("注意／警告（障害の一歩手前）");
            logger.Error("システムが停止するまではいかない障害が発生");
            logger.Fatal("システムが停止する致命的な障害が発生");

        }
    }
}

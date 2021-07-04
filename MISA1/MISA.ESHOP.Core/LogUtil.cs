using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ESHOP.Core
{
    /// <summary>
    /// Xu ly ghi log he thong
    /// </summary>
    public static class LogUtil
    {
        /// <summary>
        /// Log info
        /// </summary>
        /// <param name="message"></param>
        public static void Info(string message)
        {
            Console.WriteLine($"[INF]{message}");
        }


        /// <summary>
        /// Log info
        /// </summary>
        /// <param name="message"></param>
        public static void Debug(string message)
        {
            Console.WriteLine($"[DEG]{message}");
        }
        /// <summary>
        /// Log info
        /// </summary>
        /// <param name="message"></param>
        public static void Error(Exception ex)
        {
            Console.WriteLine($"[ERR]{ex}");
        }
    }
}

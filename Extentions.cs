using Microsoft.Extensions.Logging;
using Nethereum.Signer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace web3s3m
{
    public static class Extentions
    {
        public static bool CheckTask<T>(this Task<T> task, ref T taskResult)
        {
            try
            {
                task.ConfigureAwait(true);
                task.Wait();
            }
            catch (Exception ex)
            {
                return false;
            }
            if (task.IsFaulted || task.Exception != null)
            {
                return false;
            }
            if (task.Status != TaskStatus.RanToCompletion)
            {
                return false;
            }
            taskResult = task.Result;
            return true;
        }
    }
}

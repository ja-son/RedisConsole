using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedisConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            if(args.Length < 1)
            {
                Console.Error.WriteLine("Missing Redis Connection String");
                return;
            }

            using (var mgr = new ServiceStack.Redis.RedisManagerPool(args[0]))
            using (var cache = mgr.GetCacheClient())
            {
                cache.Set("RedisConsole.Test", "This is a test", DateTime.UtcNow.AddMinutes(1));

                Console.WriteLine("Redis Cache appears to be working.");
            }
        }
    }
}

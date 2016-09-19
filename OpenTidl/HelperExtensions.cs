using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace OpenTidl
{
    public static class HelperExtensions
    {
        public static Byte[] ToArray(this Stream stream, Int32? timeout = null)
        {
            using (var ms = new MemoryStream())
            {
                var task = stream.CopyToAsync(ms);
                if (timeout.HasValue && !task.Wait(timeout.Value))
                    throw new TimeoutException();
                else if (!timeout.HasValue)
                    task.Wait();
                return ms.ToArray();
            }
        }
        
        /// <summary>
        /// Warning: causes deadlocks when used on UI thread
        /// </summary>
        private static T Sync<T>(this Task<T> task, Int32? timeout = null)
        {
            if (timeout.HasValue && !task.Wait(timeout.Value))
                throw new TimeoutException();
            /*if (!timeout.HasValue)
                task.Wait();*/
            return task.Result;
        }

        public static T Sync<T>(this Func<Task<T>> task, Int32? timeout = null)
        {
            return Task.Run(task).Sync(timeout);
        }
    }
}

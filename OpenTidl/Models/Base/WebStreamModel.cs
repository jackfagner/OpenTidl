using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTidl;
using System.IO;
using System.Net;

namespace OpenTidl.Models.Base
{
    public class WebStreamModel
    {
        #region properties

        public Stream Stream { get; private set; }
        public Int64 ContentLength { get; private set; }

        #endregion


        #region methods

        public Byte[] ToArray()
        {
            return this.Stream.ToArray();
        }

        #endregion


        #region construction

        internal WebStreamModel(HttpWebResponse response)
        {
            try
            {
                if (response != null)
                {
                    this.ContentLength = response.ContentLength;
                    this.Stream = response.GetResponseStream();
                }
            }
            catch { }
        }

        #endregion
    }
}

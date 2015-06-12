using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace USC.GISResearchLab.Common.Core.Network.DNS
{
    public class DNSResolver
    {

        public static string[] ResolveDomainName(string domainName)
        {
            string[] ret = null;
            try
            {
                IPAddress[] addresses = Dns.GetHostAddresses(domainName);
                if (addresses != null)
                {
                    ret = new string[addresses.Length];

                    for (int i = 0; i < addresses.Length; i++)
                    {
                        ret[i] = addresses[i].ToString();
                    }
                }
            }
            catch (SocketException se)
            {
                // do nothing, this host can't be resolved so the return should be null
            }
            catch (Exception e)
            {
                throw new Exception("An exception occurred trying to resolve domain name ", e);
            }
            return ret;
        }

    }
}

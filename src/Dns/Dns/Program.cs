using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;

//dotnet run 127.0.0.1 www.baidu.com sports.sina.com.cn localhost

var ips = ResolveNetworkInterfaces();
foreach (var item in ips)
{
    Console.WriteLine(item);
}

void ResoveByHostName()
{
    foreach (var ip in args)
    {
        var hostEntry = Dns.GetHostEntry(ip);
        System.Console.WriteLine($"主机名：{hostEntry.HostName}");
        foreach (var address in hostEntry.AddressList)
            System.Console.WriteLine($"  地址：{address}");
        System.Console.WriteLine("-------------------------------------------");
    }
}

IEnumerable<string> ResolveNetworkInterfaces()
{
    foreach (NetworkInterface netInt in NetworkInterface.GetAllNetworkInterfaces())
    {
        IPInterfaceProperties property = netInt.GetIPProperties();
        foreach (UnicastIPAddressInformation ip in property.UnicastAddresses)
        {
            if (ip.IsDnsEligible && ip.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
            {
                // Windows不包含
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows)
                    && !ip.IsDnsEligible)
                {
                    continue;
                }

                var ipaddr = ip.Address.ToString();
                yield return ipaddr;
            }
        }
    }
}
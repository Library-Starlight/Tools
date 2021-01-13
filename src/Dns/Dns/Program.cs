using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using static System.Net.NetworkResolver;

//dotnet run 127.0.0.1 www.baidu.com sports.sina.com.cn localhost

var ips = ResolveNetworkInterfaces();
foreach (var item in ips)
{
    Console.WriteLine(item);
}

var ipaddresses = GetHostNetworkInterface();
foreach (var item in ipaddresses)
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

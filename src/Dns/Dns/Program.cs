using System;
using System.Net;

//dotnet run 127.0.0.1 www.baidu.com sports.sina.com.cn localhost
foreach (var ip in args)
{
    var hostEntry = Dns.GetHostEntry(ip);
    System.Console.WriteLine($"主机名：{hostEntry.HostName}");
    foreach (var address in hostEntry.AddressList)
        System.Console.WriteLine($"  地址：{address}");
    System.Console.WriteLine("-------------------------------------------");
}
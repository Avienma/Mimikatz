# 这是个什么项目
用c#实现了个远程拉取Mimikatz.ps1到内存加载，分离免杀

# 为什么写这个项目
最近学了学c#，c#可以调用powershell模块的接口所以有了通过远程拉取mimikatz的ps脚本到内存中来规避一些杀软的检测，据我所知国内对启动powershell进程这种行为十分敏感，但是基于调用接口内存远程加载拉取有很好的规避效果

# 项目不足改进
这个项目只是我拿来学习c#练手的项目并没有去想如何进一步混淆特征 流量 规避启发式检测 这种方式可以很好躲开基于进程链的检查
所以免杀还不是很完美，师傅可以下去自行修改



usage：
本地启一个http的服务 把ps脚本放到根目录等待请求
c#写好的程序以管理员运行
效果就是这样的
![图片](https://user-images.githubusercontent.com/83112602/233889894-f0b5b048-aede-45ed-98fa-5c40c33601be.png)



国内杀软比如火绒 360也是都没有问题
![图片](https://user-images.githubusercontent.com/83112602/233890261-e8c5b809-41aa-4c5e-9a41-1ac753d7ee71.png)
![图片](https://user-images.githubusercontent.com/83112602/233890371-91e646b1-bc24-466d-a0c7-915be73314c4.png)

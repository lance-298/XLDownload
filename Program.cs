using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XunleiDownloadDemo
{
    public class Program
    {
        static void Main(string[] args)
        {
            //加载dll
            XLApiDownloadHelper downloadHelper = new XLApiDownloadHelper();

            //下载
            XLApiDownload();

            Console.Read();
        }

        public static void XLApiDownload()
        {
            var ok = XLApi.Init();
            Debug.Assert(ok);

            // 下载限速
            //XLApi.SetSpeedLimit(500);

            // 上传限速
            //XLApi.SetUploadSpeedLimit(100, 100);

            //Test1();
            //Test2();
            List<IntPtr> tasks = new List<IntPtr>();
            Parallel.For(0, 10, i =>
            {
                // 建立任务
                //https://down5.huorong.cn/sysdiag-all-4.0.19.4.exe
                //http://192.168.0.65:8018//Video/2018-04-19/03705759-9FC0-4828-A895-BA8FD6ADEE38.mp4
                //http://192.168.0.65:8018//Video/20180330/sample.mp4
                var param = new XLApi.DownTaskParam()
                {
                    TaskUrl = "http://192.168.0.65:8018//Video/20180330/sample.mp4",
                    SavePath = @"D:\Down",
                    FileName = string.Format("video{0}.mp4", i)
                };
                var task = XLApi.CreateTask(param);
                tasks.Add(task);

                // 启动任务
                var rs = XLApi.StartTask(task);
                //Thread.Sleep(5000);

                //lock (obj)
                //{
                var taskInfo = new XLApi.TaskInfo();
                while (XLApi.QueryTaskInfoEx(task, taskInfo))
                {
                    switch (taskInfo.State)
                    {
                        case XLApi.TaskStatus.Startpending:
                            Console.WriteLine("task {0} {1}", taskInfo.FileName, taskInfo.State);
                            break;
                        case XLApi.TaskStatus.Download:
                            Console.WriteLine("task {0} {1},percent: {2:N2}%, speed: {3:N2}MB/s,downloded: {4:N2}MB,totalSize: {5:N2}MB", taskInfo.FileName, taskInfo.State, taskInfo.Percent * 100, taskInfo.Speed * 1.0 / 1024 / 1024, taskInfo.TotalDownload * 1.0 / 1024 / 1024, taskInfo.TotalSize * 1.0 / 1024 / 1024);
                            break;
                        case XLApi.TaskStatus.Complete:
                            Console.WriteLine("task {0} {1}", taskInfo.FileName, taskInfo.State);
                            XLApi.StopTask(task);
                            XLApi.DeleteTask(task);
                            return;
                        case XLApi.TaskStatus.Stoppending:
                            Console.WriteLine("task {0} {1}", taskInfo.FileName, taskInfo.State);
                            XLApi.StopTask(task);
                            return;
                        default:
                            break;
                    }

                    //Thread.Sleep(1000);
                }
                //}


            });

            //tasks.ForEach(task =>
            //{                
            //    // 移除任务
            //    ok = XLApi.DeleteTask(task);
            //});

            Console.WriteLine("End");
            Console.ReadLine();

            ok = XLApi.UnInit();
            Debug.Assert(ok);
        }
    }
}

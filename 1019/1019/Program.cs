using _1019.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _1019
{
    class Program
    {
        static void Main(string[] args)
        {
            Service.ImportService importService = new Service.ImportService();
            var nodes = importService.FindOpenData();
            importService.ImportToDb(nodes);
            showOpenData(nodes);
            Console.ReadKey();

        }
        public void Configure()
        {
            string baseDir = Directory.GetCurrentDirectory();

            AppDomain.CurrentDomain.SetData("DataDirectory", System.IO.Path.Combine(baseDir, "Data"));
        }



        private static void showOpenData(List<OpenData> nodes)
        {

            Console.WriteLine(string.Format("共收到{0}筆的資料", nodes.Count));
            nodes.GroupBy(node => node.服務分類).ToList()
                .ForEach(group =>
                {
                    var key = group.Key;
                    var groupDatas = group.ToList();
                    var message = $"服務分類:{key},共有{groupDatas.Count()}筆資料";
                    Console.WriteLine(message);
                });
        }
    }
}

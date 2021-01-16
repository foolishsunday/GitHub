using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ioc
{
    public static class DispatchHandler
    {
        public static void DownloadSuccessResult(DispatchEventArgs e)
        {

            var data = e.ResultData.First();
            Console.WriteLine("key = {0}, value = {1}", data.Key, data.Value);
            Console.WriteLine("name = {0}, id = {1}", e.Name, e.Id);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var data = new DispatchEventArgs();
            data.Command = "DownloadSuccessResult";
            data.Id = System.Guid.NewGuid().ToString();
            data.Name = "Factory";

            var collection = new KeyValueCollection();
            collection.Add(new KeyValuePair { Key = "StoreName", Value = "LUL" });
            data.ResultData = collection;
            data.Type = "ClientRequest";
            DispatchWork(null, data);
            Console.ReadKey();
        }
        public static void DispatchWork(object sender, DispatchEventArgs e)
        {
            if (e.Type == "ClientRequest")
            {
                try
                {
                    typeof(DispatchHandler).GetMethod(e.Command).Invoke(null, new object[] { e });
                }
                catch (Exception ex)
                {
                    string error = ex.ToString();
                    //Log
                }
            }
        }

    }
    public class BaseEventArgs : EventArgs
    {
        public string Name { get; set; }
        public string Id { get; set; }

    }
    public class ReportMessageEventArgs<T> : BaseEventArgs
    {
        public T Data { get; set; }
    }
    public class KeyValuePair
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }
    public class KeyValueCollection : Collection<KeyValuePair>
    {
        public KeyValuePair this[string key] { get { return this[key]; } }
        //public bool ContainKey(string key) 
    }
    public class DispatchEventArgs : ReportMessageEventArgs<KeyValueCollection>
    {
        public string Type { get; set; }
        public string Command { get; set; }
        public KeyValueCollection ResultData { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOC_App
{
    public static class SpecifyInfoHandler
    {
        public static CKeyValuePairCollection DownloadSuccessResult(GetSpecifyInfoEventArgs e)
        {
            var resultData = new CKeyValuePairCollection();
            resultData.Add(new CKeyValuePairInfo() { Key = "cim", Value = "Auto" });
            var data = e.ResultData.First();
            Console.WriteLine("key = {0}, value = {1}",data.Key, data.Value);
            Console.WriteLine("name = {0}, id = {1}", e.Name, e.Id);
            return resultData;
        }
    }
    class Program
    {       
        static void Main(string[] args)
        {
            var data = new GetSpecifyInfoEventArgs();
            data.Command = "DownloadSuccessResult";
            data.Id = System.Guid.NewGuid().ToString();
            data.Name = "Levi";

            var collection = new CKeyValuePairCollection();
            collection.Add(new CKeyValuePairInfo { Key = "Calc", Value = "1234" });
            data.ResultData = collection;
            data.Type = "ClientRequest";
            GetSpecifyInfo(null, data);
            Console.ReadKey();
        }
        public static void GetSpecifyInfo(object sender, GetSpecifyInfoEventArgs e)
        {
            if (e.Type == "ClientRequest")
            {
                try
                {
                    typeof(SpecifyInfoHandler).GetMethod(e.Command).Invoke(null, new object[] { e });
                }
                catch (Exception ex)
                {
                    string error = ex.ToString();
                    //Log
                }
            }
        }
         
    }
    public class GetSpecifyInfoEventArgs : ReportStatusEventArgs<CKeyValuePairCollection>
    { 
        public string Type { get; set; }
        public string Command { get; set; }
        public CKeyValuePairCollection ResultData { get; set; }
    }
    public class CKeyValuePairCollection : Collection<CKeyValuePairInfo>
    { 
        public CKeyValuePairInfo this[string key] { get { return this[key]; } }
        //public bool ContainKey(string key) 
    }
    public class CKeyValuePairInfo
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }
    public class ReportStatusEventArgs : EventArgs
    {
        public string Name { get; set; }
        public string Id { get; set; }
        
    }
    public class ReportStatusEventArgs<T> : ReportStatusEventArgs
    { 
        public T Data { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchTool
{
    public static class Util
    {
        public static IEnumerable<string> FilesName(string docPath, string ok, string ng)
        {
            if (string.IsNullOrEmpty(docPath))
            {
                throw new ArgumentNullException("document can not be null.");
            }
            var di = new DirectoryInfo(docPath);
            var subFolders = di.GetDirectories();
            if (subFolders.Length > 0)
            {
                foreach (var item in subFolders)
                {
                    var subs = FilesName(item.FullName, ok, ng);
                    foreach(var sub in subs)
                    {
                        yield return sub;
                    }
                }
            }

            string[] ngWords = ng.Split(' ');
            var files = di.GetFiles();
            foreach (var file in files)
            {
                var name = file.FullName;
                //文件名是否含有不想搜的词
                bool isContainNg = ngWords.ToList().Where(p => name.Contains(p)).Count() > 0 ? true : false;

                //文件名是否是指定后缀名
                bool isOkFile = name.Contains(ok);

                //非指定后缀名或者是不想搜的文件，则跳过
                bool isSkip = !isOkFile || isContainNg;

                if (isSkip)
                    continue;

                //其他的返回
                yield return name;
            }

        }
        public static int LineNum(string docPath, string key)
        {
            if (File.Exists(docPath))
            {
                int i = 1;
                string line;
                using (StreamReader sr = new StreamReader(docPath))
                {
                    while ((line = sr.ReadLine()) != null)
                    {
                        if (line.Contains(key))
                            return i;
                        i++;
                    }
                }
            }
            return 0;
        }
    }
}

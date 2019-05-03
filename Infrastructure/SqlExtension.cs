using System;
using System.IO;
using System.Linq;

namespace Infrastructure
{
    public static class SqlExtension
    {
        public static void RunSqlCripts()
        {
            using (var context = new MDContext())
            {
                try
                {
                    var path = AppDomain.CurrentDomain.BaseDirectory;
                    var files = Directory.GetFiles(Path.Combine(path, "SqlScripts"));
                    foreach (var file in files)
                    {
                        var sqlString = File.OpenText(file).ReadToEnd();
                        try
                        {
                            context.Database.SqlQuery<string>(sqlString).FirstOrDefault();
                        }
                        catch(Exception ex) { throw ex; }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}

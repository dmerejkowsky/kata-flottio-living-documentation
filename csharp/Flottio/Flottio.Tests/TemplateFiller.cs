using System.IO;

namespace Flottio.Tests
{
    class TemplateFiller
    {
        public static void CreateTargetFile(string content, string title, string templatePath, string targetFileName)
        {
            var template = ReadTemplate(templatePath);
            var text = Evaluate(template, title, content);
            Write(targetFileName, text);
        }

        private static void Write(string fileFullName, string content)
        {
            using (var streamWriter = new StreamWriter(fileFullName))
            {
                streamWriter.Write(content);
                streamWriter.Flush();
                streamWriter.Close();
            }
        }

        private static string Evaluate(string template, string title, string content)
        {
            return template.Replace("{0}", title).Replace("{1}", content);
        }

        private static string ReadTemplate(string templatePath)
        {
            using (var streamReader = new StreamReader(templatePath))
            {
                return streamReader.ReadToEnd();
            };
        }
    }
}

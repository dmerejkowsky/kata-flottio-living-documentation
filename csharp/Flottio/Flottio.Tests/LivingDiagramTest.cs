using DotNetGraph;
using DotNetGraph.Attributes;
using DotNetGraph.Node;
using DotNetGraph.SubGraph;
using Flottio.FuelCardMonitoring.Domain;
using NFluent;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Xunit;

namespace Flottio.Tests
{
    public class LivingDiagramTest
    {

        private DotGraph graph = new DotGraph("Hexagonal Architecture", true);
        [Fact]
        public void GenerateDiagram()
        {
            Assembly flottioAssembly = typeof(Basket).Assembly;

            String prefix = "Flottio.FuelCardMonitoring";
            IEnumerable<Type> allClasses = flottioAssembly.GetTypes();
            var topLevelClasses = allClasses.Where(classe => classe.Namespace.Contains(prefix));

            string domainPrefix = ".Domain";
            var domainClasses = topLevelClasses.Where(classe => classe.Namespace.Contains(prefix + domainPrefix));
            DotSubGraph domainGraph = CreateSubGraph(domainClasses, "Core Domain");
            graph.Elements.Add(domainGraph);

            var infraClasses = topLevelClasses.Where(classe => classe.Namespace.Contains(prefix) && !classe.Namespace.Contains(domainPrefix));
            var infraSubGraph = CreateSubGraph(infraClasses, "Infra");
            graph.Elements.Add(infraSubGraph);

            string content = CreateContent(graph);

            string templatePath = "./Ressources/viz-template.html";
            var template = ReadTemplate(templatePath);
            var title = "Living Diagram";
            var text = Evaluate(template, title, content);
            Write("livinggdiagram.html", text);

            //Check.That(compiledGraph).IsEqualTo("");

        }

        private string CreateContent(DotGraph graph)
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"# Class diagram {graph.Identifier}");
            stringBuilder.AppendLine("digraph G {");
            stringBuilder.AppendLine($"graph[labelloc = top, label =\"{graph.Identifier}\", fontname = \"Verdana\", fontsize = 12, rankdir = LR];");
            stringBuilder.AppendLine("node [fontname=\"Verdana\",fontsize=9,shape=record];");
            int idElement = 1;
            int idSubGraph = 0;
            foreach (var element in graph.Elements)
            {
                var subgraph = element as DotSubGraph;
                if (subgraph != null)
                {
                    stringBuilder.Append($"subgraph cluster_c{idSubGraph} ");
                    stringBuilder.AppendLine("{");

                    stringBuilder.AppendLine($"label = \"{subgraph.Identifier}\";");
                    foreach (var item in subgraph.Elements)
                    {
                        var node = item as DotNode;
                        if (node != null)
                        {
                            stringBuilder.AppendLine($"c{idElement} [label = \"{node.Identifier}\"]");
                            idElement++;
                        }
                    }
                    
                    stringBuilder.AppendLine("}");
                }
                idSubGraph++;
            }
            stringBuilder.AppendLine("}");
            return stringBuilder.ToString();
        }

        private void Write(string fileFullName, string content)
        {
            using (var streamWriter = new StreamWriter(fileFullName))
            {
                streamWriter.Write(content);
                streamWriter.Flush();
                streamWriter.Close();
            }
        }

        private string Evaluate(string template, string title, string content)
        {
            return template.Replace("{0}", title).Replace("{1}", content);
        }

        private string ReadTemplate(string templatePath)
        {
            using (var streamReader = new StreamReader(templatePath))
            {
                return streamReader.ReadToEnd();
            };
        }

        private static DotSubGraph CreateSubGraph(IEnumerable<Type> classes, string subGraphIdentifier)
        {
            DotSubGraph subGraph = new DotSubGraph(subGraphIdentifier);
            foreach (var topLevelClass in classes)
            {
                DotNetGraph.Core.IDotElement typeElement = new DotNetGraph.Node.DotNode(topLevelClass.Name);
                subGraph.Elements.Add(typeElement);
            }
            subGraph.Label = subGraphIdentifier;
            subGraph.Style = DotSubGraphStyle.Dashed;
            subGraph.Color = new DotColorAttribute(Color.Red);

            return subGraph;
        }
    }
}

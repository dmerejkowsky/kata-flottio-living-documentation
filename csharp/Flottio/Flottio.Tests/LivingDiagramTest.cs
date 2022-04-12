using DotNetGraph;
using DotNetGraph.Attributes;
using DotNetGraph.Edge;
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
            Dictionary<Type, int> elements = new Dictionary<Type, int>();
            var domainClasses = topLevelClasses.Where(classe => classe.Namespace.Contains(prefix + domainPrefix));
            DotSubGraph domainGraph = CreateSubGraph(domainClasses, "Core Domain", elements);
            graph.Elements.Add(domainGraph);

            var infraClasses = topLevelClasses.Where(classe => classe.Namespace.Contains(prefix) && !classe.Namespace.Contains(domainPrefix));
            var infraSubGraph = CreateSubGraph(infraClasses, "Infra", elements);
            graph.Elements.Add(infraSubGraph);

            foreach (var classe in topLevelClasses)
            {
                var fields = classe.GetRuntimeFields();
                foreach (var field in fields)
                {
                    if (topLevelClasses.Any(cl => field.FieldType == cl))
                    {
                        var edge = new DotEdge(elements[classe].ToString(), elements[field.FieldType].ToString());
                        edge.ArrowHead = new DotEdgeArrowHeadAttribute(DotEdgeArrowType.Open);
                        graph.Elements.Add(edge);
                    }
                }

                var interfaces = classe.GetInterfaces();
                foreach (var classInterface in interfaces)
                {
                    if (topLevelClasses.Any(cl => classInterface == cl))
                    {
                        var edge = new DotEdge(elements[classe].ToString(), elements[classInterface].ToString());
                        edge.ArrowHead = new DotEdgeArrowHeadAttribute(DotEdgeArrowType.Normal);
                        edge.Style = new DotEdgeStyleAttribute(DotEdgeStyle.Dashed);
                        graph.Elements.Add(edge);
                    }
                }
            }

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
            foreach (var element in graph.Elements)
            {
                var subgraph = element as DotSubGraph;
                if (subgraph != null)
                {
                    stringBuilder.Append($"subgraph cluster_c{subgraph.Identifier} ");
                    stringBuilder.AppendLine("{");

                    stringBuilder.AppendLine($"label = \"{subgraph.Label.Text}\";");
                    foreach (var item in subgraph.Elements)
                    {
                        var node = item as DotNode;
                        if (node != null)
                        {
                            stringBuilder.AppendLine($"{node.Identifier} [label = \"{node.Label.Text}\"]");
                        }
                    }

                    stringBuilder.AppendLine("}");
                }
                var edge = element as DotEdge;
                if (edge != null)
                {
                    stringBuilder.Append($"{(edge.Left as DotString).Value} -> {(edge.Right as DotString).Value} [");
                    if (edge.ArrowHead != null)
                    {
                        string arrow = edge.ArrowHead.ArrowType == DotEdgeArrowType.Normal
                            ? "onormal"
                            : edge.ArrowHead.ArrowType.ToString().ToLower();
                        stringBuilder.Append($"arrowhead={arrow},");
                    }
                    if(edge.ArrowTail != null)
                    {
                        stringBuilder.Append($"arrowtail={edge.ArrowTail.ArrowType.ToString().ToLower()},");
                    }
                    if (edge.Style != null)
                    {
                        stringBuilder.Append($"style={edge.Style.Style.ToString().ToLower()},");
                    }

                    stringBuilder.AppendLine("];");
                }
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

        int idElement = 0;
        private DotSubGraph CreateSubGraph(IEnumerable<Type> classes, string subGraphIdentifier, Dictionary<Type, int> elements)
        {
            DotSubGraph subGraph = new DotSubGraph(idElement.ToString());
            idElement++;
            foreach (var topLevelClass in classes)
            {
                var typeElement = new DotNode(idElement.ToString());
                typeElement.Label = topLevelClass.Name;
                subGraph.Elements.Add(typeElement);
                elements.Add(topLevelClass, idElement);
                idElement++;
            }

            subGraph.Label = subGraphIdentifier;
            subGraph.Style = DotSubGraphStyle.Dashed;
            subGraph.Color = new DotColorAttribute(Color.Red);

            return subGraph;
        }
    }
}

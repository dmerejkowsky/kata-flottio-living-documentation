using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Flottio.FuelCardMonitoring.Domain;
using NFluent;
using Xunit;
using Xunit.Abstractions;

namespace Flottio.Tests
{
    public class LivingGuidedTourTest
    {
        private readonly ITestOutputHelper _testOutputHelper;
        public LivingGuidedTourTest(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }
        
        private const string SEP = "\r\n";
		private const string CONTEXT_PREFIX = "Flottio.FuelCardMonitoring";
        private const string ANNOTATION_NAME = "Flottio.Annotations.GuidedTour";
        private const string REPO_LINKS_PREFIX = "https://github.com/iAmDorra/livingdocumentation-workshop";

        private readonly Dictionary<string, Tour> tours = new Dictionary<string, Tour>();
        
        private class Tour {
	        public SortedDictionary<int, string> Sites = new SortedDictionary<int, string>();
        
	        public string Put(int step, string describtion) {
		        Sites.Add(step, describtion);
		        return describtion;
	        }
        
	        public override string ToString() {
		        return Sites.ToString();
	        }
        }
        
        private class TourStep {
	        private string name;
	        private string description;
	        private int step;
        
	        public string Name() {
		        return name;
	        }
        
	        public string Description() {
		        return description;
	        }
        
	        public int Step() {
		        return step;
	        }
        
	        public TourStep(string name, string description, int step) {
		        this.name = name;
		        this.description = description;
		        this.step = step;
	        }
        
        }

        [Fact]
        public void test()
        {
            
            PrintAll();
            StringBuilder sb = new StringBuilder();
            foreach (string tourName in tours.Keys)
            {
	            sb.Append(WriteSightSeeingTour(tourName));
            }

            string targetFileName = "Quick_Developer_Tour.html";
            TemplateFiller.CreateTargetFile(
	            sb.ToString(), 
	            "Quick Developer Tour", 
	            "./Ressources/strapdown-template.html", 
	            targetFileName);

            Check.That(File.Exists(targetFileName)).IsTrue();
            Check.That(sb.ToString()).IsEqualTo(File.ReadAllText("./Ressources/content_approved.txt"));
        }

        private void PrintAll()
        {
	        var classes = typeof(Basket).Assembly.GetTypes();
	        foreach (var classe in classes.Where(cl => cl.Namespace.Contains(CONTEXT_PREFIX))) {
		        Process(classe);
	        }
        }

        private void Process(Type classe)
        {
	        string comment = BlockQuote(classe);
	        AddTourStep(
		        GetQuickDevTourStep(classe), 
		        classe.Name, 
		        classe.FullName, 
		        comment, 
		        0//classe.GetLineNumber()
		        );

	        if (classe.IsEnum) {
	        } else if (classe.IsInterface) {
	        } else {
		        foreach (var m in classe.GetMethods()) {
			        string name = m.Name;
			        string qName = classe.FullName;
			        string codeBlock = string.Empty; //Code(m.GetCodeBlock());
			        int lineNumber = 0; //m.GetLineNumber();
			        TourStep step = GetQuickDevTourStep(m.GetType());
			        AddTourStep(step, name, qName, codeBlock, lineNumber);
		        }
	        }
        }

        private TourStep GetQuickDevTourStep(Type classe)
        {
	        foreach (var guidedTour in classe.GetCustomAttributes<GuidedTourAttribute>())
	        {
		        return new TourStep(
				        guidedTour.Name.Replace("\"", ""),
				        guidedTour.Description.Replace("\"", ""),
				        guidedTour.Rank);
	        }
	        return null;
        }

        private string BlockQuote(Type classe)
        {
	        return classe.GetCustomAttribute<CommentsAttribute>()?.Comments;
        }

        private void AddTourStep(TourStep step, string name, string qName, string comment, int lineNumber)
        {
	        if (step != null) {
		        StringBuilder content = new StringBuilder();
		        content.Append(LinkSrcJava(name, qName, lineNumber));
		        content.Append(SEP);
		        if (step.Description() != null) {
			        content.Append(SEP);
			        content.Append("*" + step.Description().Trim() + "*");
		        }
		        content.Append(SEP);
		        if (comment != null) {
			        content.Append(SEP);
			        content.Append("> ");
			        content.Append(comment);
		        }
		        content.Append(SEP);

		        GetTourNamed(step.Name()).Put(step.Step(), content.ToString());
	        }
        }
        
        private string Link(string name, string url) {
	        return "[" + name + "](" + url + ")";
        }


        private string LinkSrcJava(string name, string qName, int lineNumber)
        {
	        return Link(name, REPO_LINKS_PREFIX + "/blob/master/csharp/Flottio/" + qName.Replace('.', '/') + ".cs#L" + lineNumber);
        }

        private Tour GetTourNamed(string name)
        {
	        if (tours.ContainsKey(name))
	        {
		        return tours[name];
	        }

	        var tour = new Tour();
	        tours.Add(name, tour);
	        return tour;
        }

        private string WriteSightSeeingTour(string tourName) {
	        
			StringBuilder sb = new StringBuilder();
			Tour tour = tours[tourName];
			int count = 1;
			foreach (string step in tour.Sites.Values) {
				sb.Append(SEP);
				sb.Append("## " + count + ". " + step);
				sb.Append(SEP);
				count++;
			}
			return sb.ToString();
        }
    }
}
using Sdl.Desktop.IntegrationApi;
using Sdl.Desktop.IntegrationApi.Extensions;
using Sdl.Desktop.IntegrationApi.Interfaces;
using Sdl.ProjectAutomation.Core;
using Sdl.ProjectAutomation.FileBased;
using Sdl.TranslationStudioAutomation.IntegrationApi;
using System;
using System.Data;
using System.Linq;

namespace StudioIntegrationApiSample
{
    [ViewPart(
       Id = "ProjectQuoteViewPart",
       Name = "Project Quote",
       Description = "Project Quote",
       Icon = "ProjectQuote_Icon")]
    [ViewPartLayout(Dock = DockType.Bottom, LocationByType = typeof(ProjectsController))]
    public class ProjectQuoteViewPartController : AbstractViewPartController
    {
        protected override IUIControl GetContentControl()
        {
            return _control.Value;
        }

        protected override void Initialize()
        {
            ProjectsController = SdlTradosStudio.Application.GetController<ProjectsController>();

            QuoteItems = new DataTable();
            _control.Value.Controller = this;

            ProjectsController.SelectedProjectsChanged += new EventHandler(projectsController_SelectedProjectsChanged);
        }

        private ProjectsController ProjectsController
        {
            get;
            set;
        }

        void projectsController_SelectedProjectsChanged(object sender, EventArgs e)
        {
            UpdateProjectQuote();
        }

        private readonly Lazy<ProjectQuoteViewPartControl> _control = new Lazy<ProjectQuoteViewPartControl>(() => new ProjectQuoteViewPartControl());

        public DataTable QuoteItems
        {
            get; private set;
        }

        public void UpdateProjectQuote()
        {
            QuoteItems.Clear();

            FileBasedProject project = ProjectsController.SelectedProjects.FirstOrDefault();
            if (project != null)
            {
                ProjectStatistics stats = project.GetProjectStatistics();

                QuoteItems.Clear();
                QuoteItems.Columns.Clear();

                QuoteItems.Columns.Add("Language", typeof(string));
                QuoteItems.Columns.Add("Perfect", typeof(double));
                QuoteItems.Columns.Add("Repetitions", typeof(double));
                QuoteItems.Columns.Add("InContextExact", typeof(double));
                QuoteItems.Columns.Add("Exact", typeof(double));

                FuzzyCountData[] fuzzy = stats.TargetLanguageStatistics[0].AnalysisStatistics.Fuzzy;
                for (int i = fuzzy.Length - 1; i >= 0; i--)
                {
                    AnalysisBand band = fuzzy[i].Band;
                    QuoteItems.Columns.Add(GetBandName(band), typeof(double));
                }

                QuoteItems.Columns.Add("New", typeof(double));
                QuoteItems.Columns.Add("Total", typeof(double));


                AddItemRows(stats);
            }
        }

        private string GetBandName(AnalysisBand band)
        {
            return string.Format("{0}%-{1}%", band.MinimumMatchValue, band.MaximumMatchValue);
        }

        private void AddItemRows(ProjectStatistics projectStats)
        {
            foreach (TargetLanguageStatistics languageStats in projectStats.TargetLanguageStatistics)
            {
                AnalysisStatistics stats = languageStats.AnalysisStatistics;

                string name = languageStats.TargetLanguage.DisplayName;

                DataRow row = CreateRow(stats, name);
                QuoteItems.Rows.Add(row);
            }

            QuoteItems.Rows.Add(CreateTotalsRow());
        }

        private DataRow CreateRow(AnalysisStatistics stats, string name)
        {
            DataRow row = QuoteItems.NewRow();
            row["Language"] = name;
            row["Perfect"] = GetPrice("Perfect", stats.Perfect);
            row["InContextExact"] = GetPrice("InContextExact", stats.InContextExact);
            row["Exact"] = GetPrice("Exact", stats.Exact);
            row["Repetitions"] = GetPrice("Repetitions", stats.Repetitions);

            FuzzyCountData[] fuzzy = stats.Fuzzy;
            int columnIndex = 5;
            for (int k = fuzzy.Length - 1; k >= 0; k--)
            {
                row[columnIndex] = GetPrice(fuzzy[k]);
                columnIndex++;
            }

            row["New"] = GetPrice("New", stats.New);
            row["Total"] = CalculateRowTotal(row);

            return row;
        }

        private object CalculateRowTotal(DataRow row)
        {
            object[] items = row.ItemArray;
            double total = 0;
            for (int i = 1; i < items.Length - 1; i++)
            {
                total += (double)items[i];
            }
            return total;
        }

        private DataRow CreateTotalsRow()
        {
            DataRow totalsRow = QuoteItems.NewRow();

            totalsRow["Language"] = "Total";

            for (int i = 1; i < QuoteItems.Columns.Count; i++)
            {
                double columnTotal = 0;
                foreach (DataRow itemRow in QuoteItems.Rows)
                {
                    columnTotal += (double)itemRow[i];
                }
                totalsRow[i] = columnTotal;
            }

            return totalsRow;
        }


        private double GetPrice(FuzzyCountData fuzzyCountData)
        {
            return GetPricePerWord(fuzzyCountData.Band) * fuzzyCountData.Words;
        }

        private double GetPrice(string category, CountData countData)
        {
            return GetPricePerWord(category) * countData.Words;
        }

        private double GetPricePerWord(string category)
        {
            switch (category)
            {
                case "Perfect":
                    return 0;
                case "InContextExact":
                    return 0.05;
                case "Exact":
                    return 0.05;
                case "Repetitions":
                    return 0.05;
                case "New":
                    return 0.3;
                default:
                    throw new ArgumentException("Unexpected category: " + category, nameof(category));
            }
        }

        private double GetPricePerWord(AnalysisBand band)
        {
            // fuzzy match pays a percentage of the price for a new translation
            return 0.05 + 0.3 * (100 - band.MinimumMatchValue) / 100.0;
        }
    }
}

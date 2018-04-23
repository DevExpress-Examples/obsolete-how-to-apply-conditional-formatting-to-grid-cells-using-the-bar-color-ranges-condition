using DevExpress.DashboardCommon;

namespace Grid_IconRangeCondition {
    public partial class Form1 : DevExpress.XtraEditors.XtraForm {
        public Form1() {
            InitializeComponent();
            Dashboard dashboard = new Dashboard(); dashboard.LoadFromXml(@"..\..\Data\Dashboard.xml");
            dashboardViewer1.Dashboard = dashboard;
            GridDashboardItem grid = (GridDashboardItem)dashboard.Items["gridDashboardItem1"];
            GridMeasureColumn extendedPrice = (GridMeasureColumn)grid.Columns[1];

            GridItemFormatRule rangeRule = new GridItemFormatRule(extendedPrice);
            FormatConditionColorRangeBar rangeBarCondition =
                new FormatConditionColorRangeBar(FormatConditionRangeSetPredefinedType.ColorsRedGreenBlue);
            rangeBarCondition.BarOptions.ShowBarOnly = true;
            rangeRule.Condition = rangeBarCondition;

            grid.FormatRules.AddRange(rangeRule);
        }

        private void button1_Click(object sender, System.EventArgs e) {
            GridDashboardItem grid = 
                (GridDashboardItem)dashboardViewer1.Dashboard.Items["gridDashboardItem1"];
            GridItemFormatRule rangeRule = grid.FormatRules[0];
            FormatConditionColorRangeBar rangeBarCondition = (FormatConditionColorRangeBar)rangeRule.Condition;
            RangeInfo range3 = rangeBarCondition.RangeSet[2];
            range3.Value = 50;
            range3.StyleSettings =
                new BarStyleSettings(FormatConditionAppearanceType.GradientGreen);

            RangeInfo range4 = new RangeInfo();
            range4.Value = 75;
            range4.StyleSettings =
                new BarStyleSettings(FormatConditionAppearanceType.GradientBlue);
            rangeBarCondition.RangeSet.Add(range4);

            rangeRule.Condition = rangeBarCondition;
        }
    }
}

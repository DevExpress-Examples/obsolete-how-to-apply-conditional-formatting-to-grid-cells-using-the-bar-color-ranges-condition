Imports DevExpress.DashboardCommon

Namespace Grid_IconRangeCondition
    Partial Public Class Form1
        Inherits DevExpress.XtraEditors.XtraForm

        Public Sub New()
            InitializeComponent()
            Dim dashboard As New Dashboard()
            dashboard.LoadFromXml("..\..\Data\Dashboard.xml")
            dashboardViewer1.Dashboard = dashboard
            Dim grid As GridDashboardItem = CType(dashboard.Items("gridDashboardItem1"), GridDashboardItem)
            Dim extendedPrice As GridMeasureColumn = CType(grid.Columns(1), GridMeasureColumn)

            Dim rangeRule As New GridItemFormatRule(extendedPrice)
            Dim rangeBarCondition As New  _
                FormatConditionColorRangeBar(FormatConditionRangeSetPredefinedType.ColorsRedGreenBlue)
            rangeBarCondition.BarOptions.ShowBarOnly = True
            rangeRule.Condition = rangeBarCondition

            grid.FormatRules.AddRange(rangeRule)
        End Sub

        Private Sub button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles button1.Click
            Dim grid As GridDashboardItem =
                CType(dashboardViewer1.Dashboard.Items("gridDashboardItem1"), GridDashboardItem)
            Dim rangeRule As GridItemFormatRule = grid.FormatRules(0)
            Dim rangeBarCondition As FormatConditionColorRangeBar =
                CType(rangeRule.Condition, FormatConditionColorRangeBar)
            Dim range3 As RangeInfo = rangeBarCondition.RangeSet(2)
            range3.Value = 50
            range3.StyleSettings = New BarStyleSettings(FormatConditionAppearanceType.GradientGreen)

            Dim range4 As New RangeInfo()
            range4.Value = 75
            range4.StyleSettings = New BarStyleSettings(FormatConditionAppearanceType.GradientBlue)
            rangeBarCondition.RangeSet.Add(range4)

            rangeRule.Condition = rangeBarCondition
        End Sub
    End Class
End Namespace

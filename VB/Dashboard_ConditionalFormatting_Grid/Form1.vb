Imports System
Imports DevExpress.DashboardCommon
Imports DevExpress.DashboardWin

Namespace Grid_IconRangeCondition
	Partial Public Class Form1
		Inherits DevExpress.XtraEditors.XtraForm

		Public Sub New()
			InitializeComponent()
			AddHandler dashboardViewer1.CustomizeDashboardTitle, AddressOf DashboardViewer1_CustomizeDashboardTitle
			Dim dashboard As New Dashboard()
			dashboard.LoadFromXml("..\..\Data\Dashboard.xml")
			dashboardViewer1.Dashboard = dashboard
			Dim grid As GridDashboardItem = CType(dashboard.Items("gridDashboardItem1"), GridDashboardItem)
			Dim extendedPrice As GridMeasureColumn = CType(grid.Columns(1), GridMeasureColumn)

			Dim rangeRule As New GridItemFormatRule(extendedPrice)
			Dim rangeBarCondition As New FormatConditionColorRangeBar(FormatConditionRangeSetPredefinedType.ColorsRedGreenBlue)
			rangeBarCondition.BarOptions.ShowBarOnly = True
			rangeRule.Condition = rangeBarCondition

			grid.FormatRules.AddRange(rangeRule)
		End Sub

		Private Sub DashboardViewer1_CustomizeDashboardTitle(ByVal sender As Object, ByVal e As CustomizeDashboardTitleEventArgs)
			Dim itemUpdate As New DashboardToolbarItem(Sub(args) UpdateFormatting()) With {.Caption = "Update Formatting"}
			e.Items.Add(itemUpdate)
		End Sub

		Private Sub UpdateFormatting()
			Dim grid As GridDashboardItem = CType(dashboardViewer1.Dashboard.Items("gridDashboardItem1"), GridDashboardItem)
			Dim rangeRule As GridItemFormatRule = grid.FormatRules(0)
			Dim rangeBarCondition As FormatConditionColorRangeBar = CType(rangeRule.Condition, FormatConditionColorRangeBar)
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

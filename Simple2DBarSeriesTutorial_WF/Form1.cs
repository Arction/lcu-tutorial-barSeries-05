// ------------------------------------------------------------------------------------------------------
// LightningChart® example code: 2D BarSeries Chart Demo.
//
// If you need any assistance, or notice error in this example code, please contact support@arction.com. 
//
// Permission to use this code in your application comes with LightningChart® license. 
//
// http://arction.com/ | support@arction.com | sales@arction.com
//
// © Arction Ltd 2009-2019. All rights reserved.  
// ------------------------------------------------------------------------------------------------------

using System.Drawing;
using System.Windows.Forms;

// Arction namespaces.
using Arction.WinForms.Charting;            // LightningChartUltimate and general types.
using Arction.WinForms.Charting.Axes;       // Axes for chart.
using Arction.WinForms.Charting.SeriesXY;   // Series for 2D chart.

namespace Simple2DBarSeriesTutorial_WF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // Create chart.
            var chart = new LightningChartUltimate();

            // Disable rendering before updating chart properties to improve performance
            // and to prevent unnecessary chart redrawing while changing multiple properties.
            chart.BeginUpdate();

            // Set chart control into parent container.
            chart.Parent = this; // Set form as parent.
            chart.Dock = DockStyle.Fill; // Maximize to parent client area.

            // Define variables for X- and Y-axis.
            var axisX = chart.ViewXY.XAxes[0];
            var axisY = chart.ViewXY.YAxes[0];

            // Set title options for X- and Y-axis.
            axisX.Title.Visible = false;
            axisY.Title.Text = "Temperature °C";

            // Set label angle for X-axis.
            axisX.LabelsAngle = 90;

            // LegendBox layout.
            chart.ViewXY.LegendBoxes[0].Position = LegendBoxPositionXY.SegmentTopRight;

            // Disable autoformating of labels.
            axisX.AutoFormatLabels = false;

            // Enable CustomAxisTicks.
            axisX.CustomTicksEnabled = true;

            // 1. Create a new BarSeries.
            var barSeries1 = new BarSeries(chart.ViewXY, axisX, axisY);
            
            // Add styling to created series.
            barSeries1.Fill.Color = Color.Orange;
            barSeries1.Fill.GradientFill = GradientFill.Solid;
            barSeries1.Title.Text = "2017";
            barSeries1.BarThickness = 10;

            // 2. Generate data as BarSeriesValues to represent average monthly temperatures.
            BarSeriesValue[] bars1 = new BarSeriesValue[]
            {
                new BarSeriesValue(0, -5, null),
                new BarSeriesValue(1, -6, null),
                new BarSeriesValue(2, -2, null),
                new BarSeriesValue(3, 4, null),
                new BarSeriesValue(4, 10, null),
                new BarSeriesValue(5, 14, null),
                new BarSeriesValue(6, 17, null),
                new BarSeriesValue(7, 15, null),
                new BarSeriesValue(8, 10, null),
                new BarSeriesValue(9, 6, null),
                new BarSeriesValue(10, -2, null),
                new BarSeriesValue(11, -4, null)
            };

            // Add BarSeriesValues to BarSeries.
            barSeries1.Values = bars1;

            // 3. Add BarSeries to chart.
            chart.ViewXY.BarSeries.Add(barSeries1);

            // 4. Create second BarSeries.
            var barSeries2 = new BarSeries();
            
            // Add styling to created series.
            barSeries2.Fill.Color = Color.LightGray;
            barSeries2.Fill.GradientFill = GradientFill.Solid;
            barSeries2.Title.Text = "2018";
            barSeries2.BarThickness = 10;

            // 5. Generate an other set of data as BarSeriesValues to represent average monthly temperatures.
            BarSeriesValue[] bars2 = new BarSeriesValue[]
            {
                new BarSeriesValue(0, -1, null),
                new BarSeriesValue(1, -1, null),
                new BarSeriesValue(2, 2, null),
                new BarSeriesValue(3, 8, null),
                new BarSeriesValue(4, 15, null),
                new BarSeriesValue(5, 19, null),
                new BarSeriesValue(6, 21, null),
                new BarSeriesValue(7, 19, null),
                new BarSeriesValue(8, 14, null),
                new BarSeriesValue(9, 8, null),
                new BarSeriesValue(10, 2, null),
                new BarSeriesValue(11, -7, null)
            };

            // Add BarSeriesValues to BarSeries.
            barSeries2.Values = bars2;

            // 6. Add BarSeries to chart.
            chart.ViewXY.BarSeries.Add(barSeries2);

            // 7. Configure bar view layout.
            chart.ViewXY.BarViewOptions.Grouping = BarsGrouping.ByLocation;

            // 8. Create list of months.
            string[] months = new string[]
            {
                "January",
                "February",
                "March",
                "April",
                "May",
                "June",
                "July",
                "August",
                "September",
                "October",
                "November",
                "December"
            };

            // 9. Create CustomAxisTicks to display months as X-axis values.
            for (int i = 0; i < months.Length; i++)
            {
                CustomAxisTick tick = new CustomAxisTick(axisX);
                tick.AxisValue = i;
                tick.LabelText = months[i];
                tick.Color = Color.FromArgb(35, 255, 255, 255);

                axisX.CustomTicks.Add(tick);
            }

            // Notify chart about set custom axis ticks.
            axisX.InvalidateCustomTicks();

            // Auto-scale X- and Y-axes.
            chart.ViewXY.ZoomToFit();

            #region Hidden polishing
            // Customize chart.
            CustomizeChart(chart);
            #endregion

            // Call EndUpdate to enable rendering again.
            chart.EndUpdate();
        }

        #region Hidden polishing
        void CustomizeChart(LightningChartUltimate chart)
        {
            chart.Background.Color = Color.FromArgb(255, 30, 30, 30);
            chart.Background.GradientFill = GradientFill.Solid;
            chart.ViewXY.GraphBackground.Color = Color.FromArgb(255, 20, 20, 20);
            chart.ViewXY.GraphBackground.GradientFill = GradientFill.Solid;
            chart.Title.Color = Color.FromArgb(255, 249, 202, 3);
            chart.Title.MouseHighlight = MouseOverHighlight.None;

            foreach (var yAxis in chart.ViewXY.YAxes)
            {
                yAxis.Title.Color = Color.FromArgb(255, 249, 202, 3);
                yAxis.Title.MouseHighlight = MouseOverHighlight.None;
                yAxis.MajorGrid.Color = Color.FromArgb(35, 255, 255, 255);
                yAxis.MajorGrid.Pattern = LinePattern.Solid;
                yAxis.MinorDivTickStyle.Visible = false;
            }

            foreach (var xAxis in chart.ViewXY.XAxes)
            {
                xAxis.Title.Color = Color.FromArgb(255, 249, 202, 3);
                xAxis.Title.MouseHighlight = MouseOverHighlight.None;
                xAxis.MajorGrid.Color = Color.FromArgb(35, 255, 255, 255);
                xAxis.MajorGrid.Pattern = LinePattern.Solid;
                xAxis.MinorDivTickStyle.Visible = false;
                xAxis.ValueType = AxisValueType.Number;
            }
        }
        #endregion
    }
}

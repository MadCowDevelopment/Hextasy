using System;
using System.Windows;
using System.Windows.Controls;

namespace Hextasy.Framework
{
    public class HexGrid : Panel
    {
        #region Fields

        public static readonly DependencyProperty ColumnsProperty = 
            DependencyProperty.Register("Columns", typeof(int), typeof(HexGrid),
                new FrameworkPropertyMetadata(1, FrameworkPropertyMetadataOptions.AffectsMeasure));

        #endregion Fields

        #region Public Properties

        public int Columns
        {
            get { return (int)GetValue(ColumnsProperty); }
            set { SetValue(ColumnsProperty, value); }
        }

        #endregion Public Properties

        #region Protected Methods

        protected override Size ArrangeOverride(Size arrangeSize)
        {
            var rows = CalculateRequiredRows();
            var measurements = CalculateMeasurements(arrangeSize, rows);

            for (var i = 0; i < InternalChildren.Count; i++)
            {
                var row = i / Columns;
                var col = i % Columns;

                var left = col * measurements.CellSize.Width;
                var top = row * measurements.CellSize.Height;
                var isUnevenCol = (col % 2 != 0);
                if (isUnevenCol) top += (0.5 * measurements.CellSize.Height);

                InternalChildren[i].Arrange(new Rect(new Point(left, top), measurements.ChildSize));
            }

            return arrangeSize;
        }

        protected override Size MeasureOverride(Size constraint)
        {
            var rows = CalculateRequiredRows();
            var measurements = CalculateMeasurements(constraint, rows);

            foreach (FrameworkElement child in InternalChildren)
            {
                child.Measure(measurements.ChildSize);
            }

            var totalHeight = rows * measurements.CellSize.Height;
            if (Columns > 1) totalHeight += (0.5 * measurements.CellSize.Height);
            var totalWidth = (Columns * measurements.CellSize.Width) + (0.5 * measurements.ChildSize.Width / 2);

            return new Size(totalWidth, totalHeight);
        }

        #endregion Protected Methods

        #region Private Methods

        private Measurements CalculateMeasurements(Size constraint, int rows)
        {
            var colWidth = constraint.Width / (Columns + 0.33);
            var rowHeight = constraint.Height / (rows + 0.5);
            double width;
            double height;
            if (colWidth / 0.75 / 2 * Math.Sqrt(3.0) < rowHeight)
            {
                width = colWidth / 0.75;
                height = width / 2 * Math.Sqrt(3.0);
                rowHeight = height;
            }
            else
            {
                height = rowHeight;
                width = height * 2 / Math.Sqrt(3.0);
                colWidth = width * 0.75;
            }

            return new Measurements(new Size(width, height), new Size(colWidth, rowHeight));
        }

        private int CalculateRequiredRows()
        {
            return InternalChildren.Count == 0
                ? 0
                : Math.Max(1, (int) Math.Round((double) InternalChildren.Count/Columns));
        }

        #endregion Private Methods

        #region Nested Types

        private class Measurements
        {
            #region Constructors

            public Measurements(Size childSize, Size cellSize)
            {
                ChildSize = childSize;
                CellSize = cellSize;
            }

            #endregion Constructors

            #region Public Properties

            public Size CellSize
            {
                get; private set;
            }

            public Size ChildSize
            {
                get; private set;
            }

            #endregion Public Properties
        }

        #endregion Nested Types
    }
}
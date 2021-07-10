using System;

namespace ScheduleBusinessLogic.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
	public class ColumnAttribute : Attribute
    {
        public ColumnAttribute(string title = "", 
            bool visible = true, 
            int width = 0, 
            GridViewAutoSize gridViewAutoSize = GridViewAutoSize.None, 
            bool readOnly = true,
            string format = "")
        {
            Title = title;
            Visible = visible;
            Width = width;
            GridViewAutoSize = gridViewAutoSize;
            ReadOnly = readOnly;
            Format = format;
        }

        public string Title { get; private set; }

        public bool Visible { get; private set; }

        public int Width { get; private set; }

        public GridViewAutoSize GridViewAutoSize { get; private set; }

        public bool ReadOnly { get; private set; }

        public string Format { get; private set; }
    }
}
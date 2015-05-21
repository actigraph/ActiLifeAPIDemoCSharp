using System;
using System.Globalization;

namespace ActiLifeAPILibrary.Models.Actions
{
    /// <summary> Global date/time filters to use in data scoring. </summary>
    public class ScoringFilter
    {
        /// <summary>
        /// The types of global date/time filters.
        /// </summary>
        public enum FilterType
        {
            /// <summary> Applies to every day of data. </summary>
            AllDays,

            /// <summary>
            /// 
            /// </summary>
            Weekdays,
            
            /// <summary>
            /// 
            /// </summary>
            Weekends,
            
            /// <summary>
            /// 
            /// </summary>
            DayOfTheWeek,
            
            /// <summary>
            /// 
            /// </summary>
            SpecificDate,
            
            /// <summary>
            /// 
            /// </summary>
            DayRange,
            
            /// <summary>
            /// 
            /// </summary>
            DateRange,

            /// <summary>
            /// 
            /// </summary>
            SpecificTime
        };

        /// <summary> The type of global date/time filter. </summary>
        public FilterType Type { get; set; }

        /// <summary> The name for this global date/time filter. </summary>
        public string Name { get; set; }

        /// <summary> If set to true, this filter will be used. If false, it won't be used. </summary>
        public bool Use { get; set; }
        
        /// <summary> The start time of the filter (only uses the TimeOfDay property of this value). </summary>
        public DateTime StartTime { get; set; }

        /// <summary> The stop time of the filter (only uses the TimeOfDay property of this value). </summary>
        public DateTime StopTime { get; set; }

        /// <summary> day of the week number.  0 is Sunday, 1 is Monday ... 6 is Saturday </summary>
        public int DayOfTheWeek { get; set; }

        /// <summary> If using the DayRange filter, set this for the start day to the day of the week number. 0 is Sunday, 1 is Monday ... 6 is Saturday </summary>
        public int DayRangeStart { get; set; }

        /// <summary> If using the DayRange filter, set this for the end day to the day of the week number. 0 is Sunday, 1 is Monday ... 6 is Saturday </summary>
        public int DayRangeEnd { get; set; }
        
        /// <summary> If using the SpecificDate filter, set this for the date to use. It ignores any Time portion of the DateTime. </summary>
        public DateTime SpecificDate { get; set; }

        /// <summary> If using the DateRange filter, set this for the start date to use. It ignores any Time portion of the DateTime. </summary>
        public DateTime DateRangeStart { get; set; }

        /// <summary> If using the DateRange filter, set this for the end date to use. It ignores any Time portion of the DateTime. </summary>
        public DateTime DateRangeEnd { get; set; }

        /// <summary> Initialize a ScoringFilter. Use is immediately set to FALSE. </summary>
        public ScoringFilter()
        {
            Use = false;
        }

        /// <summary> Copy constructor for a ScoringFilter. </summary>
        /// <param name="sf">The filter you want to duplicate.</param>
        public ScoringFilter(ScoringFilter sf)
        {
            Type = sf.Type;
            Name = sf.Name;
            Use = sf.Use;
            StartTime = sf.StartTime;
            StopTime = sf.StopTime;
            DayOfTheWeek = sf.DayOfTheWeek;
            DayRangeEnd = sf.DayRangeEnd;
            DayRangeStart = sf.DayRangeStart;
            SpecificDate = sf.SpecificDate;
            DateRangeStart = sf.DateRangeStart;
            DateRangeEnd = sf.DateRangeEnd;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof(ScoringFilter)) return false;
            return Equals((ScoringFilter)obj);
        }

        /// <summary> Equality checker for global date/time filters. </summary>
        /// <param name="other">The filter to evaluate.</param>
        /// <returns>True if they match. The USE property is not evaluated.</returns>
        public bool Equals(ScoringFilter other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(other.Type, Type) && Equals(other.Name, Name) && other.StartTime.Equals(StartTime) &&
                   other.StopTime.Equals(StopTime) && other.DayOfTheWeek == DayOfTheWeek &&
                   other.SpecificDate.Equals(SpecificDate);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = Type.GetHashCode();
                result = (result * 397) ^ (Name != null ? Name.GetHashCode() : 0);
                result = (result * 397) ^ StartTime.TimeOfDay.GetHashCode();
                result = (result * 397) ^ StopTime.TimeOfDay.GetHashCode();
                result = (result * 397) ^ DayOfTheWeek;
                result = (result * 397) ^ SpecificDate.Date.GetHashCode();
                return result;
            }
        }

        public override string ToString()
        {
            return string.Format("{0} - {1} - {2:t} - {3:t}", Name, GetTitleOfDataScoringDateFilter(), StartTime, StopTime);
        }

        /// <summary> Get a prettier title for the global date/time filter. </summary>
        /// <returns>A cleaner title.</returns>
        public string GetTitleOfDataScoringDateFilter()
        {
            var dayNames = CultureInfo.CurrentCulture.DateTimeFormat.DayNames;
            string title = "";
            switch (Type)
            {
                case FilterType.AllDays:
                    title = "All Days";
                    break;
                case FilterType.Weekdays:
                    title = "Weekdays";
                    break;
                case FilterType.Weekends:
                    title = "Weekends";
                    break;
                case FilterType.DayOfTheWeek:
                    title = dayNames[DayOfTheWeek];
                    break;
                case FilterType.SpecificDate:
                    title = SpecificDate.ToShortDateString();
                    break;
                case FilterType.DayRange:
                    title = string.Format("{0} - {1}", dayNames[DayRangeStart], dayNames[DayRangeEnd]);
                    break;
                case FilterType.DateRange:
                    title = string.Format("{0} - {1}", DateRangeStart.ToShortDateString(), DateRangeEnd.ToShortDateString());
                    break;
            }

            return title;
        }
    }
}
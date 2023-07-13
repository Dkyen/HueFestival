using System;
namespace HueFestival.ViewModel
{
        public class EventCategoryViewModel
        {
            public int EventCategoryId { get; set; }
            public string? EventName { get; set; }
            public string? Content { get; set; }
        }

        public class EventCategoryViewModel_Add
        {
            public string? EventName { get; set; }
            public string? Content { get; set; }
        }
 }



using System;
using System.ComponentModel.DataAnnotations;

namespace HueFestival.ViewModel
{
	public class ProgramViewModel
	{

        public int ProgramId { get; set; }

        public string? ProgramName { get; set; }
    }
    public class ProgramViewModel_Add
    {
       
        public string? ProgramName { get; set; }

        public string? Content { get; set; }

        public int TypeProgram { get; set; }

        public int Type_inoff { get; set; }

        public double Price { get; set; }
    }

    public class ProgramViewModel_Details
    {
        public int ProgramId { get; set; }

        public string? ProgramName { get; set; }

        public string? Content { get; set; }

        public int TypeProgram { get; set; }
        
        public int Type_inoff { get; set; }
        
        public double Price { get; set; }

        public List<EventViewModel>? ListEvent { get; set; }
    }


}


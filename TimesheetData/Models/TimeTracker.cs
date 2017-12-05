using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimesheetData.Models
{
	public class TimeTracker : CommonBaseModel
	{
		[ForeignKey("Projects")]
		public long ProjectID { get; set; }
		[ForeignKey("EmpUsers")]
		public long EmpID { get; set; }
		public int WeekofTheYear { get; set; }
		public string FromTodate { get; set; }
		public string TimeSheetStatus { get; set; } //D-Draft,S-Subbmit(and sent for approval),RS Re-Subbmit, R-Reject
		[ForeignKey("ApprovalUsers")]
		public long ApprovalID { get; set; }
		public virtual Projects Projects { get; set; }
		public virtual Users EmpUsers { get; set; }
		public virtual Users ApprovalUsers { get; set; }


	}

	public class TimeTrackerDetail : CommonBaseModel
	{
		[ForeignKey("TimeTracker")]
		public long TimeTrackerID { get; set; }		
		public decimal Hours { get; set; }
		public DateTime? TrackingDate { get; set; }
		public bool? IsActive { get; set; }
		public virtual TimeTracker TimeTracker { get; set; }

	}
}

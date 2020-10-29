using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gamal.ViewModel
{
	public class BookingBoardViewModel
	{
		public string SessionDescription { get; set; }
		public string ClassRoom { get; set; }
		public DateTime ExamDate { get; set; }
		public string ExamTime { get; set; }
		public string ExamName { get; set; }
		public List<Student> Students { get; set; }
	}
		
	public class Student
	{
		public String Name { get; set; }
		public string SerialNumber { get; set; }	
	}
}

using System;
using System.Collections.Generic;
using Syncfusion.SfSchedule.XForms;
using Xamarin.Forms;

namespace MonthAppointment_Rendering
{
	public class ScheduleViewModel
	{
		public ScheduleAppointmentCollection ListOfMeeting { get; set; }
		List<string> currentDayMeetings;
		List<Color> color_collection;

		public ScheduleViewModel()
		{
			ListOfMeeting = new ScheduleAppointmentCollection();
			InitializeDataForBookings();
			BookingAppointments();
		}

		#region BookingAppointments

		private void BookingAppointments()
		{
			Random randomTime = new Random();
			List<Point> randomTimeCollection = GettingTimeRanges();

			DateTime date;
			DateTime DateFrom = DateTime.Now.AddDays(-10);
			DateTime DateTo = DateTime.Now.AddDays(10);
			DateTime dateRangeStart = DateTime.Now.AddDays(-3);
			DateTime dateRangeEnd = DateTime.Now.AddDays(3);

			for (date = DateFrom; date < DateTo; date = date.AddDays(1))
			{
				if ((DateTime.Compare(date, dateRangeStart) > 0) && (DateTime.Compare(date, dateRangeEnd) < 0))
				{
					for (int AdditionalAppointmentIndex = 0; AdditionalAppointmentIndex < 3; AdditionalAppointmentIndex++)
					{
						ScheduleAppointment meeting = new ScheduleAppointment();
						int hour = (randomTime.Next((int)randomTimeCollection[AdditionalAppointmentIndex].X, (int)randomTimeCollection[AdditionalAppointmentIndex].Y));
						meeting.StartTime = new DateTime(date.Year, date.Month, date.Day, hour, 0, 0);
						meeting.EndTime = (meeting.StartTime.AddHours(1));
						meeting.Subject = currentDayMeetings[randomTime.Next(9)];
						meeting.Color = color_collection[randomTime.Next(9)];
						ListOfMeeting.Add(meeting);
					}
				}
				else
				{
					ScheduleAppointment meeting = new ScheduleAppointment();
					meeting.StartTime = new DateTime(date.Year, date.Month, date.Day, randomTime.Next(9, 11), 0, 0);
					meeting.EndTime = (meeting.StartTime.AddHours(1));
					meeting.Subject = currentDayMeetings[randomTime.Next(9)];
					meeting.Color = color_collection[randomTime.Next(9)];
					ListOfMeeting.Add(meeting);
				}
			}
		}

		#endregion BookingAppointments

		#region GettingTimeRanges

		private List<Point> GettingTimeRanges()
		{
			List<Point> randomTimeCollection = new List<Point>();
			randomTimeCollection.Add(new Point(9, 11));
			randomTimeCollection.Add(new Point(12, 14));
			randomTimeCollection.Add(new Point(15, 17));

			return randomTimeCollection;
		}

		#endregion GettingTimeRanges

		#region InitializeDataForBookings

		private void InitializeDataForBookings()
		{
			currentDayMeetings = new List<string>();
			currentDayMeetings.Add("General Meeting");
			currentDayMeetings.Add("Plan Execution");
			currentDayMeetings.Add("Project Plan");
			currentDayMeetings.Add("Consulting");
			currentDayMeetings.Add("Performance Check");
			currentDayMeetings.Add("Yoga Therapy");
			currentDayMeetings.Add("Plan Execution");
			currentDayMeetings.Add("Project Plan");
			currentDayMeetings.Add("Consulting");
			currentDayMeetings.Add("Performance Check");

			color_collection = new List<Color>();
			color_collection.Add(Color.FromHex("#FF339933"));
			color_collection.Add(Color.FromHex("#FF00ABA9"));
			color_collection.Add(Color.FromHex("#FFE671B8"));
			color_collection.Add(Color.FromHex("#FF1BA1E2"));
			color_collection.Add(Color.FromHex("#FFD80073"));
			color_collection.Add(Color.FromHex("#FFA2C139"));
			color_collection.Add(Color.FromHex("#FFA2C139"));
			color_collection.Add(Color.FromHex("#FFD80073"));
			color_collection.Add(Color.FromHex("#FF339933"));
			color_collection.Add(Color.FromHex("#FFE671B8"));
			color_collection.Add(Color.FromHex("#FF00ABA9"));

		}

		#endregion InitializeDataForBookings
	}
}


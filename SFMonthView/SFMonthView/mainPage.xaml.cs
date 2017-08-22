using MonthAppointment_Rendering;
using Syncfusion.SfSchedule.XForms;
using Xamarin.Forms;

namespace SFMonthView
{
    public partial class mainPage : ContentPage
    {
        public mainPage()
        {
            InitializeComponent();
            var schedule = new SfSchedule
            {
                ScheduleView = ScheduleView.MonthView,
                ShowAppointmentsInline = true
            };

            var viewModel = new ScheduleViewModel();
            schedule.DataSource = viewModel.ListOfMeeting;

            Content = schedule;
        }
    }
}

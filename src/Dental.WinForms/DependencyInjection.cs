using Dental.Domain.Views.Appointment;
using Dental.WinForms.Abstractions;
using Dental.WinForms.Factories;
using Dental.WinForms.Forms;
using Dental.WinForms.Views;
using Microsoft.Extensions.DependencyInjection;
using VisitsView = Dental.WinForms.Views.VisitsView;

namespace Dental.WinForms;

public static class DependencyInjection
{
    extension(IServiceCollection services)
    {
        public IServiceCollection AddWinForms()
        {
            services.AddTransient<IFormFactory, FormFactory>();
            services.AddForms();
            services.AddViews();

            return services;
        }

        private IServiceCollection AddForms()
        {
            services.AddTransient<frmMain>();
            services.AddTransient<frmAddUpdateVisit>();
            services.AddTransient<frmAddEditTreatment>();
            services.AddTransient<frmAddEditAppointment>();
            services.AddTransient<frmAddEditPatient>();

            return services;
        }

        private IServiceCollection AddViews()
        {
            services.AddTransient<MainMenuView>();
            services.AddTransient<VisitsView>();
            services.AddTransient<PatientsView>();
            services.AddTransient<AppointmentInfo>();
            services.AddTransient<AppointmentsView>();

            return services;
        }
    }
}
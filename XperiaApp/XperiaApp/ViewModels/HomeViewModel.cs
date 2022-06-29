using System;
using System.Collections.Generic;
using System.Text;

namespace XperiaApp.ViewModels
{
    public class HomeViewModel
    {
        public HomeViewModel()
        {
            Services = GetServices();
        }
        public List<Service> Services { get; set; }
        private List<Service> GetServices()
        {
            return new List<Service>
            {
                new Service { Title = "Hair Service", Image ="barber_01", Description = "Get Your Desire Hair Service Here" },
                new Service { Title = "MakeUp Service", Image ="barber_all2", Description = "Get Your Desire MakeUp Service Here" },
            };
        }

    }
    public class Service
    {
        public string Title { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
    }
}
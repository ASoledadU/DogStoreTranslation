using System.Collections.Generic;

namespace VSC
{
    public class DogSpa
    {
        public Dictionary<string, Service> Services { get; set; }

        public DogSpa(List<Service> services)
        {
            Services = new Dictionary<string, Service>();
            foreach (var service in services){
                Services.Add(service.Name, service);
            }
        }

        public bool ProvidesService(string serviceName)
        {
            return FindService(serviceName) != null;
        }
        public Service FindService(string serviceName)
        {
            return Services.GetValueOrDefault(serviceName, null);
        }
    }
}

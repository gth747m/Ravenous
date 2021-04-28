using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using Ravenous.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ravenous.Pages
{
    public partial class MeasurementsPage : ComponentBase
    {
        [Inject]
        public RavenousContext Context { get; set; }
        [Inject]
        public NavigationManager Navigation { get; set; }
        public List<Measurement> Measurements { get; set; }

        protected override void OnInitialized()
        {
            Measurements = Context.Measurement
                .AsNoTracking()
                .OrderBy(i => i.Name)
                .ToList();
        }
        
        public void OnMeasurementClick(int id)
        {
            Navigation.NavigateTo(string.Format("/measurements/edit/{0}", id));
        }

        public void OnAddMeasurementClick()
        {
            Navigation.NavigateTo("/measurements/add");
        }
    }
}
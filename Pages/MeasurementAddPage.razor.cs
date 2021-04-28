using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using Ravenous.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ravenous.Pages
{
    public partial class MeasurementAddPage : ComponentBase
    {
        [Inject]
        public RavenousContext Context { get; set; }
        [Inject]
        public NavigationManager Navigation { get; set; }
        [Parameter]
        public int Id { get; set; }
        public Measurement Measurement { get; set; }

        protected override void OnInitialized()
        {
            Measurement = new Measurement();
        }

        public async Task OnValidSumbit()
        {
            Context.Measurement.Add(Measurement);
            await Context.SaveChangesAsync();
            NavBack();
        }

        public void OnCancel()
        {
            NavBack();
        }

        public void NavBack()
        {
            Navigation.NavigateTo("/measurements");
        }
    }
}

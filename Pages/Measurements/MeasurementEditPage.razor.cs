using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using Ravenous.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ravenous.Pages.Measurements
{
    public partial class MeasurementEditPage : ComponentBase
    {
        [Inject]
        public RavenousContext Context { get; set; }
        [Inject]
        public NavigationManager Navigation { get; set; }
        [Parameter]
        public int Id { get; set; }
        public Measurement Measurement { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Measurement = await Context.Measurement
                .Where(i => i.MeasurementId == Id)
                .FirstOrDefaultAsync();
        }

        public async Task OnValidSumbit()
        {
            await Context.SaveChangesAsync();
            NavBack();
        }

        public async Task OnDelete()
        {
            Context.Measurement.Remove(Measurement);
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

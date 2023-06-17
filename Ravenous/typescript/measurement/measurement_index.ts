namespace Measurement {
    /* 
     * Redirect from table row click to the measurement details page
     */
    function bindMeasurementRowClick(row: HTMLTableRowElement) {
        const measurementId: string | null = row.getAttribute("data-measurement-id");
        if (measurementId) {
            window.location.href = window.origin + "/Measurements/Details?id=" + measurementId;
        }
    }

    /**
     * Bind on click for each measurement row 
     */
    const measurementRows: Element[] = Array.from(document.getElementsByClassName("measurement-row"));
    measurementRows.forEach((row: Element) => {
        row.addEventListener("click", function () { bindMeasurementRowClick(row as HTMLTableRowElement); });
    });
}
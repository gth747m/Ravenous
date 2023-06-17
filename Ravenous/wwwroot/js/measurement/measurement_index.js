"use strict";
var Measurement;
(function (Measurement) {
    /*
     * Redirect from table row click to the measurement details page
     */
    function bindMeasurementRowClick(row) {
        const measurementId = row.getAttribute("data-measurement-id");
        if (measurementId) {
            window.location.href = window.origin + "/Measurements/Details?id=" + measurementId;
        }
    }
    /**
     * Bind on click for each measurement row
     */
    const measurementRows = Array.from(document.getElementsByClassName("measurement-row"));
    measurementRows.forEach((row) => {
        row.addEventListener("click", function () { bindMeasurementRowClick(row); });
    });
})(Measurement || (Measurement = {}));
//# sourceMappingURL=measurement_index.js.map
"use strict";
var RecipeDetails;
(function (RecipeDetails) {
    /*
     * Toggle checkboxes on row click
     */
    function bindCheckboxRowClick(row) {
        const inputs = Array.from(row.getElementsByTagName("input"));
        inputs.forEach((element) => {
            const input = element;
            if (input.type == "checkbox") {
                input.checked = !input.checked;
            }
        });
    }
    /**
     * Bind on click for each checkbox row
     */
    const checkboxRows = Array.from(document.getElementsByClassName("checkbox-row"));
    checkboxRows.forEach((row) => {
        row.addEventListener("click", function () { bindCheckboxRowClick(row); });
    });
})(RecipeDetails || (RecipeDetails = {}));
//# sourceMappingURL=recipe_details.js.map
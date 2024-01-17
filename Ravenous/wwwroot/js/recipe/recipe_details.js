"use strict";
var RecipeDetails;
(function (RecipeDetails) {
    /**
     * Bind on click for each checkbox row
     */
    const checkboxRows = Array.from(document.getElementsByClassName("checkbox-row"));
    checkboxRows.forEach((row) => {
        row.addEventListener("click", function (event) {
            // If they didn't click on the checkbox itself
            if (event.target.tagName !== "INPUT") {
                // Get the checkbox
                const inputs = Array.from(row.getElementsByTagName("INPUT"));
                inputs.forEach((element) => {
                    const input = element;
                    // Check it
                    if (input.type == "checkbox") {
                        input.checked = !input.checked;
                    }
                });
            }
        });
    });
})(RecipeDetails || (RecipeDetails = {}));
//# sourceMappingURL=recipe_details.js.map
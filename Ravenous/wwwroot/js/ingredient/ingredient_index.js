"use strict";
var Ingredient;
(function (Ingredient) {
    /*
     * Redirect from table row click to the ingredient details page
     */
    function bindIngredientRowClick(row) {
        const ingredientId = row.getAttribute("data-ingredient-id");
        if (ingredientId) {
            window.location.href = window.origin + "/Ingredients/Details?id=" + ingredientId;
        }
    }
    /**
     * Bind on click for each ingredient row
     */
    const ingredientRows = Array.from(document.getElementsByClassName("ingredient-row"));
    ingredientRows.forEach((row) => {
        row.addEventListener("click", function () { bindIngredientRowClick(row); });
    });
})(Ingredient || (Ingredient = {}));
//# sourceMappingURL=ingredient_index.js.map
"use strict";
var Recipe;
(function (Recipe) {
    /*
     * Redirect from table row click to the recipe details page
     */
    function bindRecipeRowClick(row) {
        const recipeId = row.getAttribute("data-recipe-id");
        if (recipeId) {
            window.location.href = window.origin + "/Recipes/Details?id=" + recipeId;
        }
    }
    /**
     * Bind on click for each recipe row
     */
    const recipeRows = Array.from(document.getElementsByClassName("recipe-row"));
    recipeRows.forEach((row) => {
        row.addEventListener("click", function () { bindRecipeRowClick(row); });
    });
})(Recipe || (Recipe = {}));
//# sourceMappingURL=recipe_index.js.map
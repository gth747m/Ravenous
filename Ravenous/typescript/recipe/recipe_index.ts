namespace Recipe {
    /* 
     * Redirect from table row click to the recipe details page
     */
    function bindRecipeRowClick(row: HTMLTableRowElement) {
        const recipeId: string | null = row.getAttribute("data-recipe-id");
        if (recipeId) {
            window.location.href = window.origin + "/Recipes/Details?id=" + recipeId;
        }
    }

    /**
     * Bind on click for each recipe row 
     */
    const recipeRows: Element[] = Array.from(document.getElementsByClassName("recipe-row"));
    recipeRows.forEach((row: Element) => {
        row.addEventListener("click", function () { bindRecipeRowClick(row as HTMLTableRowElement); });
    });
}
namespace Ingredient {
    /* 
     * Redirect from table row click to the ingredient details page
     */
    function bindIngredientRowClick(row: HTMLTableRowElement) {
        const ingredientId: string | null = row.getAttribute("data-ingredient-id");
        if (ingredientId) {
            window.location.href = window.origin + "/Ingredients/Details?id=" + ingredientId;
        }
    }

    /**
     * Bind on click for each ingredient row 
     */
    const ingredientRows: Element[] = Array.from(document.getElementsByClassName("ingredient-row"));
    ingredientRows.forEach((row: Element) => {
        row.addEventListener("click", function () { bindIngredientRowClick(row as HTMLTableRowElement); });
    });
}
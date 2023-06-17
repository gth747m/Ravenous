namespace RecipeDetails {
    /* 
     * Toggle checkboxes on row click
     */
    function bindCheckboxRowClick(row: HTMLTableRowElement) {
        const inputs: Element[] = Array.from(row.getElementsByTagName("input"));
        inputs.forEach((element: Element) => {
            const input: HTMLInputElement = element as HTMLInputElement;
            if (input.type == "checkbox") {
                input.checked = !input.checked;
            }
        });
    }

    /**
     * Bind on click for each checkbox row 
     */
    const checkboxRows: Element[] = Array.from(document.getElementsByClassName("checkbox-row"));
    checkboxRows.forEach((row: Element) => {
        row.addEventListener("click", function () { bindCheckboxRowClick(row as HTMLTableRowElement); });
    });
}

namespace RecipeDetails {
    /**
     * Bind on click for each checkbox row 
     */
    const checkboxRows: Element[] = Array.from(document.getElementsByClassName("checkbox-row"));
    checkboxRows.forEach((row: Element) => {
        row.addEventListener("click", function (event) {
            // If they didn't click on the checkbox itself
            if ((event.target as HTMLElement).tagName !== "INPUT") {
                // Get the checkbox
                const inputs: Element[] = Array.from(row.getElementsByTagName("INPUT"));
                inputs.forEach((element: Element) => {
                    const input: HTMLInputElement = element as HTMLInputElement;
                    // Check it
                    if (input.type == "checkbox") {
                        input.checked = !input.checked;
                    }
                });
            }
        });
    });
}

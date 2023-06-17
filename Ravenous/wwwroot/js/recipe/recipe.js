"use strict";
/**
 * Add the available measurements to the given <select> element
 * @param selectInput The element to add options to
 */
function addMeasurementOptions(selectInput) {
    const measurementsDiv = document.getElementById("measurements");
    if (!measurementsDiv) {
        return;
    }
    const measurements = Array.from(measurementsDiv.children);
    measurements.forEach((element) => {
        const measurementInput = element;
        if (measurementInput) {
            const measurementOption = document.createElement("option");
            measurementOption.value = measurementInput.value;
            measurementOption.text = measurementInput.name;
            selectInput.options.add(measurementOption);
        }
    });
}
/**
 * Add the available ingredients to the given <select> element
 * @param selectInput The element to add options to
 */
function addIngredientOptions(selectInput) {
    const ingredientsDiv = document.getElementById("ingredients");
    if (!ingredientsDiv) {
        return;
    }
    const ingredients = Array.from(ingredientsDiv.children);
    ingredients.forEach((element) => {
        const ingredientInput = element;
        if (ingredientInput) {
            const ingredientOption = document.createElement("option");
            ingredientOption.value = ingredientInput.value;
            ingredientOption.text = ingredientInput.name;
            selectInput.options.add(ingredientOption);
        }
    });
}
/**
 * Create a new ingredient input group <div>
 * @param num New list entry number
 */
function newIngredientInputGroup(num) {
    const ingredientInputDiv = document.createElement("div");
    ingredientInputDiv.className = "input-group";
    const inputGroupText = document.createElement("span");
    inputGroupText.className = "input-group-text";
    inputGroupText.classList.add("ingredient-number");
    inputGroupText.innerHTML = String(num + 1);
    ingredientInputDiv.appendChild(inputGroupText);
    const amountInput = document.createElement("input");
    amountInput.type = "number";
    amountInput.min = "0";
    amountInput.step = "0.01";
    amountInput.className = "form-control";
    amountInput.name = "amounts";
    ingredientInputDiv.appendChild(amountInput);
    const measurementIdSelect = document.createElement("select");
    measurementIdSelect.className = "form-control";
    measurementIdSelect.name = "measurementIds";
    addMeasurementOptions(measurementIdSelect);
    ingredientInputDiv.appendChild(measurementIdSelect);
    const ingredientIdSelect = document.createElement("select");
    ingredientIdSelect.className = "form-control";
    ingredientIdSelect.name = "ingredientIds";
    addIngredientOptions(ingredientIdSelect);
    ingredientInputDiv.appendChild(ingredientIdSelect);
    const ingredientDeleteDiv = document.createElement("div");
    ingredientDeleteDiv.className = "btn-ingredient-delete";
    ingredientDeleteDiv.addEventListener("click", () => {
        deleteIngredientInputGroup(ingredientDeleteDiv);
    });
    const ingredientDeleteSpan = document.createElement("span");
    ingredientDeleteSpan.classList.add("oi");
    ingredientDeleteSpan.classList.add("oi-circle-x");
    ingredientDeleteDiv.appendChild(ingredientDeleteSpan);
    ingredientInputDiv.appendChild(ingredientDeleteDiv);
    return ingredientInputDiv;
}
/**
 * Create a new instruction input group <div>
 * @param num
 */
function newInstructionInputGroup(num) {
    const instructionInputDiv = document.createElement("div");
    instructionInputDiv.className = "input-group";
    const inputGroupText = document.createElement("span");
    inputGroupText.className = "input-group-text";
    inputGroupText.classList.add("instruction-number");
    inputGroupText.innerHTML = String(num + 1);
    instructionInputDiv.appendChild(inputGroupText);
    const instructionInp = document.createElement("input");
    instructionInp.className = "form-control";
    instructionInp.name = "instructions";
    instructionInputDiv.appendChild(instructionInp);
    const instructionDeleteDiv = document.createElement("div");
    instructionDeleteDiv.className = "btn-instruction-delete";
    instructionDeleteDiv.addEventListener("click", () => {
        deleteInstructionInputGroup(instructionDeleteDiv);
    });
    const instructionDeleteSpan = document.createElement("span");
    instructionDeleteSpan.classList.add("oi");
    instructionDeleteSpan.classList.add("oi-circle-x");
    instructionDeleteDiv.appendChild(instructionDeleteSpan);
    instructionInputDiv.appendChild(instructionDeleteDiv);
    return instructionInputDiv;
}
/**
 *  Add a new ingredient input group
 */
function addIngredientInputGroup() {
    const ingredientInputDiv = document.getElementById("ingredient-div");
    if (!ingredientInputDiv) {
        return;
    }
    ingredientInputDiv.appendChild(newIngredientInputGroup(ingredientInputDiv.children.length));
}
/**
 *  Add a new instruction input group
 */
function addInstructionInputGroup() {
    const instructionDiv = document.getElementById("instruction-div");
    if (!instructionDiv) {
        return;
    }
    instructionDiv.appendChild(newInstructionInputGroup(instructionDiv.children.length));
}
/**
 * Renumber instruction rows
 */
function renumberInstructions() {
    var instructionDiv = document.getElementById("instruction-div");
    if (instructionDiv) {
        var inputGroups = Array.from(instructionDiv.children);
        inputGroups.forEach((inputGroup, index) => {
            var numberSpan = inputGroup.firstElementChild;
            if (numberSpan) {
                numberSpan.innerHTML = String(index + 1);
            }
        });
    }
}
/**
 * Renumber ingredient rows
 */
function renumberIngredients() {
    var ingredientDiv = document.getElementById("ingredient-div");
    if (ingredientDiv) {
        var inputGroups = Array.from(ingredientDiv.children);
        inputGroups.forEach((inputGroup, index) => {
            var numberSpan = inputGroup.firstElementChild;
            if (numberSpan) {
                numberSpan.innerHTML = String(index + 1);
            }
        });
    }
}
/**
 * Delete an instruction row
 * @param element Delete button
 */
function deleteInstructionInputGroup(element) {
    var parent = element.parentElement;
    if (parent) {
        var grandparent = parent.parentElement;
        if (grandparent) {
            grandparent.removeChild(parent);
            renumberInstructions();
        }
    }
}
/**
 * Delete an ingredient row
 * @param element Delete button
 */
function deleteIngredientInputGroup(element) {
    var parent = element.parentElement;
    if (parent) {
        var grandparent = parent.parentElement;
        if (grandparent) {
            grandparent.removeChild(parent);
            renumberIngredients();
        }
    }
}
/*****************************************************************************************
 * Button Bindings
 *****************************************************************************************/
/**
 * Bind click on the add ingredient button
 */
const addIngredientBtn = document.getElementById("add-ingredient-btn");
if (addIngredientBtn) {
    addIngredientBtn.addEventListener("click", () => { addIngredientInputGroup(); });
}
/**
 * Bind click on the add ingredient delete button
 */
const ingredientDeleteBtns = Array.from(document.getElementsByClassName("btn-ingredient-delete"));
ingredientDeleteBtns.forEach((element) => {
    element.addEventListener("click", () => {
        deleteIngredientInputGroup(element);
    });
});
/**
 * Bind click on the add instruction button
 */
const addInstructionBtn = document.getElementById("add-instruction-btn");
if (addInstructionBtn) {
    addInstructionBtn.addEventListener("click", () => { addInstructionInputGroup(); });
}
/**
 * Bind click on the add instruction delete button
 */
const instructionDeleteBtns = Array.from(document.getElementsByClassName("btn-instruction-delete"));
instructionDeleteBtns.forEach((element) => {
    element.addEventListener("click", () => {
        deleteInstructionInputGroup(element);
    });
});
//# sourceMappingURL=recipe.js.map
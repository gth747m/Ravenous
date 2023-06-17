/*
import { newIngredientInputGroup, newInstructionInputGroup } from "recipe.js";

/**
 *  Add a new ingredient input group
 *
function addIngredientInputGroup(): void {
    const ingredientInputDiv: HTMLElement | null = document.getElementById("ingredient-div");
    if (!ingredientInputDiv) {
        return;
    }
    ingredientInputDiv.appendChild(newIngredientInputGroup(ingredientInputDiv.children.length));
}

/**
 *  Add a new instruction input group
 *
function addInstructionInputGroup(): void {
    const instructionDiv: HTMLElement | null = document.getElementById("instruction-div");
    if (!instructionDiv) {
        return;
    }
    instructionDiv.appendChild(newInstructionInputGroup(instructionDiv.children.length));
}

/**
 * Bind click on the add ingredient button
 *
const addIngredientBtn = document.getElementById("add-ingredient-btn");
if (addIngredientBtn) {
    addIngredientBtn.addEventListener("click", () => { addIngredientInputGroup(); });
}

/**
 * Bind click on the add instruction button
 *
const addInstructionBtn = document.getElementById("add-instruction-btn");
if (addInstructionBtn) {
    addInstructionBtn.addEventListener("click", () => { addInstructionInputGroup(); });
}

*/
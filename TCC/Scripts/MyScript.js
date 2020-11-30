﻿//let inputs = document.querySelectorAll("input");
let input = document.querySelectorAll(".input-data");
input.forEach(inputform => {
    let label = inputform.querySelector("label");
    let inputs = inputform.querySelector("input");
    inputform.addEventListener("click", () => {
        label.classList.add("translate");
    });
    if (inputs.value.length == "") {
        label.classList.remove("translate");
    } else {
        label.classList.add("translate");
    }
});


//Masks

$(function () {
    $("#Cnpj").mask("99.999.999/999-99");
    $("#Tel").mask("(99) 9999-9999");
    //$("#Cep").mask("99.999-999");
    $("#Datavalid").mask("99/9999");
    //$("Numcartao").mask("9999 9999 9999 9999");
});
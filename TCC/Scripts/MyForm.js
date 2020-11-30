const btnSubmit = document.querySelector(".submitButton");
const container = document.querySelector(".contentLogin");

btnSubmit.addEventListener("click", (event) => {
    event.preventDefault();

    const fieldsCntainer = [...document.querySelectorAll(".input-Data")]
    fieldsCntainer.forEach(fieldCntainer => {
        const field = fieldCntainer.querySelector("input");
        if (field.value == "") container.classList.add("validate-error");
    });
    container.classList.add("container-hide");


});

container.addEventListener("animationstart", (event) => {
    if (event.animationName == "container-hide-move")
        document.querySelector("body").style.overflow = "hidden"
})


container.addEventListener("animationend", (event) => {
    if (event.animationName == "container-hide-move")
        container.style.display = "none";
    document.querySelector("body").style.overflow = "noen"
})
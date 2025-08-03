document.addEventListener("DOMContentLoaded", function () {
    const searchContainer = document.getElementById("searchContainer");
    const input = document.getElementById("search");
    const results = document.getElementById("searchResults");
    const overlay = document.getElementById("overlay");

    overlay.addEventListener("click", function () {
        results.innerHTML = "";
        overlay.classList.remove("active");
        searchContainer.style.zIndex = 1;
    });

    input.addEventListener("click", () => {
        if (input.value.trim().length >= 2) {
            input.dispatchEvent(new Event("input"));
        }
        overlay.classList.add("active");
        searchContainer.style.zIndex = 10;
    });

    input.addEventListener("focus", () => {
        input.style.width = "400px";
    });

    input.addEventListener("blur", () => {
        input.style.width = "200px";
    });
});
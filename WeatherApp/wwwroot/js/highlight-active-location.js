document.addEventListener("DOMContentLoaded", function () {
    const container = document.getElementById("locationLinks");
    const activeCity = container.dataset.activeCity;
    const link = container.querySelector(`#${activeCity}`);
    link.classList.add("location-active");
});
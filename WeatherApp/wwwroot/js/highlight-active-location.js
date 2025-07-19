document.addEventListener("DOMContentLoaded", function () {
    const container = document.getElementById("locationLinks");
    const activeCityId = container.dataset.activeCityId;
    const link = document.getElementById(activeCityId);
    link.classList.add("location-active");
});
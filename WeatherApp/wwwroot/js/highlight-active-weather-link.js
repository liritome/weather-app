document.addEventListener("DOMContentLoaded", function () {
    const container = document.getElementById("navLinks");
    const activeTab = container.dataset.activeTab;
    const link = container.querySelector(`#${activeTab}`);
    link.classList.add("link-active");
});
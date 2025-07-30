document.addEventListener("DOMContentLoaded", function () {
    const btn = document.getElementById("settingsBtn");
    const settings = document.getElementById("settings");
    const settingsCloseBtn = document.getElementById("settingsCloseBtn");

    btn.addEventListener("click", function (e) {
        e.stopPropagation();
        settings.style.display = settings.style.display == "none" ? "block" : "none";
    });

    document.addEventListener("click", function (e) {
        if (!settings.contains(e.target) && e.target !== btn) {
            settings.style.display = "none";
        }
    });

    settingsCloseBtn.addEventListener("click", function () {
        settings.style.display = "none";
    });
});
document.addEventListener("DOMContentLoaded", function () {
    document.getElementById("temperatureUnitSwitcher").addEventListener("change", function () {
        const selectedUnit = this.value;
        document.cookie = `temperatureUnit=${selectedUnit}; path=/; max-age=31536000`;
        location.reload();
    });

    document.getElementById("speedUnitSwitcher").addEventListener("change", function () {
        const selectedUnit = this.value;
        document.cookie = `speedUnit=${selectedUnit}; path=/; max-age=31536000`;
        location.reload();
    });

    document.getElementById("precipUnitSwitcher").addEventListener("change", function () {
        const selectedUnit = this.value;
        document.cookie = `precipUnit=${selectedUnit}; path=/; max-age=31536000`;
        location.reload();
    });

    document.getElementById("pressureUnitSwitcher").addEventListener("change", function () {
        const selectedUnit = this.value;
        document.cookie = `pressureUnit=${selectedUnit}; path=/; max-age=31536000`;
        location.reload();
    });
});
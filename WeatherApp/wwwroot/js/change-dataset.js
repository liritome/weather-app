document.addEventListener("DOMContentLoaded", function () {
    const switches = [
        "temperature",
        "apparentTemperature",
        "windDirection",
        "windSpeed",
        "windGusts",
        "precipitationProbability",
        "precipitation",
        "pressure",
        "humidity",
        "uvIndex",
        "cloudCover"
    ];
    const defaultSwitches = [
        "temperature",
        "windDirection",
        "windGusts",
        "precipitation",
        "pressure"
    ];
    const resetBtn = document.getElementById("resetDatasetsBtn");

    switches.forEach((name) => {
        const sw = document.getElementById(`${name}Switch`);
        const container = document.getElementById(`${name}Container`);
        const cookieValue = document.cookie.split('; ').find(c => c.startsWith(`${name}Dataset=`))?.split("=")[1] || defaultSwitches.includes(name);
        container.style.display = cookieValue === "true" ? "block" : "none";
        sw.addEventListener("change", function () {
            document.cookie = `${name}Dataset=${this.checked}; path=/; max-age=31536000`;
            container.style.display = this.checked ? "block" : "none";
        });
    });

    resetBtn.addEventListener("click", function () {
        switches.forEach((name) => {
            const sw = document.getElementById(`${name}Switch`);
            sw.checked = defaultSwitches.includes(name);
            sw.dispatchEvent(new Event("change"));
        });
    });
});
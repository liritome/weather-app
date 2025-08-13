document.addEventListener("DOMContentLoaded", function () {
    const input = document.getElementById("search");
    const results = document.getElementById("searchResults");

    fillSavedLocations();

    input.addEventListener("input", async function () {
        const query = input.value.trim();

        if (query.length < 2) {
            results.innerHTML = "";
            return;
        }

        try {
            const res = await fetch(`/Geocoder/SearchLocations?location=${encodeURIComponent(query)}`);
            const locations = await res.json();

            results.innerHTML = "";
            if (locations.length === 0) {
                results.innerHTML = "<li class='list-group-item'>No locations found</li>";
                return;
            }

            locations.forEach(loc => {
                const countryCode = loc.country_code?.toLowerCase();
                const li = document.createElement("li");
                li.className = "search-result-item list-group-item list-group-item-action";
                const locationDetails = [
                    loc.country,
                    loc.admin1,
                    loc.admin2,
                    loc.admin3,
                    loc.admin4
                ].filter(x => x).join(', ');
                li.innerHTML = `
                    <img src="https://hatscripts.github.io/circle-flags/flags/${countryCode}.svg" width="24" style="margin-right: 8px;" />
                    <span style="color: black; font-size: 16px;">${loc.name}</span>
                    <span style="font-size: 14px;">${locationDetails}</span>
                `;
                li.dataset.id = loc.id;
                li.dataset.name = loc.name;

                li.addEventListener("click", () => {
                    saveLocation(loc.name, loc.id);
                    input.value = "";
                    results.innerHTML = "";
                    window.location.href = buildLocationUrl(loc.name, loc.id);
                });

                results.appendChild(li);
            });
        } catch (error) {
            results.innerHTML = "<li class='list-group-item text-danger'>No locations found</li>";
        }
    });
});

function saveLocation(locationName, locationId) {
    let recent = JSON.parse(localStorage.getItem("savedLocations")) || [];
    recent = recent.filter(loc => loc.id !== locationId);
    recent.unshift({ id: locationId, name: locationName });
    if (recent.length > 4) recent = recent.slice(0, 4);
    localStorage.setItem("savedLocations", JSON.stringify(recent));
}

function fillSavedLocations() {
    const saved = JSON.parse(localStorage.getItem("savedLocations")) || [];
    const container = document.getElementById("locationLinks");
    const activeCityId = container.dataset.activeCityId;
    container.innerHTML = "";

    saved.forEach(loc => {
        const a = document.createElement("a");
        a.href = buildLocationUrl(loc.name, loc.id);
        a.id = `${loc.id}`;
        a.textContent = loc.name;

        a.addEventListener("click", () => {
            saveLocation(loc.name, loc.id);
        });

        container.appendChild(a);
    });

    const activeLink = document.getElementById(activeCityId);
    if (activeLink) {
        activeLink.classList.add("location-active");
    }
}

function buildLocationUrl(locationName, locationId) {
    const cityString = `${locationName}-${locationId}`;
    const pathParts = window.location.pathname.split("/").filter(p => p);
    if (pathParts.length >= 3) {
        pathParts[2] = cityString;
    }
    return "/" + pathParts.join("/") + window.location.search;
}
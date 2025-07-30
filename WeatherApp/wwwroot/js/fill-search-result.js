document.addEventListener("DOMContentLoaded", function () {
    const input = document.getElementById("locationSearch");
    const results = document.getElementById("searchResults");
    const overlay = document.getElementById("overlay");

    //localStorage.clear();
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

    document.addEventListener("click", (e) => {
        if (e.target == input) {
            overlay.classList.add("active");
            
        }
        else if (!results.contains(e.target)) {
            results.innerHTML = "";
            overlay.classList.remove("active");
        }
    });

    input.addEventListener("click", () => {
        if (input.value.trim().length >= 2) {
            input.dispatchEvent(new Event("input"));
        }
    });

    input.addEventListener("focus", () => {
        input.style.width = "400px";
    });

    input.addEventListener("blur", () => {
        input.style.width = "200px";
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
    const currentPath = window.location.pathname;

    const params = new URLSearchParams(window.location.search);
    params.delete("city");
    params.set("city", cityString);

    return `${currentPath}?${params.toString()}`;
}
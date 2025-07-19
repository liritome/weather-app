document.addEventListener("DOMContentLoaded", function () {
    const input = document.getElementById("locationSearch");
    const results = document.getElementById("searchResults");

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
                results.innerHTML = "<li class='list-group-item'>No results found</li>";
                return;
            }

            locations.forEach(loc => {
                const li = document.createElement("li");
                li.className = "list-group-item list-group-item-action";
                li.textContent = `${loc.name}${[
                    loc.country,
                    loc.admin1,
                    loc.admin2,
                    loc.admin3,
                    loc.admin4
                ].filter(x => x).map(x => `, ${x}`).join('')}`;
                li.dataset.id = loc.id;
                li.dataset.name = loc.name;

                li.addEventListener("click", () => {
                    const locationId = loc.id;
                    const locationName = loc.name;
                    const cityString = `${locationName}-${locationId}`;

                    input.value = "";
                    results.innerHTML = "";

                    const container = document.getElementById("locationLinks");
                    const existingLink = document.getElementById(`${locationId}`);
                    if (existingLink) {
                        container.removeChild(existingLink);
                        container.insertBefore(existingLink, container.firstChild);
                    }
                    else {
                        const a = document.createElement("a");
                        a.href = `/Weather/Now?city=${encodeURIComponent(cityString)}`;
                        a.id = `${locationId}`;
                        a.textContent = locationName;

                        container.insertBefore(a, container.firstChild);

                        while (container.children.length > 5) {
                            container.removeChild(container.lastChild);
                        }
                    }

                    window.location.href = `/Weather/Now?city=${cityString}`;
                });

                results.appendChild(li);
            });
        } catch (error) {
            console.error("Search failed:", error);
            results.innerHTML = "<li class='list-group-item text-danger'>No results found</li>";
        }
    });

    document.addEventListener("click", (e) => {
        if (!results.contains(e.target) && e.target !== input) {
            results.innerHTML = "";
        }
    });
});
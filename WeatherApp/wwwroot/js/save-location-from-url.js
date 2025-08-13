saveLocationFromUrl();

async function saveLocationFromUrl() {
    const pathParts = window.location.pathname.split('/').filter(p => p);
    let location = null;
    if (pathParts.length >= 2 && pathParts[0].toLowerCase() === "weather") {
        location = pathParts[2];
    }
    const existsResponse = await fetch(`/Geocoder/LocationExists?location=${encodeURIComponent(location)}`);
    const exists = await existsResponse.json();
    if (exists) {
        const parts = location.split('-');
        const name = decodeURIComponent(parts[0]);
        const id = parseInt(parts[1]);
        saveLocation(name, id);
        fillSavedLocations();
    }
}
saveLocationFromUrl();

async function saveLocationFromUrl() {
    const urlParams = new URLSearchParams(window.location.search);
    const location = urlParams.get("city");
    const existsResponse = await fetch(`/Geocoder/LocationExists?location=${encodeURIComponent(location)}`);
    const exists = await existsResponse.json();
    if (exists) {
        const parts = location.split('-');
        const name = parts[0];
        const id = parseInt(parts[1]);
        saveLocation(name, id);
        fillSavedLocations();
    }
}
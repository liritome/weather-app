getLocationByIp();

function getLocationByIp()
{
    const saved = JSON.parse(localStorage.getItem("savedLocations")) || [];
    if (saved.length === 0) {
        const resByIp = fetch(`/Geocoder/GetLocationByIp`);
        const location = resByIp.json();
        let name = location.name;
        let id = location.id;
        saveLocation(name, id);
        window.location.href = buildLocationUrl(name, id);
    }
}
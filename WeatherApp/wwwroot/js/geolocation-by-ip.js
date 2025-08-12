getLocationByIp();

async function getLocationByIp()
{
    const saved = JSON.parse(localStorage.getItem("savedLocations")) || [];
    if (saved.length === 0) {
        const resByIp = await fetch(`/Geocoder/GetLocationByIp`);
        const location = await resByIp.json();
        let name = location.name;
        let id = location.id;
        saveLocation(name, id);
        window.location.href = buildLocationUrl(name, id);
    }
}
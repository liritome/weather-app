document.addEventListener("DOMContentLoaded", function () {
    let currentIndex = 0;
    const gridContainer = document.getElementById("grid-container");
    const days = gridContainer.dataset.days;
    const daysVisible = gridContainer.dataset.daysVisible;
    const dayWidth = gridContainer.dataset.dayWidth;
    const sliders = document.querySelectorAll('.slider');
    const btnLeft = document.getElementById("btnLeft");
    const btnRight = document.getElementById("btnRight");

    function slideRight() {
        if (currentIndex < days - daysVisible) {
            currentIndex++;
            updateSlider();
        }
    }

    function slideLeft() {
        if (currentIndex > 0) {
            currentIndex--;
            updateSlider();
        }
    }

    function updateSlider() {
        const offset = currentIndex * -dayWidth;
        sliders.forEach(slider => {
            slider.style.transform = `translateX(${offset}px)`;
        });
        btnLeft.disabled = currentIndex <= 0;
        btnRight.disabled = currentIndex >= days - daysVisible;
    }

    btnLeft.addEventListener('click', slideLeft);
    btnRight.addEventListener('click', slideRight);

    updateSlider();
});
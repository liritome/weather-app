document.addEventListener("DOMContentLoaded", function () {
    let currentIndex = 0;
    const gridContainer = document.getElementById("grid-container");
    const items = Number(gridContainer.dataset.items);
    const itemsVisible = Number(gridContainer.dataset.itemsVisible);
    const itemWidth = Number(gridContainer.dataset.itemWidth);
    const step = Number(gridContainer.dataset.step);
    const sliders = document.querySelectorAll('.slider');
    const btnLeft = document.getElementById("btnLeft");
    const btnRight = document.getElementById("btnRight");

    function slideRight() {
        if (currentIndex < items - itemsVisible && items - currentIndex - itemsVisible >= step) {
            currentIndex += step;
        }
        else {
            currentIndex = items - itemsVisible;
        }
        updateSlider();
    }

    function slideLeft() {
        if (currentIndex > 0 && currentIndex >= step) {
            currentIndex -= step;
        }
        else {
            currentIndex = 0;
        }
        updateSlider();
    }

    function updateSlider() {
        const offset = currentIndex * -itemWidth;
        sliders.forEach(slider => {
            slider.style.transform = `translateX(${offset}px)`;
        });
        btnLeft.disabled = currentIndex <= 0;
        btnRight.disabled = currentIndex >= items - itemsVisible;
    }

    btnLeft.addEventListener('click', slideLeft);
    btnRight.addEventListener('click', slideRight);

    updateSlider();
});
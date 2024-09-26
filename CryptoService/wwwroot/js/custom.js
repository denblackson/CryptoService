// /wwwroot/swagger/custom.js

document.addEventListener("DOMContentLoaded", function () {
    var dropdown = document.querySelector('#algorithm'); // Шукаємо випадаючий список алгоритмів
    if (dropdown) {
        dropdown.addEventListener('change', function () {
            console.log("Алгоритм вибрано: ", dropdown.value);
            // Додай свою логіку
        });
    }
});

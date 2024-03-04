// Change plus/minus sign on click for collapsible elements Ingredients and Nutritional Information
const toggleSigns = document.querySelectorAll(".toggle-sign");

for (let i = 0; i < toggleSigns.length; i++) {
  toggleSigns[i].addEventListener("click", function () {
    const x = toggleSigns[i].querySelector("span");
    if (toggleSigns[i].classList.contains("collapsed")) {
      x.textContent = "+";
    } else {
      x.textContent = "-";
    }
  });
}
